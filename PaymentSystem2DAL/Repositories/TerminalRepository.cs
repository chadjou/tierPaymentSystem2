using PaymentSystem2DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem2DAL.Repositories
{
    public class TerminalRepository : GenericRepository<Entities.Terminal>, ITerminalRepository
    {
        private PaymentSystemContext PaymentSystemContext;
        public TerminalRepository(PaymentSystemContext context)
            : base(context)
        {
            PaymentSystemContext = context;
        }

        public async Task<IList<Entities.Terminal>> GetTerminals()
        {
            return await this.GetAllAsync();
        }

        public async Task<Entities.Terminal> GetTerminalById(int id)
        {
            return await this.GetByIdAsync(id);
        }

        public async Task<int> AddTerminal(Entities.Terminal inputEt)
        {
            await this.InsertAsync(inputEt, true);
            return inputEt.Id;
        }


        public async Task UpdateTerminal(Entities.Terminal inputEt)
        {
            //checking for errors
            Entities.Terminal updEt = GetTerminalById(inputEt.Id).Result;

            updEt = inputEt;


            await this.UpdateAsync(updEt, updEt.Id, true);
            //this.Commit();
        }


        public async Task DeleteTerminal(int id)
        {
            await this.DeleteAsync(id, true);
            //this.Commit();
        }
    }
}
