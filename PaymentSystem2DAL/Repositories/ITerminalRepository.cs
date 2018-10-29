using System.Collections.Generic;
using System.Threading.Tasks;
using PaymentSystem2DAL.Entities;

namespace PaymentSystem2DAL.Repositories
{
    public interface ITerminalRepository
    {
        Task<int> AddTerminal(Terminal inputEt);
        Task DeleteTerminal(int id);
        Task<Terminal> GetTerminalById(int id);
        Task<IList<Terminal>> GetTerminals();
        Task UpdateTerminal(Terminal inputEt);
    }
}