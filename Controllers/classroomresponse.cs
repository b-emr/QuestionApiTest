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
    public class classroomresponse : ControllerBase
    {
        private readonly AppDbContext _context;

        public classroomresponse(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/classroomresponse
        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<ClassroomResponse>>> GetClassroomResponses()
        {
            return await _context.ClassroomResponses.ToListAsync();
        }

        // GET: api/classroomresponse/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<ClassroomResponse>> GetClassroomResponse(long id)
        {
            var classroomResponse = await _context.ClassroomResponses.FindAsync(id);

            if (classroomResponse == null)
            {
                return NotFound();
            }

            return classroomResponse;
        }

        // PUT: api/classroomresponse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("put/{id}")]
        public async Task<IActionResult> PutClassroomResponse(long id, ClassroomResponse classroomResponse)
        {
            if (id != classroomResponse.Id)
            {
                return BadRequest();
            }

            _context.Entry(classroomResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomResponseExists(id))
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

        // POST: api/classroomresponse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("post")]
        public async Task<ActionResult<ClassroomResponse>> PostClassroomResponse(ClassroomResponse classroomResponse)
        {
            _context.ClassroomResponses.Add(classroomResponse);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassroomResponse), new { id = classroomResponse.Id }, classroomResponse);
        }

        // DELETE: api/classroomresponse/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteClassroomResponse(long id)
        {
            var classroomResponse = await _context.ClassroomResponses.FindAsync(id);
            if (classroomResponse == null)
            {
                return NotFound();
            }

            _context.ClassroomResponses.Remove(classroomResponse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassroomResponseExists(long id)
        {
            return _context.ClassroomResponses.Any(e => e.Id == id);
        }
    }
}
