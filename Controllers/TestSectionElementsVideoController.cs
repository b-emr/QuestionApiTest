using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using erentitan.Models;
using erentitan.Services;

namespace erentitan.Controllers;


public class TestSectionElementsVideoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestSectionElementsVideoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestSectionElementsVideoController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("getQuestion/{id}")]
        public async Task<ActionResult<Classroom>> GetClassroom(long id)
        {
            var question = await _context.TestSectionElement.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }
    }
}