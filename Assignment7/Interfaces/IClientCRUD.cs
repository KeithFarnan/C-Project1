using System.Collections.Generic;

namespace Assignment7.Interfaces
{
    public interface IClientCRUD
    {
        void CreateClient(Client client);
        Client GetClient(int clientId);
        List<Client> GetAllClients();
        void UpdateClient(Client client);
        void DeleteClient(int clientId);
    }
}