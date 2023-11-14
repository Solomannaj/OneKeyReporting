namespace DataExtractionTool.DataLayer.Models
{
    public class FilterParamsHCP_DTO
    {
        public string MATSOC { get; set; }
        public string HCP_IND_STATUS { get; set; }
        public string HCP_ACT_STATUS { get; set; }
        public string HCP_TYPE { get; set; }
        public string HCP_SP_type { get; set; }
        public string HCP_SP1 { get; set; }
        public string HCP_SP2 { get; set; }
        public string HCP_SP3 { get; set; }
        public string HCP_TIH1 { get; set; }
        public string HCP_TIH2 { get; set; }
        public string HCP_TEN { get; set; }
        public string HCP_PRIM_FLAG { get; set; }
        public string HCO_STATE { get; set; }
        public string HCO_SP { get; set; }
        public string HCO_TYP { get; set; }
        public string HCO_SECTOR { get; set; }
        public string HCO_MC { get; set; }
        public string HCO_POSTCODE { get; set; }
        public string HCO_NAME_PART { get; set; }
        public string MAIL_STATUS { get; set; }
        public string FAX_STATUS { get; set; }
        public string CALL_STATUS { get; set; }
        public string EMAIL_STATUS { get; set; }
    }

    public class FilterParamsHCO_DTO
    {
        public string MATSOC { get; set; }
        public string HCO_STATUS { get; set; }   
        public string HCO_STATE { get; set; }
        public string HCO_SP { get; set; }
        public string HCO_TYP { get; set; }
        public string HCO_SECTOR { get; set; }
        public string HCO_MC { get; set; }
        public string HCO_POSTCODE { get; set; }
        public string HCO_NAME_PART { get; set; }
        public string MAIL_STATUS { get; set; }
        public string FAX_STATUS { get; set; }
        public string CALL_STATUS { get; set; }
        public string EMAIL_STATUS { get; set; }
    }
}
