using System.ComponentModel;

namespace MyUtils.Entity
{
    public  class brxx
    {
        [Description("ID")]
        public string id { get; set; }
        [Description("姓名")]
        public string xm { get; set; }

        [Description("性别")]
        public string xb { get; set; }

        [Description("年龄")]
        public string nl { get; set; }

        public override string ToString()
        {
            return "{id=" + id + ",xm=" + xm + ",xb=" + xb + ",nl=" + nl+"}";
        }
    }
}
