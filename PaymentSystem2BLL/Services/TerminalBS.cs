using System;
using System.Collections.Generic;
using System.Text;
using PaymentSystem2DAL.Repositories;
using PaymentSystem2DAL.Entities;
using System.Threading.Tasks;

namespace PaymentSystem2BLL.Services
{
     public class TerminalBS
    {
        private TerminalRepository _terminalRepository;

        public TerminalBS(TerminalRepository _terminalRepository)
        {
            if (_terminalRepository != null)
                this._terminalRepository = _terminalRepository;
        }

        public async Task<IList<PaymentSystem2DAL.Entities.Terminal>> GetTerminals()
        {
            return await this._terminalRepository.GetTerminals();
        }

        public async Task<PaymentSystem2DAL.Entities.Terminal> GetContactById(int id)
        {
            return await this._terminalRepository.GetTerminalById(id);
        }

        public async Task<int> AddContact(PaymentSystem2DAL.Entities.Terminal inputEt)
        {
            return await this._terminalRepository.AddTerminal(inputEt);
        }

        public async Task UpdateTerminal(PaymentSystem2DAL.Entities.Terminal inputEt)
        {
            await this._terminalRepository.UpdateTerminal(inputEt);
        }



        public async Task DeleteTerminal2(int id)
        {
            await this._terminalRepository.DeleteTerminal(id);
        }
    }
}
