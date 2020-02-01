using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestPlaner.Data;
using TestPlaner.models;

namespace TestPlaner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCasesController : ControllerBase
    {
        private readonly TestPlanContext _context;

        public TestCasesController(TestPlanContext context)
        {
            _context = context;
        }

        // GET: api/TestCases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestCase>>> GetTestCase()
        {
            return await _context.TestCase.ToListAsync();
        }

        // GET: api/TestCases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestCase>> GetTestCase(int id)
        {
            var testCase = await _context.TestCase.FindAsync(id);

            if (testCase == null)
            {
                return NotFound();
            }

            return testCase;
        }

        // PUT: api/TestCases/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestCase(int id, TestCase testCase)
        {
            if (id != testCase.Id)
            {
                return BadRequest();
            }

            _context.Entry(testCase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestCaseExists(id))
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TestCase>> PostTestCase(TestCase testCase)
        {
            _context.TestCase.Add(testCase);
            var suite=_context.TestSuite.FirstOrDefault(s => s.Id == testCase.SuiteId);
            if (suite==null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestCase", new { id = testCase.Id }, testCase);
        }

        // DELETE: api/TestCases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestCase>> DeleteTestCase(int id)
        {
            var testCase = await _context.TestCase.FindAsync(id);
            if (testCase == null)
            {
                return NotFound();
            }

            _context.TestCase.Remove(testCase);
            await _context.SaveChangesAsync();

            return testCase;
        }

        private bool TestCaseExists(int id)
        {
            return _context.TestCase.Any(e => e.Id == id);
        }
    }
}
