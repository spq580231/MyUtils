using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyUtils.Case
{
    [AttributeUsage(AttributeTargets.Class)]

    /// <summary>
    /// 自定义特性
    /// </summary>
    internal sealed class MyAttribute:Attribute
    {
        /// <summary>
        /// 开发者
        /// </summary>
        public string developer;
        /// <summary>
        /// 版本
        /// </summary>
        public string version;
        /// <summary>
        /// 说明
        /// </summary>
        public string descripion;

        public MyAttribute(string developer, string version, string descripion)
        {
            this.developer = developer;
            this.version = version;
            this.descripion = descripion;
        }
    }
}
