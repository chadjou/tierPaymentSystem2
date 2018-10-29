using System.Collections.Generic;
using System.Threading.Tasks;
using PaymentSystem2DAL.Entities;

namespace PaymentSystem2DAL.Repositories
{
    public interface ISellerRepository
    {
        Task<int> AddContact(Seller inputEt);
        Task DeleteSeller2(int id);
        Task<IList<Seller>> GetContacts();
        Task<IList<Seller>> GetContactsWithIncludes();
        Task<Seller> GetSellerById(int id);
        Task UpdateSeller(Seller inputEt);
    }
}