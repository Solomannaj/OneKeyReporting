using DataExtractionTool.DataLayer.Models;
using DataExtractionTool.DataLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataExtractionTool.Helpers;
using System.IO;
using System;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
//using System.Web.Http;

namespace DataExtractionTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        //private readonly IReportResultRepository _context;
        private readonly IADORepository _ADOContext;
        IWebHostEnvironment _hostingEnv;
        public ReportController( IWebHostEnvironment hostingEnv, IADORepository ADOContext)//IReportResultRepository context,
        {
            //_context = context;
            _hostingEnv = hostingEnv;
            _ADOContext = ADOContext;
        }

        //[HttpPost]
        //[Route("GetReport")]
        //public async Task<int> GetReport(FilterParams_DTO parameters)
        //{
        //    SqlParameter[] inputParameter = {

        //        new SqlParameter("@MATSOC", parameters.MATSOC),

        //        new SqlParameter("@HCP_IND_STATUS", parameters.HCP_IND_STATUS),
                    
        //        new SqlParameter("@HCP_ACT_STATUS", parameters.HCP_ACT_STATUS),
 
        //        new SqlParameter("@HCP_TYPE", parameters.HCP_TYPE),
 
        //        new SqlParameter("@HCP_SP_type", parameters.HCP_SP_type),
 
        //        new SqlParameter("@HCP_SP1", parameters.HCP_SP1),
 
        //        new SqlParameter("@HCP_SP2", parameters.HCP_SP2),
 
        //        new SqlParameter("@HCP_SP3", parameters.HCP_SP3),
 
        //        new SqlParameter("@HCP_TIH1", parameters.HCP_TIH1),
 
        //        new SqlParameter("@HCP_TIH2", parameters.HCP_TIH2),
 
        //        new SqlParameter("@HCP_TEN", parameters.HCP_TEN),
 
        //        new SqlParameter("@HCP_PRIM_FLAG", parameters.HCP_PRIM_FLAG),
 
        //        new SqlParameter("@HCO_STATE", parameters.HCO_STATE),
 
        //        new SqlParameter("@HCO_SP", parameters.HCO_SP),
 
        //        new SqlParameter("@HCO_TYP", parameters.HCO_TYP),
 
        //        new SqlParameter("@HCO_SECTOR", parameters.HCO_SECTOR),
 
        //        new SqlParameter("@HCO_MC", parameters.HCO_MC),
 
        //        new SqlParameter("@HCO_POSTCODE", parameters.HCO_POSTCODE),
 
        //        new SqlParameter("@HCO_NAME_PART", parameters.HCO_NAME_PART),
 
        //        new SqlParameter("@MAIL_STATUS", parameters.MAIL_STATUS),
 
        //        new SqlParameter("@FAX_STATUS", parameters.FAX_STATUS),
 
        //        new SqlParameter("@CALL_STATUS", parameters.CALL_STATUS),
 
        //        new SqlParameter("@EMAIL_STATUS", parameters.EMAIL_STATUS),
        //    };

        //    var result = await _context.GetDataProc("EXEC Usp_Get_STD_HCP_Mailing_final_temp " +
        //       " @MATSOC, " +
        //       "@HCP_IND_STATUS, " +
        //       "@HCP_ACT_STATUS, " +
        //       "@HCP_TYPE, " +
        //       "@HCP_SP_type, " +
        //       "@HCP_SP1," +
        //       "@HCP_SP2, " +
        //       "@HCP_SP3, " +
        //       "@HCP_TIH1, " +
        //       "@HCP_TIH2, " +
        //       "@HCP_TEN, " +
        //       "@HCP_PRIM_FLAG, " +
        //       "@HCO_STATE, " +
        //       "@HCO_SP, " +
        //       "@HCO_TYP, " +
        //       "@HCO_SECTOR, " +
        //       "@HCO_MC, " +
        //       "@HCO_POSTCODE, " +
        //       "@HCO_NAME_PART, " +
        //       "@MAIL_STATUS, " +
        //       "@FAX_STATUS, " +
        //       "@CALL_STATUS, " +
        //       "@EMAIL_STATUS",
        //       inputParameter);
         
        //    return result.ToList().Count();
        //}

        [HttpPost]
        [Route("ExportReportHCO")]
        public  async Task<FileResult> ExportReportHCO(FilterParamsHCO_DTO parameters, string country)
        {
            SqlParameter[] inputParameter = {

                new SqlParameter("@MATSOC", parameters.MATSOC),

                new SqlParameter("@HCO_STATUS", parameters.HCO_STATUS),               

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

            var _reportData = await _ADOContext.GetDataTable("Usp_Get_STD_HCO_Mailing_final", inputParameter, country);

            // string path = sfdlgDownloadReport.FileName;

            if (_reportData.Rows.Count > 0)
            {
                //Path.GetFileName() sfdlgDownloadReport.=".csv"
                //var strFilePath = "C:\\Users\\u1148431\\Raushan\\DotNet\\2023\\Learning\\CustomReport.csv";
                //var strFilePath = "\\\\Sydssql0193p\\data_group\\ONEKEY\\Data_Extractions\\CustomReport.csv";
                //string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                //string strFilePath = Path.Combine(path, "CustomReport.csv");
                StreamWriter sw = new StreamWriter(Path.Combine( _hostingEnv.ContentRootPath,"test.csv"), false);
                //headers    
                for (int i = 0; i < _reportData.Columns.Count; i++)
                {
                    sw.Write(_reportData.Columns[i]);
                    if (i < _reportData.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                foreach (DataRow dr in _reportData.Rows)
                {
                    for (int i = 0; i < _reportData.Columns.Count; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            string value = dr[i].ToString();
                            if (value.Contains(','))
                            {
                                value = String.Format("\"{0}\"", value);
                                sw.Write(value);
                            }
                            else
                            {
                                sw.Write(dr[i].ToString());
                            }
                        }
                        if (i < _reportData.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                
                sw.Close();

            }
            string fileName = "foo.csv";
            byte[] fileBytes = System.IO.File.ReadAllBytes(Path.Combine(_hostingEnv.ContentRootPath, "test.csv")) ;

            return File(fileBytes, "text/csv", fileName); // this is the key!
        }

        [HttpPost]
        [Route("ExportReportHCP")]
        public async Task<FileResult> ExportReportHCP(FilterParamsHCP_DTO parameters, string country)
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

            var _reportData = await _ADOContext.GetDataTable("Usp_Get_STD_HCP_Mailing_final_temp", inputParameter, country);

            // string path = sfdlgDownloadReport.FileName;

            if (_reportData.Rows.Count > 0)
            {
                //Path.GetFileName() sfdlgDownloadReport.=".csv"
                //var strFilePath = "C:\\Users\\u1148431\\Raushan\\DotNet\\2023\\Learning\\CustomReport.csv";
                //var strFilePath = "\\\\Sydssql0193p\\data_group\\ONEKEY\\Data_Extractions\\CustomReport.csv";
                //string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                //string strFilePath = Path.Combine(path, "CustomReport.csv");
                StreamWriter sw = new StreamWriter(Path.Combine(_hostingEnv.ContentRootPath, "test.csv"), false);
                //headers    
                for (int i = 0; i < _reportData.Columns.Count; i++)
                {
                    sw.Write(_reportData.Columns[i]);
                    if (i < _reportData.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                foreach (DataRow dr in _reportData.Rows)
                {
                    for (int i = 0; i < _reportData.Columns.Count; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            string value = dr[i].ToString();
                            if (value.Contains(','))
                            {
                                value = String.Format("\"{0}\"", value);
                                sw.Write(value);
                            }
                            else
                            {
                                sw.Write(dr[i].ToString());
                            }
                        }
                        if (i < _reportData.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }

                sw.Close();

            }
            string fileName = "foo.csv";
            byte[] fileBytes = System.IO.File.ReadAllBytes(Path.Combine(_hostingEnv.ContentRootPath, "test.csv"));

            return File(fileBytes, "text/csv", fileName); // this is the key!
        }

        [HttpPost]
        [Route("GetReportHCO")]
        public async Task<int> GetReportHCO(FilterParamsHCO_DTO parameters, string country)
        {
            SqlParameter[] inputParameter = {

                new SqlParameter("@MATSOC", parameters.MATSOC),

                new SqlParameter("@HCO_STATUS", parameters.HCO_STATUS),              

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

            var result =await _ADOContext.GetDataTable("Usp_Get_STD_HCO_Mailing_final", inputParameter, country);
            return result.Rows.Count;           
        }

        [HttpPost]
        [Route("GetReportHCP")]
        public async Task<int> GetReportHCP(FilterParamsHCP_DTO parameters, string country)
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
           

            var result = await _ADOContext.GetDataTable("Usp_Get_STD_HCP_Mailing_final", inputParameter, country);
            return result.Rows.Count;
        }


    }
}
