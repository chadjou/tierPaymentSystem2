using System.Collections.Generic;
using System.Threading.Tasks;
using PaymentSystem2DAL.Entities;

namespace PaymentSystem2BLL.Services
{
    public interface ITerminalBS
    {
        Task<int> AddContact(Terminal inputEt);
        Task DeleteTerminal2(int id);
        Task<Terminal> GetContactById(int id);
        Task<IList<Terminal>> GetTerminals();
        Task UpdateTerminal(Terminal inputEt);
    }
}