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
    public class TestSuitesController : ControllerBase
    {
        private readonly TestPlanContext _context;

        public TestSuitesController(TestPlanContext context)
        {
            _context = context;
        }

        // GET: api/TestSuites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestSuite>>> GetTestSuite()
        {
            return await _context.TestSuite.ToListAsync();
        }

        // GET: api/TestSuites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestSuite>> GetTestSuite(int id)
        {
            var testSuite = await _context.TestSuite.FindAsync(id);

            if (testSuite == null)
            {
                return NotFound();
            }

            return testSuite;
        }

        // PUT: api/TestSuites/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestSuite(int id, TestSuite testSuite)
        {
            if (id != testSuite.Id)
            {
                return BadRequest();
            }

            _context.Entry(testSuite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestSuiteExists(id))
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

        // POST: api/TestSuites
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TestSuite>> PostTestSuite(TestSuite testSuite)
        {
            _context.TestSuite.Add(testSuite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestSuite", new { id = testSuite.Id }, testSuite);
        }

        // DELETE: api/TestSuites/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestSuite>> DeleteTestSuite(int id)
        {
            var testSuite = await _context.TestSuite.FindAsync(id);
            if (testSuite == null)
            {
                return NotFound();
            }

            _context.TestSuite.Remove(testSuite);
            await _context.SaveChangesAsync();

            return testSuite;
        }

        private bool TestSuiteExists(int id)
        {
            return _context.TestSuite.Any(e => e.Id == id);
        }
    }
}
