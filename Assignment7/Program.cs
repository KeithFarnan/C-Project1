using Assignment7.Interfaces;
using System;
using System.Collections.Generic;

namespace Assignment7
{
    // Tester class for the application that creates a connection string to the database and modifies the database
    class Program
    {
        static void Main(string[] args)
        {
            // connection string to the database
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\fs2\18102879\Desktop/students.accdb;
            Persist Security Info = False; ";
            // creating an object of the clientCRUD class passing the connection string and allowing access to the methods in that class
            IClientCRUD clientCRUD = new ClientCRUD(connectionString);
            
            // creating a client object to add to the database 
            Client keith = new Client
            {
                ClientName = "Keith",
                Address = "Galway",
                DateOfBirth = new DateTime(1900, 1, 01)
            };
            // insert the new client into the db
            clientCRUD.CreateClient(keith);

            // read out all the clients from the db
            List<Client> allClientsInDb = clientCRUD.GetAllClients();
            // getting the number of clients in the db
            int numberOfClients = allClientsInDb.Count;
            // selecting the lastclient in the db
            Client lastClient = allClientsInDb[numberOfClients - 1];
            // reading the client details to the console
            Console.WriteLine($"{lastClient.ClientName} was born on {lastClient.DateOfBirth}, and lives in {lastClient.Address}.");

            // changing the address of the client
            lastClient.Address = "somewhere else";

            //updating the db with the new address
            clientCRUD.UpdateClient(lastClient);

            // reading all clients in the database again
            int clientId = lastClient.ClientId;
            // selecting the last client and reading their data to the console
            lastClient = clientCRUD.GetClient(clientId);
            Console.WriteLine($"{lastClient.ClientName} was born on {lastClient.DateOfBirth}, and now lives in {lastClient.Address}.");

            // deleting the client from the db
            clientCRUD.DeleteClient(clientId);


            // creating a contractCRUD object with the connection string
            IContractCRUD contractCRUD = new ContractCRUD(connectionString);

            // creating new Contract object
            Contract keithContract = new Contract
            {
                ClientId = 1,
                StartDate = new DateTime(1900, 1, 01),
                EndDate = new DateTime(2019, 1, 01),
                Contract_Value = 9000,
                AmountOwed = 3000
               };
            // adding the new Contract object to the db
            contractCRUD.CreateContract(keithContract);

            // retrieving all contract objects in the db and selecting the last and printing the values to the console
            List<Contract> allContractsInDb = contractCRUD.GetAllContracts();
            int numberOfContracts = allContractsInDb.Count;
            Contract lastContract = allContractsInDb[numberOfContracts - 1];
            Console.WriteLine($"{lastContract.ContractId} was started on {lastContract.StartDate} ends on {lastContract.EndDate}, and has a value of {lastContract.Contract_Value}.");

            // changing the value of the contract and updating the value in the db
            lastContract.Contract_Value = 10000;
            contractCRUD.UpdateContract(lastContract);

            // deleting the last contract in the db
            int contractId = lastContract.ContractId;
            lastContract = contractCRUD.GetContract(contractId);
            Console.WriteLine($"{lastContract.ContractId} was started on {lastContract.StartDate} ends on {lastContract.EndDate}, and has a value of {lastContract.Contract_Value}.");
            contractCRUD.DeleteContract(clientId);

            Console.ReadKey();
        }
    }
}