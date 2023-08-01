using CRUDSystem.Data;
using CRUDSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDSystem.Repository.ClientRepository
{
    public class ClientRepository:IClientRepository
    {
        private readonly AppDbContext _context;
        public ClientRepository( AppDbContext context)
        {
            _context = context;
        }

        public void Add(Client client)
        {
            _context.Clients.Add(client);
        }

        public void Delete(int? id)
        {
            var client = GetById(id);
            _context.Clients.Remove(client);
        }

        public void Edit(Client client)
        {
            _context.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<Client> GetAll()
        {
            return _context.Clients
                .Include(c=>c.Governorate)
                .Include(c=>c.Center)
                .Include(c=>c.Village).ToList();
        }

        public Client GetById(int? id)
        {
            return _context.Clients
                .Include(c => c.Governorate)
                .Include(c => c.Center)
                .Include(c => c.Village).FirstOrDefault(c=>c.ClientID == id)!;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
