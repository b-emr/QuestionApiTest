using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using erentitan.Models;

namespace erentitan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentresponse : ControllerBase
    {
        private readonly AppDbContext _context;

        public studentresponse(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/studentresponse
        [HttpGet("/get")]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudentResponses()
        {
            return await _context.StudentResponses.ToListAsync();
        }

        // GET: api/studentresponse/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<StudentResponse>> GetStudentResponse(long id)
        {
            var studentResponse = await _context.StudentResponses.FindAsync(id);

            if (studentResponse == null)
            {
                return NotFound();
            }

            return studentResponse;
        }

        // PUT: api/studentresponse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("put/{id}")]
        public async Task<IActionResult> PutStudentResponse(long id, StudentResponse studentResponse)
        {
            if (id != studentResponse.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentResponseExists(id))
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

        // POST: api/studentresponse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("post")]
        public async Task<ActionResult<StudentResponse>> PostStudentResponse(StudentResponse studentResponse)
        {
            _context.StudentResponses.Add(studentResponse);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentResponse), new { id = studentResponse.Id }, studentResponse);
        }

        // DELETE: api/studentresponse/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteStudentResponse(long id)
        {
            var studentResponse = await _context.StudentResponses.FindAsync(id);
            if (studentResponse == null)
            {
                return NotFound();
            }

            _context.StudentResponses.Remove(studentResponse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentResponseExists(long id)
        {
            return _context.StudentResponses.Any(e => e.Id == id);
        }
    }
}
