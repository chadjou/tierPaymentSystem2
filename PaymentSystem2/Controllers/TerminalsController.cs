using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem2BLL.Services;
using PaymentSystem2DAL.DataContext;
using PaymentSystem2DAL.Entities;

namespace PaymentSystem2.Controllers
{
    public class TerminalsController : ControllerBase
    {

        private TerminalBS bs;
        private readonly PaymentSystemContext _context;

        public TerminalsController(PaymentSystemContext context, TerminalBS TerminalBS)
        {
            bs = TerminalBS;
            _context = context;
        }

        // GET: api/Terminals
        [HttpGet]
        public async Task<IEnumerable<Terminal>> GetTerminalsAsync()
        {
            var rtnList = await bs.GetContacts();
            return rtnList;
        }

        [HttpPost]
        [Route("~/api/terminal")]
        public async Task<int> Post_AddProduct([FromBody] Terminal Terminal)
        {

            var qq = await bs.AddContact(Terminal);

            return qq;

            ////Generate a link to the new product and set the Location header in the response.
            ////For public HttpResponseMessage Post_AddProduct([FromBody] Models.Product mProduct)
            //var response = new HttpResponseMessage(HttpStatusCode.Created);
            //string uri = Url.Link("GetProductById", new { id = eProduct.ProductId });
            //response.Headers.Location = new Uri(uri);
            //return response;
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
        public async Task<IActionResult> PutTerminal([FromRoute] int id, [FromBody] Terminal terminal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != terminal.Id)
            {
                return BadRequest();
            }

            _context.Entry(terminal).State = EntityState.Modified;

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
        public async Task<IActionResult> PostTerminal([FromBody] Terminal terminal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Terminals.Add(terminal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTerminal", new { id = terminal.Id }, terminal);
        }

        // DELETE: api/Terminals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerminal([FromRoute] int id)
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

            return Ok(terminal);
        }

        private bool TerminalExists(int id)
        {
            return _context.Terminals.Any(e => e.Id == id);
        }

        [Route("~/api/deleteterminal2")]
        public async Task DeleteTerminal2([FromBody] int id)
        {

            await bs.DeleteTerminal2(id);
        }

        [Route("~/api/updateterminal2")]
        public async Task UpdateTerminal([FromBody] Terminal terminal)
        {

            await bs.UpdateTerminal(terminal);
        }
    }
}
