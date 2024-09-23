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
    public class swc : ControllerBase
    {
        private readonly AppDbContext _context;

        public swc(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/swc
        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<StudentsWithClassrooms>>> GetStudentsWithClassrooms()
        {
            return await _context.StudentsWithClassrooms.ToListAsync();
        }

        // GET: api/swc/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<StudentsWithClassrooms>> GetStudentsWithClassrooms(long id)
        {
            var studentsWithClassrooms = await _context.StudentsWithClassrooms.FindAsync(id);

            if (studentsWithClassrooms == null)
            {
                return NotFound();
            }

            return studentsWithClassrooms;
        }

        // PUT: api/swc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("put/{id}")]
        public async Task<IActionResult> PutStudentsWithClassrooms(long id, StudentsWithClassrooms studentsWithClassrooms)
        {
            if (id != studentsWithClassrooms.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentsWithClassrooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsWithClassroomsExists(id))
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

        // POST: api/swc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("post")]
        public async Task<ActionResult<StudentsWithClassrooms>> PostStudentsWithClassrooms(StudentsWithClassrooms studentsWithClassrooms)
        {
            _context.StudentsWithClassrooms.Add(studentsWithClassrooms);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentsWithClassrooms), new { id = studentsWithClassrooms.Id }, studentsWithClassrooms);
        }

        // DELETE: api/swc/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteStudentsWithClassrooms(long id)
        {
            var studentsWithClassrooms = await _context.StudentsWithClassrooms.FindAsync(id);
            if (studentsWithClassrooms == null)
            {
                return NotFound();
            }

            _context.StudentsWithClassrooms.Remove(studentsWithClassrooms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsWithClassroomsExists(long id)
        {
            return _context.StudentsWithClassrooms.Any(e => e.Id == id);
        }
    }
}
