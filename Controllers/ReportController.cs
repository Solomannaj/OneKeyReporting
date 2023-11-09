using DataExtractionTool.DataLayer.Models;
using DataExtractionTool.DataLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace DataExtractionTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportResultRepository _context;
        public ReportController(IReportResultRepository context)
        {
            _context = context;            
        }

        [HttpPost]
        [Route("GetReport")]
        public IQueryable<object> GetReport(FilterParams_DTO parameters)
        {
            SqlParameter[] inputParameter = {

                new SqlParameter("@MATSOC", parameters.MATSOC),

                new SqlParameter("@HCP_IND_STATUS", parameters.HCP_IND_STATUS),
                    
                new SqlParameter("@HCP_ACT_STATUS", parameters.HCP_ACT_STATUS),
 
                new SqlParameter("@HCP_TYPE", parameters.HCP_TYPE),
 
                new SqlParameter("@HCP_SP_type", parameters.HCP_SP_type),
 
                new SqlParameter("@HCP_SP1", parameters.HCP_SP1),
 
                new SqlParameter("@HCP_SP2", parameters.HCP_SP2),
 
                new SqlParameter("@HCP_SP3", parameters.HCP_SP3),
 
                new SqlParameter("@HCP_TIH1", parameters.HCP_TIH1),
 
                new SqlParameter("@HCP_TIH2", parameters.HCP_TIH2),
 
                new SqlParameter("@HCP_TEN", parameters.HCP_TEN),
 
                new SqlParameter("@HCP_PRIM_FLAG", parameters.HCP_PRIM_FLAG),
 
                new SqlParameter("@HCO_STATE", parameters.HCO_STATE),
 
                new SqlParameter("@HCO_SP", parameters.HCO_SP),
 
                new SqlParameter("@HCO_TYP", parameters.HCO_TYP),
 
                new SqlParameter("@HCO_SECTOR", parameters.HCO_SECTOR),
 
                new SqlParameter("@HCO_MC", parameters.HCO_MC),
 
                new SqlParameter("@HCO_POSTCODE", parameters.HCO_POSTCODE),
 
                new SqlParameter("@HCO_NAME_PART", parameters.HCO_NAME_PART),
 
                new SqlParameter("@MAIL_STATUS", parameters.MAIL_STATUS),
 
                new SqlParameter("@FAX_STATUS", parameters.FAX_STATUS),
 
                new SqlParameter("@CALL_STATUS", parameters.CALL_STATUS),
 
                new SqlParameter("@EMAIL_STATUS", parameters.EMAIL_STATUS),
            };            
         
            return _context.GetDataProc("EXEC Usp_Get_STD_HCP_Mailing_final_temp " +
                " @MATSOC, " +
                "@HCP_IND_STATUS, " +
                "@HCP_ACT_STATUS, " +
                "@HCP_TYPE, " +
                "@HCP_SP_type, " +
                "@HCP_SP1," +
                "@HCP_SP2, " +
                "@HCP_SP3, " +
                "@HCP_TIH1, " +
                "@HCP_TIH2, " +
                "@HCP_TEN, " +
                "@HCP_PRIM_FLAG, " +
                "@HCO_STATE, " +
                "@HCO_SP, " +
                "@HCO_TYP, " +
                "@HCO_SECTOR, " +
                "@HCO_MC, " +
                "@HCO_POSTCODE, " +
                "@HCO_NAME_PART, " +
                "@MAIL_STATUS, " +
                "@FAX_STATUS, " +
                "@CALL_STATUS, " +
                "@EMAIL_STATUS",
                inputParameter);
        }
    }
}
