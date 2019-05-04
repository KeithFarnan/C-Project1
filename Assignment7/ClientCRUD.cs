using Assignment7.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    public class ClientCRUD : IClientCRUD
    {
        private string _connectionString;

        public ClientCRUD(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateClient(Client client)
        {
            ExecuteSql($"INSERT INTO ContractClients (Client_Name, DOB, Address) VALUES ('{client.ClientName}', '{client.DateOfBirth}', '{client.Address}')");
        }

        public List<Client> GetAllClients()
        {
            //this is the list we are going to return
            List<Client> clients = ExecuteReaderSql("SELECT Client_ID, Client_Name, DOB, Address FROM ContractClients");
            return clients;
        }

        public Client GetClient(int clientId)
        {
            //there should be at max one result here!
            List<Client> clients = ExecuteReaderSql($"SELECT Client_ID, Client_Name, DOB, Address FROM ContractClients WHERE Client_ID = {clientId}");
            if (clients.Count == 1)
            {
                return clients[0];
            }
            else return null;
        }

        public void UpdateClient(Client client)
        {
            ExecuteSql($"UPDATE ContractClients SET Client_Name = '{client.ClientName}', DOB = '{client.DateOfBirth}', Address = '{client.Address}' WHERE Client_ID = {client.ClientId}");
        }

        public void DeleteClient(int clientId)
        {
            ExecuteSql($"DELETE FROM ContractClients WHERE Client_ID = {clientId}");
        }

        private void ExecuteSql(string sql)
        {
            OleDbConnection connection = new OleDbConnection
            {
                ConnectionString = _connectionString
            };

            connection.Open();

            OleDbCommand command = new OleDbCommand
            {
                Connection = connection,
                CommandText = sql
            };

            command.ExecuteNonQuery();

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

            return clients;
        }
    }
}