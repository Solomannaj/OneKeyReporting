using Microsoft.CodeAnalysis;
using System.Data;

namespace DataExtractionTool.DataLayer.Models
{
    public class ReportResult
    {
        public string HCP_UNIQUE_ID { get; set; }
        public string TITLE { get; set; }
        public string IND_TYPE { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string SPECIALTY { get; set; }
        public string SPECIALTY2 { get; set; }
        public string SPECIALTY3 { get; set; }
        public string ROLE2 { get; set; }
        public string SPECIAL_INTEREST1 { get; set; }
        public string SPECIAL_INTEREST2 { get; set; }
        public string SPECIAL_INTEREST3 { get; set; }
        public string SPECIAL_INTEREST4 { get; set; }
        public string SPECIAL_INTEREST5 { get; set; }
        public string INDIVIDUAL_STATUS { get; set; }
        public string ACTIVITY_STATUS { get; set; }
        public string ORGANISATION_ID_L3 { get; set; }
        public string ORGANISATION_NAME_L3 { get; set; }
        public string ORGANISATION_ID_L2 { get; set; }
        public string ORGANISATION_NAME_L2 { get; set; }
        public string ORGANISATION_ID_L1 { get; set; }
        public string ORGANISATION_NAME_L1 { get; set; }
        public string ACCOUNT_ID { get; set; }
        public string ACCOUNT_NAME { get; set; }
        public string ACCOUNT_TYPE { get; set; }
        public string ACCOUNT_SPECIALTY { get; set; }
        public string Public_Private { get; set; }
        public string PRIMARY_AFFILIATION { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string SUBURB { get; set; }
        public string STATE { get; set; }
        public string POST_CODE { get; set; }
        public string mailing_ADDRESS1 { get; set; }
        public string mailing_ADDRESS2 { get; set; }
        public string mailing_ADDRESS3 { get; set; }
        public string mailing_SUBURB { get; set; }
        public string mailing_STATE { get; set; }
        public string mailing_POST_CODE { get; set; }
        public string metro_country { get; set; }
        public string BRICK_CODE { get; set; }
        public string BRICK_DESC { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string FAX_NUMBER { get; set; }
        public string Mail_Status { get; set; }       
        public string Fax_Status { get; set; }        
        public string Phone_Status { get; set; }      
        public string WKP_Email_Status { get; set; }
        
    }
}
