using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MyUtils.Entity
{
    /// <summary>
    ///  5.3.1明细审核
    /// </summary>

    ///   输入就诊信息为单行数据，
    ///   输入诊断信息为多行数据，
    ///   输入费用明细信息为多行数据，
    ///   输出分析信息为单行数据，
    ///   输出违规信息为单行数据，
    ///   输出违规明细信息为多行数据。
    public class data
    {
        [Description("系统编码")]
        public string syscode { get; set; }
        [Description("规则标识集合")]
        public string rule_ids { get; set; }

        [Description("任务ID")]
        public string task_id { get; set; }

        [Description("触发场景")]
        public string trig_scen { get; set; }
    }
}
