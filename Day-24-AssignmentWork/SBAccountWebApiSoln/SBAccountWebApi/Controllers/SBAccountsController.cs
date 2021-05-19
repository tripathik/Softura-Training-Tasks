using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBAccountWebApi.Models;

namespace SBAccountWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SBAccountsController : ControllerBase
    {
        private readonly SBAccountContext _context;

        public SBAccountsController(SBAccountContext context)
        {
            _context = context;
        }

        // GET: api/SBAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SBAccount>>> GetSBAccounts()
        {
            return await _context.SBAccounts.ToListAsync();
        }

        // GET: api/SBAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SBAccount>> GetSBAccount(int id)
        {
            var sBAccount = await _context.SBAccounts.FindAsync(id);

            if (sBAccount == null)
            {
                return NotFound();
            }

            return sBAccount;
        }

        // PUT: api/SBAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSBAccount(int id, SBAccount sBAccount)
        {
            if (id != sBAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(sBAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SBAccountExists(id))
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

        // POST: api/SBAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SBAccount>> PostSBAccount(SBAccount sBAccount)
        {
            _context.SBAccounts.Add(sBAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSBAccount", new { id = sBAccount.Id }, sBAccount);
        }

        // DELETE: api/SBAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSBAccount(int id)
        {
            var sBAccount = await _context.SBAccounts.FindAsync(id);
            if (sBAccount == null)
            {
                return NotFound();
            }

            _context.SBAccounts.Remove(sBAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SBAccountExists(int id)
        {
            return _context.SBAccounts.Any(e => e.Id == id);
        }
    }
}
