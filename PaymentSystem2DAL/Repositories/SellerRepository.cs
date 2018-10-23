using PaymentSystem2DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem2DAL.Repositories
{
    public class SellerRepository : GenericRepository<Entities.Seller>
    {

        private PaymentSystemContext storeDBContext;
        public SellerRepository(PaymentSystemContext context)
            : base(context)
        {
            storeDBContext = context;
        }

        public async Task<IList<Entities.Seller>> GetContacts()
        {

            var qq = await this.GetAllAsync();

            return await this.GetAllAsync();
        }

        public  Task<IList<Entities.Seller>> GetContactsWithIncludes()
        {

            //var qq =  this.GetAllWithIncludes("Terminals");

            return  this.GetAllWithIncludes("Terminals");
        }

     
        public async Task<Entities.Seller> GetSellerById(int id)
        {
            return await this.GetByIdAsync(id);
        }
        
        public async Task<int> AddContact(Entities.Seller inputEt)
        {
            await this.InsertAsync(inputEt, true);
            return inputEt.Id;
        }
        
        
        public async Task UpdateSeller(Entities.Seller inputEt)
        {
            //Get entity to be updated
            Entities.Seller updEt = GetSellerById(inputEt.Id).Result;

            updEt = inputEt;


            await this.UpdateAsync(updEt, true);
            //this.Commit();
        }
        

        public async Task DeleteSeller2(int id)
        {
            await this.DeleteAsync(id, true);
            //this.Commit();
        }
    }
}
