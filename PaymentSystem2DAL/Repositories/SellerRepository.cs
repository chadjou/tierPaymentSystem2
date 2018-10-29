using System.Collections.Generic;
using System.Threading.Tasks;
using PaymentSystem2DAL.DataContext;
using PaymentSystem2DAL.Entities;

namespace PaymentSystem2DAL.Repositories
{
    public class SellerRepository : GenericRepository<Seller>, ISellerRepository
    {
        private PaymentSystemContext paymentaymentSystemContext;

        public SellerRepository(PaymentSystemContext context)
            : base(context)
        {
            paymentaymentSystemContext = context;
        }

        public async Task<IList<Seller>> GetContacts()
        {
            return await GetAllAsync();
        }

        public Task<IList<Seller>> GetContactsWithIncludes()
        {
           

            return GetAllWithIncludes("Terminals");
        }


        public async Task<Seller> GetSellerById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<int> AddContact(Seller inputEt)
        {
            await InsertAsync(inputEt, true);
            return inputEt.Id;
        }


        public async Task UpdateSeller(Seller inputEt)
        {
            //Get entity to be updated
            var updEt = GetSellerById(inputEt.Id).Result;

            updEt = inputEt;


            await UpdateAsync(updEt, updEt.Id, true);
            //this.Commit();
        }


        public async Task DeleteSeller2(int id)
        {
            await DeleteAsync(id, true);
            //this.Commit();
        }
    }
}