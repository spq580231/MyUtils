using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace MyUtils.Function
{
    public static class AppUtils
    {
        /// <summary>
        /// 将UTF-8编码文本追加到已有文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="str"></param>
        public static void AppendText(string path, string str)
        {
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
        }
        /// <summary>
        /// 从文件读取字符串
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>字符串</returns>
        public static string ReadStr(string path)
        {
            string str;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
            {
                str = sr.ReadToEnd();
            }
            return str;
        }
        /// <summary>
        /// 从文件读取字符串
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>JSON字符串</returns>
        public static string ReadJsonStr(string path)
        {
            return JsonConvert.SerializeObject(JObject.Parse(ReadStr(path)), Newtonsoft.Json.Formatting.Indented);
        }
        /// <summary>
        /// 从文件读取JObject字符串
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static JObject ReadJobject(string path)
        {
            return JObject.Parse(ReadJsonStr(path));
        }
        /// <summary>
        /// 从文件读取JArray字符串
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static JArray ReadJArray(string path)
        {
            return JArray.Parse(ReadJsonStr(path));
        }
        /// dataTable转换成Json格式字符串     
        ///	</summary>     
        ///	<param name="dt"/>
        ///	<param name="Counts">总记录数</param>  
        ///	<returns>返回JSON数据，无则返回空</returns>     
        public static string DataTableToJson(DataTable dt, int Counts)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            jsonBuilder.Append("\"total\":");
            jsonBuilder.Append(Counts.ToString());
            jsonBuilder.Append(",\"rows\":[ ");
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jsonBuilder.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        jsonBuilder.Append("\"");
                        jsonBuilder.Append(dt.Columns[j].ColumnName);
                        jsonBuilder.Append("\":\"");
                        jsonBuilder.Append(dt.Rows[i][j].ToString());
                        jsonBuilder.Append("\",");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("},");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            }
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return JsonConvert.SerializeObject(JObject.Parse(jsonBuilder.ToString()), Newtonsoft.Json.Formatting.Indented);
        }
        /// <summary>
        /// 记录程序使用时间
        /// </summary>
        /// <param name="action"></param>
        /// <param name="isParal">是否并发执行</param>
        public static void GitTime(Action action, bool isParal)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            if (isParal)
            {
                Parallel.Invoke(action);
            }
            else
            {
                action();
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
        /// <summary>
        /// 把DataTable的列名改成实体类的注释
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DataTable ChangeColumnNnames(DataTable dt, Type obj)
        {
            PropertyInfo[] peroperties = obj.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in peroperties)
            {
                object[] objs = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objs.Length < 0) return null;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (property.Name.Equals(dt.Columns[i].ColumnName.ToLower()))
                    {
                        dt.Columns[i].ColumnName = ((DescriptionAttribute)objs[0]).Description;
                    }
                }
            }
            return dt;
        }
        /// <summary>
        /// 把DataGridView的列名改成实体类的注释
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="obj"></param>
        public static void ChangeColumnNnames(DataGridView dgv, Type obj)
        {
            PropertyInfo[] peroperties = obj.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in peroperties)
            {
                object[] objs = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objs.Length < 0) return;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (property.Name.Equals(dgv.Columns[i].Name.ToLower()))
                    {
                        dgv.Columns[i].HeaderText = ((DescriptionAttribute)objs[0]).Description;
                    }
                }
            }
        }
        /// <summary>
        /// DataTable转实体类（多行）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> DataTableToListEntity<T>(DataTable dt) where T : class, new()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                PropertyInfo[] pArray = type.GetProperties();
                T entity = new T();
                foreach (PropertyInfo p in pArray)
                {
                    if (row[p.Name] is Int64)
                    {
                        p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                        continue;
                    }
                    p.SetValue(entity, row[p.Name], null);
                }
                list.Add(entity);
            }
            return list;
        }
        /// <summary>
        /// DataTable转实体类（单行）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T DataTableToEntity<T>(DataTable dt) where T : class, new()
        {
            Type type = typeof(T);
            T entity = new T();
            foreach (DataRow row in dt.Rows)
            {
                PropertyInfo[] pArray = type.GetProperties();
                foreach (PropertyInfo p in pArray)
                {
                    if (row[p.Name] is Int64)
                    {
                        p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                        continue;
                    }
                    p.SetValue(entity, row[p.Name], null);
                }
            }
            return entity;
        }
        /// <summary>
        /// DataTable 对象 转换为Json 字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
            ArrayList arrayList = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();  //实例化一个参数集合
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToString());
                }
                arrayList.Add(dictionary); //ArrayList集合中添加键值
            }
            return javaScriptSerializer.Serialize(arrayList);  //返回一个json字符串
        }

        /// <summary>
        /// JArray转换为DataTable
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DataTable JArrayToDataTable(JArray array)
        {
            if (array.Count < 1) return null;
            DataTable table = new DataTable();
            StringBuilder columns = new StringBuilder();
            JObject objColumns = array[0] as JObject;
            //构造表头
            foreach (JToken jkon in objColumns.AsEnumerable<JToken>())
            {
                string name = ((JProperty)(jkon)).Name;
                columns.Append(name + ",");
                table.Columns.Add(name);
            }
            //向表中添加数据
            for (int i = 0; i < array.Count; i++)
            {
                DataRow row = table.NewRow();
                JObject obj = array[i] as JObject;
                foreach (JToken jkon in obj.AsEnumerable<JToken>())
                {

                    string name = ((JProperty)(jkon)).Name;
                    string value = ((JProperty)(jkon)).Value.ToString();
                    row[name] = value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
        /// <summary>
        /// 对象转XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ObjToXml<T>(T t)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xz = new XmlSerializer(t.GetType());
                xz.Serialize(sw, t);
                return sw.ToString();
            }
        }
        /// <summary>
        /// XML转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T XmlToObj<T>(T t, string s)
        {
            using (StringReader sr = new StringReader(s))
            {
                XmlSerializer xz = new XmlSerializer(t.GetType());
                return (T)xz.Deserialize(sr);
            }
        }
        /// <summary>
        /// XML转DataSet
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static DataSet XmlToDataSet(string xmlString)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlString);
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmldoc.InnerXml);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                reader.Close();
                return xmlDS;
            }
            catch (System.Exception ex)
            {
                reader.Close();
                throw ex;
            }
        }
        /// <summary>
        /// XML 转 JOSN
        /// </summary>
        public static string XmltoJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return JsonConvert.SerializeXmlNode(doc);
        }
        /// <summary>
        /// 遍历Json 形成键值对
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string KeyValueCombination(string str)
        {
            var obj = JObject.Parse(str);
            string ren = "";
            foreach (var x in obj as JObject)
            {
                ren += x.Key + "=" + x.Value + "&";
            }
            return ren.TrimEnd('&');
        }
        /// <summary>
        /// JJSON按key进行排序
        /// </summary>
        /// <param name="jobj">原始JSON JToken.Parse(string json);</param>
        /// <param name="obj">初始值Null</param>
        /// <returns></returns>
        public static string SortJson(string s)
        {
            var a = JObject.Parse(s);
            var target = KeySort(a);
            return JsonConvert.SerializeObject(target, Newtonsoft.Json.Formatting.Indented);

        }
        public static SortedDictionary<string, object> KeySort(JObject obj)
        {
            var res = new SortedDictionary<string, object>();
            foreach (var x in obj)
            {
                if (x.Value is JValue) res.Add(x.Key, x.Value);
                else if (x.Value is JObject) res.Add(x.Key, KeySort((JObject)x.Value));
                else if (x.Value is JArray)
                {
                    var tmp = new SortedDictionary<string, object>[x.Value.Count()];
                    for (var i = 0; i < x.Value.Count(); i++)
                    {
                        tmp[i] = KeySort((JObject)x.Value[i]);
                    }
                    res.Add(x.Key, tmp);
                }
            }
            return res;
        }


        /// <summary>
        /// 字符串转16进制
        /// </summary>
        /// <param name="mStr"></param>
        /// <returns></returns>
        public static string getHexString(string mStr)
        {
            String ret = "";
            byte[] bytes = ASCIIEncoding.Default.GetBytes(mStr);
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += ((int)(bytes[i] + 0x100)).ToString("X").Substring(1);

            }
            return ret;
        }
        /// <summary>
        /// 16进制字符串转字节
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] hexStringToBytes(String hexString)
        {
            if (hexString == null || hexString.Equals(""))
            {
                return null;
            }

            hexString = hexString.ToUpper();
            int length = hexString.Length / 2;
            char[] hexChars = hexString.ToCharArray();
            byte[] d = new byte[length];
            for (int i = 0; i < length; i++)
            {
                int pos = i * 2;
                d[i] = (byte)Int32.Parse(hexString.Substring(pos, 2), System.Globalization.NumberStyles.HexNumber);
            }
            return d;
        }
        /// <summary>
        /// <summary>
        /// 将字符串编码为Base64字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Encode(string str)
        {
            byte[] barray;
            barray = Encoding.Default.GetBytes(str);
            return Convert.ToBase64String(barray);
        }
        /// <summary>
        /// 将Base64字符串解码为普通字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Decode(string str)
        {
            byte[] barray;
            try
            {
                barray = Convert.FromBase64String(str);
                return Encoding.Default.GetString(barray);
            }
            catch
            {
                return str;
            }
        }
       
    }
}
