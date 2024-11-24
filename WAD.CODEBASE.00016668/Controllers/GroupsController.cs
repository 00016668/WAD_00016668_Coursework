using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD.CODEBASE._00016668.Data;
using WAD.CODEBASE._00016668.Models;

namespace WAD.CODEBASE._00016668.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly ContactDbContext _context;

        public GroupsController(ContactDbContext context)
        {
            _context = context;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groups>>> GetGroupsDbSet()
        {
          if (_context.GroupsDbSet == null)
          {
              return NotFound();
          }
            return await _context.GroupsDbSet.ToListAsync();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Groups>> GetGroups(int id)
        {
          if (_context.GroupsDbSet == null)
          {
              return NotFound();
          }
            var groups = await _context.GroupsDbSet.FindAsync(id);

            if (groups == null)
            {
                return NotFound();
            }

            return groups;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroups(int id, Groups groups)
        {
            if (id != groups.GroupId)
            {
                return BadRequest();
            }

            _context.Entry(groups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupsExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Groups>> PostGroups(Groups groups)
        {
          if (_context.GroupsDbSet == null)
          {
              return Problem("Entity set 'ContactDbContext.GroupsDbSet'  is null.");
          }
            _context.GroupsDbSet.Add(groups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroups", new { id = groups.GroupId }, groups);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroups(int id)
        {
            if (_context.GroupsDbSet == null)
            {
                return NotFound();
            }
            var groups = await _context.GroupsDbSet.FindAsync(id);
            if (groups == null)
            {
                return NotFound();
            }

            _context.GroupsDbSet.Remove(groups);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupsExists(int id)
        {
            return (_context.GroupsDbSet?.Any(e => e.GroupId == id)).GetValueOrDefault();
        }
    }
}
