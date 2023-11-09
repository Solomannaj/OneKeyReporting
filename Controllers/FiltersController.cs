using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataExtractionTool.DataLayer.Repositories;
using DataExtractionTool.DataLayer.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataExtractionTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        private readonly IMatsocResultRepository _matsocContext;
        private readonly IHCPTypeResultRepository _hcpTypeContext;
        public FiltersController(IMatsocResultRepository matsocContext, IHCPTypeResultRepository hcpTypeContext)
        {
            _matsocContext = matsocContext;
            _hcpTypeContext = hcpTypeContext;
        }

        [HttpGet]
        [Route("GetMatsocAU")]
        public async Task<List<MatsocResult>> GetMatsocAU()
        {
            //SqlParameter[] inputParameter = {
            //    new SqlParameter("@userid", userid)
            //};
            return await _matsocContext.GetDataProc("EXEC Usp_DT_Get_Matsoc",null);
        }

        [HttpGet]
        [Route("GetHCPType")]
        public async Task<List<HCPTypeResult>> GetHCPType()
        {
            //SqlParameter[] inputParameter = {
            //    new SqlParameter("@userid", userid)
            //};
            return await _hcpTypeContext.GetDataProc("EXEC Usp_DT_Get_HCP_Type", null);
        }
    }
}
