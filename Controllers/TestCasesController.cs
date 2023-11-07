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
    public class TestCasesController : ControllerBase
    {
        private readonly ITestCaseRepository _context;

        public TestCasesController(ITestCaseRepository context)
        {
            _context = context;
        }

        // GET: api/TestCases
        [HttpGet]
        [Route("GetTestCasesBySuitId/{testSuitId}")]
        public async Task<ActionResult<IEnumerable<TestCase_DTO>>> GetTestCasesBySuitId(int testSuitId)
        {
            var testCases = await _context.FindByExpressionAsync(x => x.TestSuitId == testSuitId);
            List<TestCase_DTO> lstDto = new List<TestCase_DTO>();
            testCases.ForEach(testCase =>
            {
                TestCase_DTO dto = new TestCase_DTO()
                {
                    TestSuitId = testCase.TestSuitId,
                    TestCaseId = testCase.TestCaseId,
                    TestCaseName= testCase.TestCaseName,
                    RunMode = testCase.RunMode,
                    RunModeText = testCase.RunMode == true ? "Yes" : "No"
                };

                lstDto.Add(dto);
            });

            return lstDto;
        }

        // GET: api/TestCases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestCase>> GetTestCase(int id)
        {
            var testCase = await _context.FindByIdAsync(id);

            if (testCase == null)
            {
                return NotFound();
            }

            return testCase;
        }

        // PUT: api/TestCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestCase(TestCase testCase)
        {
          

            try
            {
                await _context.UpdateAsync(testCase);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestCaseExists(testCase.TestCaseId))
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

        // POST: api/TestCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestCase>> PostTestCase(TestCase testCase)
        {
           await _context.AddAsync(testCase);            

            return CreatedAtAction("GetTestCase", new { id = testCase.TestCaseId }, testCase);
        }

        // DELETE: api/TestCases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestCase(int id)
        {
            var testCase = await _context.FindByIdAsync(id);
            if (testCase == null)
            {
                return NotFound();
            }

            
            await _context.DeleteAsync(testCase);

            return NoContent();
        }

        private bool TestCaseExists(int id)
        {
            return _context.Exists(e => e.TestCaseId == id);
        }
    }
}
