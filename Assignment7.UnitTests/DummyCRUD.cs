using Assignment7.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.UnitTests
{

    public class DummyCRUD : IContractCRUD, IClientCRUD
    {

        public List<Contract> contracts = new List<Contract>();

        public List<Client> clients = new List<Client>();

        public void CreateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void CreateContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public void DeleteContract(int contractId)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAllClients()
        {
            return clients;
        }

        public List<Contract> GetAllContracts()
        {
            return contracts;
        }

        public Client GetClient(int clientId)
        {
            foreach(Client client in clients)
            {
                if (clientId == client.ClientId)
                {
                    return client;
                }
            }
            return null;
        }

        public Contract GetContract(int contractId)
        {
            foreach (Contract contract in contracts)
            {
                if (contractId == contract.ContractId)
                {
                    return contract;
                }
            }
            return null;
        }

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void UpdateContract(Contract contract)
        {
            throw new NotImplementedException();
        }
    }
}
