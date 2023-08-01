using CRUDSystem.Data;
using CRUDSystem.Models;

namespace CRUDSystem.Repository.AccountRepository
{
    public class AccountRepositiry : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepositiry(AppDbContext context)
        {
            _context = context;
        }
        public Account Find(string userName, string password)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.UserName == userName && a.Password == password);
            return account;
        }
    }
}
