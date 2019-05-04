using Assignment7.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    // Client CRUD class that implements the I Client CRUD interface
    public class ClientCRUD : IClientCRUD
    {
        // connection string to connect to the database
        private string _connectionString;

        // class constructor that takes the connection string as a parameter
        public ClientCRUD(string connectionString)
        {
            _connectionString = connectionString;
        }

        // creates client in the database from the values from the client object being passed in 
        public void CreateClient(Client client)
        {
            ExecuteSql($"INSERT INTO ContractClients (Client_Name, DOB, Address) VALUES ('{client.ClientName}', '{client.DateOfBirth}', '{client.Address}')");
        }

        // returns a list of all the clients in the database
        public List<Client> GetAllClients()
        {
            //this is the list we are going to return
            List<Client> clients = ExecuteReaderSql("SELECT Client_ID, Client_Name, DOB, Address FROM ContractClients");
            return clients;
        }

        // returns a Client object for the client with the Id passed in as a parameter
        public Client GetClient(int clientId)
        {
            //there should be at max one result here
            List<Client> clients = ExecuteReaderSql($"SELECT Client_ID, Client_Name, DOB, Address FROM ContractClients WHERE Client_ID = {clientId}");
            if (clients.Count == 1)
            {
                // return the client
                return clients[0];
            }
            // return null if no client with that id exists
            else return null;
        }

        // updates client taking the client object as the parameter
        public void UpdateClient(Client client)
        {
            ExecuteSql($"UPDATE ContractClients SET Client_Name = '{client.ClientName}', DOB = '{client.DateOfBirth}', Address = '{client.Address}' WHERE Client_ID = {client.ClientId}");
        }

        // deletes client from the database using the client id as the parameter to identify the client in the database
        public void DeleteClient(int clientId)
        {
            ExecuteSql($"DELETE FROM ContractClients WHERE Client_ID = {clientId}");
        }

        // private method in the class which takes the sql string opens the connection to the database executes the command and closes the connection
        private void ExecuteSql(string sql)
        {
            OleDbConnection connection = new OleDbConnection
            {
                ConnectionString = _connectionString
            };

            // opens the connection to the database
            connection.Open();
            // creating new command object to allow interaction with the database
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection,
                CommandText = sql
            };

            command.ExecuteNonQuery();
            // close the connection to the database
            connection.Close();
        }

        private List<Client> ExecuteReaderSql(string sql)
        {
            //this is the list we are going to return
            List<Client> clients = new List<Client>();

            OleDbConnection connection = new OleDbConnection
            {
                ConnectionString = _connectionString
            };

            // opens the connection to the database
            connection.Open();
            // creating new command object to allow interaction with the database
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection,
                CommandText = sql
            };
            // creating datareader object for the array
            OleDbDataReader reader = command.ExecuteReader();
            // while loop to traverse the entire table, creating a client object for each row, and adding it to the list
            while (reader.Read())
            {
                Client client = new Client();
                client.ClientId = Convert.ToInt32(reader[0].ToString());
                client.ClientName = reader[1].ToString();
                client.DateOfBirth = Convert.ToDateTime(reader[2].ToString());
                client.Address = reader[3].ToString();

                clients.Add(client);
            }
            // close the connection to the database
            connection.Close();
            // return clients list
            return clients;
        }
    }
}