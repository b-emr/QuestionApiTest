using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using erentitan.Models;
using erentitan.Services;

namespace erentitan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class classroom : ControllerBase
    {
        private readonly AppDbContext _context;

        public classroom(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/classroom
        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<Classroom>>> GetClassrooms()
        {
            return await _context.Classrooms.ToListAsync();
        }

        // GET: api/classroom/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Classroom>> GetClassroom(long id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound();
            }

            return classroom;
        }

        // PUT: api/classroom/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("put/{id}")]
        public async Task<IActionResult> PutClassroom(long id, Classroom classroom)
        {
            if (id != classroom.Id)
            {
                return BadRequest();
            }

            _context.Entry(classroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomExists(id))
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

        // POST: api/classroom
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("post")]
        public async Task<ActionResult<Classroom>> PostClassroom(Classroom classroom)
        {
            _context.Classrooms.Add(classroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassroom), new { id = classroom.Id }, classroom);
        }

        // DELETE: api/classroom/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteClassroom(long id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassroomExists(long id)
        {
            return _context.Classrooms.Any(e => e.Id == id);
        }

        [HttpGet("getclasses")]
        public List<ClassroomResponse> getClasses()
        {
            var s = GetClasses.getClass(_context);
            return s;
        }
    }
}
