using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectService.Models;

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectContext _context;

        public ProjectController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectItem>>> GetProject()
        {
            return await _context.ProjectItem.ToListAsync();
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectItem>> GetProject(Guid id)
        {
            var projectItem = await _context.ProjectItem.FindAsync(id);

            if (projectItem == null)
            {
                return NotFound();
            }

            return projectItem;
        }

        // PUT: api/Project/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, ProjectItem projectItem)
        {
            if (id != projectItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectItemsExists(id))
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

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectItem>> CreateProject(ProjectItem projectItem)
        {
            _context.ProjectItem.Add(projectItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = projectItem.Id }, projectItem);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var projectItems = await _context.ProjectItem.FindAsync(id);
            if (projectItems == null)
            {
                return NotFound();
            }

            _context.ProjectItem.Remove(projectItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectItemsExists(Guid id)
        {
            return _context.ProjectItem.Any(e => e.Id == id);
        }
    }
}
