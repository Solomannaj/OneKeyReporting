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
    public class TestSuitsController : ControllerBase
    {
        private readonly ITestSuitRepository _context;       

        public TestSuitsController(ITestSuitRepository context)
        {
            _context = context;         
        }

        // GET: api/TestSuits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestSuit_DTO>>> GetTestSuit()
        {
            var testSuits= await _context.GetAllAsync();
            List<TestSuit_DTO> lstDto = new List<TestSuit_DTO>();
            testSuits.ForEach(testSuit =>
            {
                TestSuit_DTO dto = new TestSuit_DTO()
                {
                    TestSuitId= testSuit.TestSuitId,
                    TestSuitName= testSuit.TestSuitName,
                    RunMode= testSuit.RunMode,
                    RunModeText= testSuit.RunMode == true? "Yes": "No"
                };

                lstDto.Add(dto);
            });

            return lstDto;
        }

        // GET: api/TestSuits/5
    
        [HttpGet("{id}")]
        public async Task<ActionResult<TestSuit>> GetTestSuit(int id)
        {
            var testSuit = await _context.FindByIdAsync(id);

            if (testSuit == null)
            {
                return NotFound();
            }

            return testSuit;
        }

        // PUT: api/TestSuits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestSuit(TestSuit testSuit)
        {

            try
            {
                await _context.UpdateAsync(testSuit);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestSuitExists(testSuit.TestSuitId))
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

        // POST: api/TestSuits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestSuit>> PostTestSuit(TestSuit testSuit)
        {
           await _context.AddAsync(testSuit);
          

            return CreatedAtAction("GetTestSuit", new { id = testSuit.TestSuitId }, testSuit);
        }

        // DELETE: api/TestSuits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestSuit(int id)
        {
            var testSuit = await _context.FindByIdAsync(id);
            if (testSuit == null)
            {
                return NotFound();
            }

           await _context.DeleteAsync(testSuit);
            

            return NoContent();
        }


        private bool TestSuitExists(int id)
        {
            return  _context.Exists(x => x.TestSuitId == id);
        }

    }
}
