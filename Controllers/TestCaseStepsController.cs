using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataExtractionTool.DataLayer;
using DataExtractionTool.DataLayer.Models;
using DataExtractionTool.DataLayer.Repositories;

namespace DataExtractionTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCaseStepsController : ControllerBase
    {
        private readonly ITestCaseStepRepository _context;
        private readonly IActionKeyRepository _actionKeyContext;
        private readonly ILocatorTypeRepository _locatorTypeContext;
        private List<ActionKey> _actionKeys;
        List<LocatorType> _loacatorTypes;

        public TestCaseStepsController(ITestCaseStepRepository context, IActionKeyRepository actionKeyContext, ILocatorTypeRepository locatorTypeContext)
        {
            _context = context;
            _actionKeyContext = actionKeyContext;
            _locatorTypeContext = locatorTypeContext;
            _actionKeys = new List<ActionKey>();
            _loacatorTypes = new List<LocatorType>();
        }

        // GET: api/TestCaseSteps
        [HttpGet]
        [Route("GetTestCaseStepsByCaseId/{testCaseId}")]
        public async Task<ActionResult<IEnumerable<TestCaseStep_DTO>>> GetTestCaseStepsByCaseId(int testCaseId)
        {
            var testCaseSteps = await _context.FindByExpressionAsync(x => x.TestCaseId == testCaseId);
            List<TestCaseStep_DTO> lstDto = new List<TestCaseStep_DTO>();
            //if(_actionKeys.Count == 0)
            //{
            //    _actionKeys = await _actionKeyContext.GetAllAsync();
            //}

            //if (_loacatorTypes.Count == 0)
            //{
            //    _loacatorTypes = await _locatorTypeContext.GetAllAsync();
            //}

          

            testCaseSteps.OrderBy(x=>x.TestCaseStepSequence).ToList().ForEach(testCaseStep =>
            {
                TestCaseStep_DTO dto = new TestCaseStep_DTO()
                {
                    TestCaseId= testCaseStep.TestCaseId,
                    TestCaseStepId= testCaseStep.TestCaseStepId,
                    TestCaseStepDesc= testCaseStep.TestCaseStepDesc,
                    TestCaseStepSequence= testCaseStep.TestCaseStepSequence,
                    Locator= testCaseStep.Locator,
                    Varible= testCaseStep.Varible,
                    Data= testCaseStep.Data,
                    PerformanceTrack= testCaseStep.PerformanceTrack,
                    TestCaseStepResult= testCaseStep.TestCaseStepResult,
                    ExpMessage= testCaseStep.ExpMessage,
                    ActionKeyId= testCaseStep.ActionKeyId,
                    ActionKey ="", //_actionKeys.Where(x=>x.ActionKeyId== testCaseStep.ActionKeyId).FirstOrDefault().ActionKeyName,
                    LocatorTypeId= testCaseStep.LocatorTypeId,
                    LocatorType ="", //_loacatorTypes.Where(x=>x.LocatorTypeId==testCaseStep.LocatorTypeId).FirstOrDefault().LocatorTypeName,
                    RunMode= testCaseStep.RunMode,
                    ScreenShot= testCaseStep.ScreenShot,
                    RunModeText = testCaseStep.RunMode == true? "Yes":"No",
                    ScreenShotText= testCaseStep.ScreenShot == true ? "Yes" : "No",
                };

                lstDto.Add(dto);
            });

            return lstDto;
        }

        // GET: api/TestCaseSteps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestCaseStep>> GetTestCaseStep(int id)
        {
            var testCaseStep = await _context.FindByIdAsync(id);

            if (testCaseStep == null)
            {
                return NotFound();
            }

            return testCaseStep;
        }

        // PUT: api/TestCaseSteps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestCaseStep(TestCaseStep testCaseStep)
        {
           

            try
            {
                await _context.UpdateAsync(testCaseStep);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestCaseStepExists(testCaseStep.TestCaseStepId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TestCaseSteps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]      
        public async Task<ActionResult<TestCaseStep>> PostTestCaseStep(TestCaseStep testCaseStep)
        {
            
            await _context.AddAsync(testCaseStep);

            return CreatedAtAction("GetTestCaseStep", new { id = testCaseStep.TestCaseStepId }, testCaseStep);
        }

        // DELETE: api/TestCaseSteps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestCaseStep(int id)
        {
            var testCaseStep = await _context.FindByIdAsync(id);
            if (testCaseStep == null)
            {
                return NotFound();
            }

            await _context.DeleteAsync(testCaseStep);
            

            return NoContent();
        }

        [HttpGet]
        [Route("GetActionKeys")]
        public async Task<ActionResult<IEnumerable<ActionKey>>> GetActionKeys()
        {
            _actionKeys= await _actionKeyContext.GetAllAsync();

            return _actionKeys;


        }

        [HttpGet]
        [Route("GetLocatorTypes")]
        public async Task<ActionResult<IEnumerable<LocatorType>>> GetLocatorTypes()
        {
            _loacatorTypes= await _locatorTypeContext.GetAllAsync();
            return _loacatorTypes;

        }
     
        private bool TestCaseStepExists(int id)
        {
            return _context.Exists(e => e.TestCaseStepId == id);
        }
    }
}
