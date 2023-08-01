using CRUDSystem.Models;

namespace CRUDSystem.Repository.ClientRepository
{
    public interface IClientRepository
    {
        List<Client> GetAll();
        Client GetById(int? id);
        void Add(Client client);
        void Edit(Client client);
        void Delete(int? id);
        void Save();
    }
    
}
