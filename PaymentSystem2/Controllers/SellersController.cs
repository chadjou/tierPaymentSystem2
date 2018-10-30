using Mapster;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaymentSystem2.ViewModels;
using PaymentSystem2BLL.Services;
using PaymentSystem2DAL.DataContext;
using PaymentSystem2DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly PaymentSystemContext _context;
        private readonly ISellerBS _bs;

        public SellersController(PaymentSystemContext context, ISellerBS sellerBs)
        {
            _bs = sellerBs;
            _context = context;
        }

        [HttpGet]
        [Route("~/api/seller")]
        public async Task<string> GetSellersAsync()
        {
            var sellerList = await _bs.GetSellers();

            var sellerVmList = sellerList.Adapt<IEnumerable<SellerVm>>();

            var serializerSettings = new JsonSerializerSettings
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects };

            var json = JsonConvert.SerializeObject(sellerVmList, Formatting.Indented, serializerSettings);

            return json;
        }

        [HttpPost]
        [Route("~/api/seller")]
        public async Task<int> Post_AddProduct([FromBody] Seller sellerReq)
        {
            return await _bs.AddSeller(sellerReq.Adapt<Seller>());
        }

        private bool SellerExists(int id)
        {
            return _context.Sellers.Any(e => e.Id == id);
        }

        [Route("~/api/seller")]
        [HttpDelete]
        public async Task DeleteSeller([FromBody] int id)
        {
            await _bs.DeleteSeller(id);
        }

        [Route("~/api/seller")]
        [HttpPut]
        public async Task UpdateSeller([FromBody] SellerVm sellerReq)
        {
            var seller = sellerReq.Adapt<Seller>();
            await _bs.UpdateSeller(seller);
        }
    }
}