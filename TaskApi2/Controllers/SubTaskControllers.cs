using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Data;
using TaskManagementApi.Models;

namespace TaskManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTasksController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public SubTasksController(TaskDbContext context)
        {
            _context = context;
        }

        // GET: api/SubTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubTask>>> GetSubTasks()
        {
            return await _context.SubTasks.Include(st => st.Task).ToListAsync();
        }

        // GET: api/SubTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubTask>> GetSubTask(int id)
        {
            var subTask = await _context.SubTasks.Include(st => st.Task)
                .FirstOrDefaultAsync(st => st.SubTaskId == id);

            if (subTask == null)
            {
                return NotFound();
            }

            return subTask;
        }

        // POST: api/SubTasks
        [HttpPost]
        public async Task<ActionResult<SubTask>> PostSubTask(SubTask subTask)
        {
            _context.SubTasks.Add(subTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubTask), new { id = subTask.SubTaskId }, subTask);
        }

        // PUT: api/SubTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubTask(int id, SubTask subTask)
        {
            if (id != subTask.SubTaskId)
            {
                return BadRequest();
            }

            _context.Entry(subTask).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubTaskExists(id))
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

        // DELETE: api/SubTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubTask(int id)
        {
            var subTask = await _context.SubTasks.FindAsync(id);
            if (subTask == null)
            {
                return NotFound();
            }

            _context.SubTasks.Remove(subTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubTaskExists(int id)
        {
            return _context.SubTasks.Any(e => e.SubTaskId == id);
        }
    }
}
