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
        //private readonly IMatsocResultRepository _matsocContext;
        //private readonly IHCPTypeResultRepository _hcpTypeContext;
        private readonly IADORepository _ADOContext;
        public FiltersController( IADORepository ADOContext)//IMatsocResultRepository matsocContext, IHCPTypeResultRepository hcpTypeContext,
        {
            //_matsocContext = matsocContext;
            //_hcpTypeContext = hcpTypeContext;
            _ADOContext = ADOContext;
        }

        [HttpGet]
        [Route("GetMatsoc")]
        public  async Task<List<string>> GetMatsoc(string country)
        {
            var result =await _ADOContext.GetDataTable("Usp_DT_Get_Matsoc", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }
            return ret;
        }

        [HttpGet]
        [Route("GetHCPType")]
        public async Task<List<string>> GetHCPType(string country)
        {            

            var result =await _ADOContext.GetDataTable("Usp_DT_Get_HCP_Type", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }

            return ret;
        }

        [HttpGet]
        [Route("GetHCPACTStatus")]
        public async Task<List<string>> GetHCPACTStatus(string country)
        {

            var result = await _ADOContext.GetDataTable("Usp_DT_Get_HCP_ACT_Status", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }

            return ret;
        }

        [HttpGet]
        [Route("GetHCPSpecialty")]
        public async Task<List<string>> GetHCPSpecialty(string country)
        {

            var result = await _ADOContext.GetDataTable("Usp_DT_Get_HCP_Specialty", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }

            return ret;
        }


        [HttpGet]
        [Route("GetHCPRole")]
        public async Task<List<string>> GetHCPRole(string country)
        {

            var result = await _ADOContext.GetDataTable("Usp_DT_Get_HCP_Role", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }

            return ret;
        }

        [HttpGet]
        [Route("GetHCPTendency")]
        public async Task<List<string>> GetHCPTendency(string country)
        {

            var result = await _ADOContext.GetDataTable("Usp_DT_Get_HCP_Tendency", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }

            return ret;
        }

        [HttpGet]
        [Route("GetHCOState")]
        public async Task<List<string>> GetHCOState(string country)
        {

            var result = await _ADOContext.GetDataTable("Usp_DT_Get_HCO_State", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }

            return ret;
        }


        [HttpGet]
        [Route("GetHCOSpecialty")]
        public async Task<List<string>> GetHCOSpecialty(string country)
        {

            var result = await _ADOContext.GetDataTable("Usp_DT_Get_HCO_Specialty", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }

            return ret;
        }

        [HttpGet]
        [Route("GetHCOType")]
        public async Task<List<string>> GetHCOType(string country)
        {

            var result = await _ADOContext.GetDataTable("Usp_DT_Get_HCO_Type", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }

            return ret;
        }

        [HttpGet]
        [Route("GetHCOSector")]
        public async Task<List<string>> GetHCOSector(string country)
        {

            var result = await _ADOContext.GetDataTable("Usp_DT_Get_HCO_Sector", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }

            return ret;
        }

        [HttpGet]
        [Route("GetHCOMetroCountry")]
        public async Task<List<string>> GetHCOMetroCountry(string country)
        {

            var result = await _ADOContext.GetDataTable("Usp_DT_Get_HCO_Metro_Country", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }

            return ret;
        }

        [HttpGet]
        [Route("GetHCPPRIMARYAFFILIATION")]
        public async Task<List<string>> GetHCPPRIMARYAFFILIATION(string country)
        {

            var result = await _ADOContext.GetDataTable("Usp_DT_Get_HCP_PRIMARY_AFFILIATION", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }

            return ret;
        }

        [HttpGet]
        [Route("GetHCPINDStatus")]
        public async Task<List<string>> GetHCPINDStatus(string country)
        {

            var result = await _ADOContext.GetDataTable("Usp_DT_Get_HCP_IND_Status", null, country);
            List<string> ret = new List<string>();
            foreach (DataRow item in result.Rows)
            {
                ret.Add(Convert.ToString(item[0]));
            }

            return ret;
        }


    }
}
