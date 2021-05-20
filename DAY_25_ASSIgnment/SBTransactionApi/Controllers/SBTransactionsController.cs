using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SBTransactionApi.Models;



namespace SBTransactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SBTransactionsController : ControllerBase
    {
        private readonly SBTransactionContext _context;

        public SBTransactionsController(SBTransactionContext context)
        {
            _context = context;
        }

        

        // GET: api/SBTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SBTransaction>>> GetSBTransactions()
        {
            return await _context.SBTransactions.ToListAsync();
        }

        // GET: api/SBTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SBTransaction>> GetSBTransaction(int id)
        {
            var sBTransaction = await _context.SBTransactions.FindAsync(id);

            if (sBTransaction == null)
            {
                return NotFound();
            }

            return sBTransaction;
        }

        // PUT: api/SBTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSBTransaction(int id, SBTransaction sBTransaction)
        {
            if (id != sBTransaction.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(sBTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SBTransactionExists(id))
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

        // POST: api/SBTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SBTransaction>> PostSBTransaction(SBTransaction sBTransaction)
        {
            _context.SBTransactions.Add(sBTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSBTransaction", new { id = sBTransaction.TransactionId }, sBTransaction);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSBTransaction(int id)
        {
            var sBTransaction = await _context.SBTransactions.FindAsync(id);
            if (sBTransaction == null)
            {
                return NotFound();
            }
            _context.SBTransactions.Remove(sBTransaction);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool SBTransactionExists(int id)
        {
            return _context.SBTransactions.Any(e => e.TransactionId == id);
        }
        [HttpGet]
        [Route(("GetAccounts"))]
        public async Task<List<SBAccount>> GetAccount()
        {
            string Baseurl = "http://localhost:28109/";
            var TransactionInfo = new List<SBAccount>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
                HttpResponseMessage Res = await client.GetAsync("api/SBAccounts");
                if (Res.IsSuccessStatusCode)
                {
                    var TransactionResponse = Res.Content.ReadAsStringAsync().Result;
                    TransactionInfo = JsonConvert.DeserializeObject<List<SBAccount>>(TransactionResponse);
                    return TransactionInfo;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
