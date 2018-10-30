using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem2BLL.Services;
using PaymentSystem2DAL.DataContext;
using PaymentSystem2DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using PaymentSystem2.ViewModels;

namespace PaymentSystem2.Controllers
{
    public class TerminalsController : ControllerBase
    {
        private ITerminalBS _bs;
        private readonly PaymentSystemContext _context;

        public TerminalsController(PaymentSystemContext context, ITerminalBS terminalBs)
        {
            _bs = terminalBs;
            _context = context;
        }

        // GET: api/Terminals
        [HttpGet]
        public async Task<IEnumerable<TerminalVm>> GetTerminalsAsync()
        {

            var terminalList = await _bs.GetTerminals();
            var sellerVmList = terminalList.Adapt<IEnumerable<TerminalVm>>();
            
            return sellerVmList;
        }

        [HttpPost]
        [Route("~/api/terminal2")]
        public async Task<int> Post_AddProduct([FromBody] Terminal terminalVm)
        {
            return await _bs.AddContact(terminalVm.Adapt<Terminal>());
        }

        // GET: api/Terminals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTerminal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var terminal = await _context.Terminals.FindAsync(id);

            if (terminal == null)
            {
                return NotFound();
            }

            return Ok(terminal);
        }

        // PUT: api/Terminals/5
        [HttpPut("{id}")]
        [Route("~/api/terminal")]
        public async Task<IActionResult> PutTerminal([FromRoute] int id, [FromBody] TerminalVm terminalVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != terminalVm.Id)
            {
                return BadRequest();
            }

            _context.Entry(terminalVm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerminalExists(id))
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

        // POST: api/Terminal
        [HttpPost]
        [Route("~/api/terminal")]
        public async Task<IActionResult> PostTerminal([FromBody] TerminalVm terminalVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Terminals.Add(terminalVm.Adapt<Terminal>());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTerminal", new { id = terminalVm.Id }, terminalVm);
        }

        // DELETE: api/Terminals/5
        [Route("~/api/terminal")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTerminal([FromBody] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var terminal = await _context.Terminals.FindAsync(id);
            if (terminal == null)
            {
                return NotFound();
            }

            _context.Terminals.Remove(terminal);
            await _context.SaveChangesAsync();

            return Ok(terminal.Adapt<TerminalVm>());
        }

        private bool TerminalExists(int id)
        {
            return _context.Terminals.Any(e => e.Id == id);
        }

        [Route("~/api/terminal")]
        [HttpPut]
        public async Task UpdateTerminal([FromBody] Terminal terminal)
        {
            await _bs.UpdateTerminal(terminal);
        }
    }
}