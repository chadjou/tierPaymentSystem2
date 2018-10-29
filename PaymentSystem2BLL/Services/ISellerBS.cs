using System.Collections.Generic;
using System.Threading.Tasks;
using PaymentSystem2DAL.Entities;

namespace PaymentSystem2BLL.Services
{
    public interface ISellerBS
    {
        Task<int> AddSeller(Seller inputEt);
        Task DeleteSeller(int id);
        Task<Seller> GetSellerById(int id);
        Task<IList<Seller>> GetSellers();
        Task UpdateSeller(Seller inputEt);
    }
}