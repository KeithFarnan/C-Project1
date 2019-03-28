using Assignment7.Interfaces;
using System;
using System.Collections.Generic;

namespace Assignment7
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\fs2\18102879\Desktop/students.accdb;
            Persist Security Info = False; ";


            IClientCRUD clientCRUD = new ClientCRUD(connectionString);

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

            int numberOfClients = allClientsInDb.Count;
            Client lastClient = allClientsInDb[numberOfClients - 1];
            Console.WriteLine($"{lastClient.ClientName} was born on {lastClient.DateOfBirth}, and lives in {lastClient.Address}.");

            // changing the address
            lastClient.Address = "somewhere else";

            //updating the db with the new address
           clientCRUD.UpdateClient(lastClient);

            int clientId = lastClient.ClientId;


            lastClient = clientCRUD.GetClient(clientId);

            Console.WriteLine($"{lastClient.ClientName} was born on {lastClient.DateOfBirth}, and now lives in {lastClient.Address}.");


            // deleting the client from the db
            clientCRUD.DeleteClient(clientId);

            IContractCRUD contractCRUD = new ContractCRUD(connectionString);

            Contract keithContract = new Contract
            {
                ClientId = 1,
                StartDate = new DateTime(1900, 1, 01),
                EndDate = new DateTime(2019, 1, 01),
                Contract_Value = 9000,
                AmountOwed = 3000
               };

           contractCRUD.CreateContract(keithContract);
           List<Contract> allContractsInDb = contractCRUD.GetAllContracts();

            int numberOfContracts = allContractsInDb.Count;
           Contract lastContract = allContractsInDb[numberOfContracts - 1];
           Console.WriteLine($"{lastContract.ContractId} was started on {lastContract.StartDate} ends on {lastContract.EndDate}, and has a value of {lastContract.Contract_Value}.");

            lastContract.Contract_Value = 10000;

            contractCRUD.UpdateContract(lastContract);
            int contractId = lastContract.ContractId;



           lastClient = clientCRUD.GetClient(clientId);

           Console.WriteLine($"{lastContract.ContractId} was started on {lastContract.StartDate} ends on {lastContract.EndDate}, and has a value of {lastContract.Contract_Value}.");

           contractCRUD.DeleteContract(clientId);

           

            Console.ReadKey();
        }
    }
}