using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataExtractionTool.DataLayer.Repositories;
using DataExtractionTool.DataLayer.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Data;

namespace DataExtractionTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        private readonly IMatsocResultRepository _matsocContext;
        private readonly IHCPTypeResultRepository _hcpTypeContext;
        private readonly IADORepository _ADOContext;
        public FiltersController(IMatsocResultRepository matsocContext, IHCPTypeResultRepository hcpTypeContext, IADORepository ADOContext)
        {
            _matsocContext = matsocContext;
            _hcpTypeContext = hcpTypeContext;
            _ADOContext = ADOContext;
        }

        [HttpGet]
        [Route("GetMatsocAU")]
        public  async Task<List<string>> GetMatsocAU()
        {
            var result =await _ADOContext.GetDataTable("Usp_DT_Get_Matsoc", null);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item["MATSOC_CLIENT_NAME"]));
            }
            return ret;
        }

        [HttpGet]
        [Route("GetHCPType")]
        public async Task<List<string>> GetHCPType()
        {            

            var result =await _ADOContext.GetDataTable("Usp_DT_Get_HCP_Type", null);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item["HCP_TYPE"]));
            }

            return ret;
        }
    }
}
