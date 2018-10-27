using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaymentSystem2BLL.Services;
using PaymentSystem2DAL.DataContext;
using PaymentSystem2DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly PaymentSystemContext _context;
        private readonly SellerBS bs;

        public SellersController(PaymentSystemContext context, SellerBS sellerBs)
        {
            bs = sellerBs;
            _context = context;
        }

        [HttpGet]
        [Route("~/api/seller")]
        public async Task<string> GetSellersAsync()
        {
            var rtnList = await bs.GetSellers();

            var serializerSettings = new JsonSerializerSettings
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects };

            var json = JsonConvert.SerializeObject(rtnList, Formatting.Indented, serializerSettings);

            return json;
        }

        [HttpPost]
        [Route("~/api/seller")]
        public async Task<int> Post_AddProduct([FromBody] Seller Seller)
        {
            return await bs.AddSeller(Seller);

            ////Generate a link to the new product and set the Location header in the response.
            ////For public HttpResponseMessage Post_AddProduct([FromBody] Models.Product mProduct)
            //var response = new HttpResponseMessage(HttpStatusCode.Created);
            //string uri = Url.Link("GetProductById", new { id = eProduct.ProductId });
            //response.Headers.Location = new Uri(uri);
            //return response;
        }

        private bool SellerExists(int id)
        {
            return _context.Sellers.Any(e => e.Id == id);
        }

        [Route("~/api/seller")]
        [HttpDelete]
        public async Task DeleteSeller([FromBody] int id)
        {
            await bs.DeleteSeller(id);
        }

        [Route("~/api/seller")]
        [HttpPut]
        public async Task UpdateSeller([FromBody] Seller seller)
        {
            await bs.UpdateSeller(seller);
        }
    }
}