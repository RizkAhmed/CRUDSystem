using CRUDSystem.Models;

namespace CRUDSystem.Repository.AccountRepository
{
    public interface IAccountRepository
    {
        Account Find(string userName, string password);

    }
}
