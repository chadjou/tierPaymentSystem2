using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem2BLL.Services;
using PaymentSystem2DAL.DataContext;
using PaymentSystem2DAL.Entities;

namespace PaymentSystem2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private SellerBS bs;
        private readonly PaymentSystemContext _context;

        public SellersController(PaymentSystemContext context, SellerBS SellerBS)
        {
            bs = SellerBS;
            _context = context;
        }

        // GET: api/Sellers
        [HttpGet]
        public async Task<IEnumerable<Seller>> GetSellersAsync()
        {
            var rtnList = await bs.GetContacts();
            // return _context.Sellers;
            return rtnList;
        }

        [HttpPost]
        [Route("~/api/seller")]
        public async Task<int> Post_AddProduct([FromBody] Seller Seller)
        {

            var qq = await bs.AddContact(Seller);

            return qq;

            ////Generate a link to the new product and set the Location header in the response.
            ////For public HttpResponseMessage Post_AddProduct([FromBody] Models.Product mProduct)
            //var response = new HttpResponseMessage(HttpStatusCode.Created);
            //string uri = Url.Link("GetProductById", new { id = eProduct.ProductId });
            //response.Headers.Location = new Uri(uri);
            //return response;
        }


        // GET: api/Sellers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeller([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seller = await _context.Sellers.FindAsync(id);

            if (seller == null)
            {
                return NotFound();
            }

            return Ok(seller);
        }

        // PUT: api/Sellers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeller([FromRoute] int id, [FromBody] Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seller.SellerId)
            {
                return BadRequest();
            }

            _context.Entry(seller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(id))
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

        // POST: api/Sellers
        [HttpPost]
        public async Task<IActionResult> PostSeller([FromBody] Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeller", new { id = seller.SellerId }, seller);
        }

        // DELETE: api/Sellers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeller([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seller = await _context.Sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }

            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();

            return Ok(seller);
        }

        private bool SellerExists(int id)
        {
            return _context.Sellers.Any(e => e.SellerId == id);
        }
    }
}