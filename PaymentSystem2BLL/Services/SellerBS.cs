using PaymentSystem2DAL.Repositories;
using PaymentSystem2DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem2BLL.Services
{
    public class SellerBS
    {
        private SellerRepository _sellerRepository;

        public SellerBS(SellerRepository _sellerRepository)
        {
            if (_sellerRepository != null)
                this._sellerRepository = _sellerRepository;
        }

        public async Task<IList<PaymentSystem2DAL.Entities.Seller>> GetContacts()
        {
            //return await this._sellerRepository.GetContacts();
            return await this._sellerRepository.GetContactsWithIncludes();
        }

        public async Task<PaymentSystem2DAL.Entities.Seller> GetContactById(int id)
        {
            return await this._sellerRepository.GetSellerById(id);
        }

        public async Task<int> AddContact(PaymentSystem2DAL.Entities.Seller inputEt)
        {
            return await this._sellerRepository.AddContact(inputEt);
        }
            
        public async Task UpdateSeller(PaymentSystem2DAL.Entities.Seller inputEt)
        {
            await this._sellerRepository.UpdateSeller(inputEt);
        }
        
        

        public async Task DeleteSeller2(int id)
        {
            await this._sellerRepository.DeleteSeller2(id);
        }
    }
}
