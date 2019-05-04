using System;
using System.Collections.Generic;
using Assignment7.Interfaces;

namespace Assignment7.UnitTests
{
    // class that has the dummy CRUD data and implements the IContractCRUD and IClientCRUD interfaces
    public class DummyCRUD : IContractCRUD, IClientCRUD
    {
        // creating lists to hold the contract and client objects
        public List<Contract> contracts = new List<Contract>();
        public List<Client> clients = new List<Client>();

        // 
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

        // return clients list to calling method
        public List<Client> GetAllClients()
        {
            return clients;
        }

        // return list of contracts to calling method
        public List<Contract> GetAllContracts()
        {
            return contracts;
        }

        // returns client object that matches the id passed in as parameter
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

        // returns contract object that matches the id passed in as parameter
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
