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
    public class cwc : ControllerBase
    {
        private readonly AppDbContext _context;

        public cwc(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/cwc
        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<ClassroomsWithCourses>>> GetClassroomsWithCourses()
        {
            return await _context.ClassroomsWithCourses.ToListAsync();
        }

        // GET: api/cwc/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<ClassroomsWithCourses>> GetClassroomsWithCourses(long id)
        {
            var classroomsWithCourses = await _context.ClassroomsWithCourses.FindAsync(id);

            if (classroomsWithCourses == null)
            {
                return NotFound();
            }

            return classroomsWithCourses;
        }

        // PUT: api/cwc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("put/{id}")]
        public async Task<IActionResult> PutClassroomsWithCourses(long id, ClassroomsWithCourses classroomsWithCourses)
        {
            if (id != classroomsWithCourses.Id)
            {
                return BadRequest();
            }

            _context.Entry(classroomsWithCourses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomsWithCoursesExists(id))
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

        // POST: api/cwc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/post")]
        public async Task<ActionResult<ClassroomsWithCourses>> PostClassroomsWithCourses(ClassroomsWithCourses classroomsWithCourses)
        {
            _context.ClassroomsWithCourses.Add(classroomsWithCourses);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassroomsWithCourses), new { id = classroomsWithCourses.Id }, classroomsWithCourses);
        }

        // DELETE: api/cwc/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteClassroomsWithCourses(long id)
        {
            var classroomsWithCourses = await _context.ClassroomsWithCourses.FindAsync(id);
            if (classroomsWithCourses == null)
            {
                return NotFound();
            }

            _context.ClassroomsWithCourses.Remove(classroomsWithCourses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassroomsWithCoursesExists(long id)
        {
            return _context.ClassroomsWithCourses.Any(e => e.Id == id);
        }
    }
}
