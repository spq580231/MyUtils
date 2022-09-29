using System.ComponentModel;

namespace MyUtils.Entity
{
    public  class setlinfo
    {
        [Description("人员编号")]
        public string psn_no { get; set; }
        [Description("就诊ID")]
        public string mdtrt_id { get; set; }
        [Description("结算ID")]
        public string setl_id { get; set; }
        [Description("医保编号")]
        public string hi_no { get; set; }
        [Description("病案号")]
        public string medcasno { get; set; }
        [Description("申报时间")]
        public string dcla_time { get; set; }
        [Description("国籍")]
        public string ntly { get; set; }
        [Description("职业")]
        public string prfs { get; set; }
        [Description("现住址")]
        public string curr_addr { get; set; }
        [Description("单位名称")]
        public string emp_name { get; set; }
        [Description("单位地址")]
        public string emp_addr { get; set; }
        [Description("单位电话")]
        public string emp_tel { get; set; }
        [Description("邮编")]
        public string poscode { get; set; }
        [Description("联系人姓名")]
        public string coner_name { get; set; }
        [Description("与患者关系")]
        public string patn_rlts { get; set; }
        [Description("联系人地址")]
        public string coner_addr { get; set; }
        [Description("联系人电话")]
        public string coner_tel { get; set; }
        [Description("新生儿入院类型")]
        public string nwb_admtype { get; set; }
        [Description("新生儿出生体重")]
        public string nwbbirwt { get; set; }
        [Description("新生儿入院体重")]
        public string nwbadmwt { get; set; }
        [Description("多新生儿出生体重")]
        public string mul_nwb_bir_wt { get; set; }
        [Description("多新生儿入院体重")]
        public string mul_nwb_adm_wt { get; set; }
        [Description("门诊慢特病诊断科别")]
        public string opsp_diag_caty { get; set; }
        [Description("门诊慢特病就诊日期")]
        public string opsp_mdtrt_date { get; set; }
        [Description("入院途径")]
        public string adm_way { get; set; }
        [Description("治疗类别")]
        public string trt_type { get; set; }
        [Description("入院时间")]
        public string adm_time { get; set; }
        [Description("转科科别")]
        public string refldept_dept { get; set; }
        [Description("出院时间")]
        public string dscg_time { get; set; }
        [Description("出院科别")]
        public string dscg_caty { get; set; }
        [Description("门（急）诊诊断（西医诊断）")]
        public string otp_wm_dise { get; set; }
        [Description("西医疾病代码")]
        public string wm_dise_code { get; set; }
        [Description("门（急）诊诊断（中医诊断）")]
        public string otptcmdise { get; set; }
        [Description("中医疾病代码")]
        public string tcmdisecode { get; set; }
        [Description("呼吸机使用时长")]
        public string vent_used_dura { get; set; }
        [Description("颅脑损伤患者入院前昏迷时长")]
        public string pwcry_bfadm_coma_dura { get; set; }
        [Description("颅脑损伤患者入院后昏迷时长")]
        public string pwcry_afadm_coma_dura { get; set; }
        [Description("特级护理天数")]
        public string spga_nurscare_days { get; set; }
        [Description("一级护理天数")]
        public string lv1_nurscare_days { get; set; }
        [Description("二级护理天数")]
        public string scd_nurscare_days { get; set; }
        [Description("三级护理天数")]
        public string lv3_nurscare_days { get; set; }
        [Description("离院方式")]
        public string dscg_way { get; set; }
        [Description("拟接收机构名称")]
        public string acp_medins_name { get; set; }
        [Description("拟接收机构代码")]
        public string acp_optins_code { get; set; }
        [Description("票据代码")]
        public string bill_code { get; set; }
        [Description("票据号码")]
        public string bill_no { get; set; }
        [Description("业务流水号")]
        public string biz_sn { get; set; }
        [Description("出院31天内再住院计划标志")]
        public string days_rinp_flag_31 { get; set; }
        [Description("出院31天内再住院计划目的")]
        public string days_rinp_pup_31 { get; set; }
        [Description("主诊医师代码")]
        public string chfpdr_code { get; set; }
        [Description("结算开始日期")]
        public string setl_begn_date { get; set; }
        [Description("结算结束日期")]
        public string setl_end_date { get; set; }
        [Description("医疗机构填报部门")]
        public string medins_fill_dept { get; set; }
        [Description("医疗机构填报人")]
        public string medins_fill_psn { get; set; }
        [Description("责任护士代码")]
        public string resp_nurs_code { get; set; }
        [Description("状态分类")]
        public string stas_type { get; set; }
        [Description("医保支付方式")]
        public string hi_paymtd { get; set; }

    }
}
