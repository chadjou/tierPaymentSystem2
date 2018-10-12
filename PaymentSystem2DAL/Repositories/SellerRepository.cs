using PaymentSystem2DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem2DAL.Repositories
{
    class SellerRepository : GenericRepository<Entities.Seller>
    {

        private PaymentSystemContext storeDBContext;
        public SellerRepository(PaymentSystemContext context)
            : base(context)
        {
            storeDBContext = context;
        }

        public async Task<IList<Entities.Seller>> GetContacts()
        {
            return await this.GetAllAsync();
        }

        public async Task<Entities.Seller> GetContactById(int id)
        {
            return await this.GetByIdAsync(id);
        }
        /*
        public async Task<int> AddContact(Entities.Seller inputEt)
        {
            inputEt.ContactId = 0;
            inputEt.AuditTime = DateTime.Now;
            await this.InsertAsync(inputEt, true);
            //this.Commit();
            return inputEt.ContactId;
        }
        

        public async Task UpdateContact(Entities.Seller inputEt)
        {
            //Get entity to be updated
            Entities.Seller updEt = GetContactById(inputEt.ContactId).Result;

            if (!string.IsNullOrEmpty(inputEt.ContactName)) updEt.ContactName = inputEt.ContactName;
            if (!string.IsNullOrEmpty(inputEt.Phone)) updEt.Phone = inputEt.Phone;
            if (!string.IsNullOrEmpty(inputEt.Email)) updEt.Email = inputEt.Email;
            if (inputEt.PrimaryType != 0) updEt.PrimaryType = inputEt.PrimaryType;
            updEt.AuditTime = DateTime.Now;

            await this.UpdateAsync(updEt, true);
            //this.Commit();
        }
        */

        public async Task DeleteContact(int id)
        {
            await this.DeleteAsync(id, true);
            //this.Commit();
        }
    }
}
