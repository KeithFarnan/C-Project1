using Assignment7.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    // Contract CRUD that implements contract Crud interface and implements those methods
    public class ContractCRUD : IContractCRUD
    {
        private string _connectionString;

        public ContractCRUD(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateContract(Contract contract)
        {
            ExecuteSql($"INSERT INTO Contracts (Client_ID, Start_Date, End_Date, Contract_Value, AmountOwed) VALUES ('{contract.ClientId}', '{contract.StartDate}', '{contract.EndDate}', '{contract.Contract_Value}', '{contract.AmountOwed}')");
        }

        public List<Contract> GetAllContracts()
        {

            List<Contract> contracts = ExecuteReaderSql("SELECT Contract_ID, Client_ID, Start_Date, End_Date, Contract_Value, AmountOwed FROM Contracts");

            return contracts;
        }
            

        public Contract GetContract(int contractId)
        {
            List<Contract> contracts = ExecuteReaderSql($"SELECT Contract_ID, Client_ID, Start_Date, End_Date, Contract_Value, AmountOwed FROM Contracts WHERE Contract_ID = {contractId}");
            if (contracts.Count == 1)
            {
                return contracts[0];
            }
            else return null;
        }

        public void UpdateContract(Contract contract)
        {
            ExecuteSql($"UPDATE Contracts SET Client_ID = {contract.ClientId}, Start_Date = '{contract.StartDate}', End_Date = '{contract.EndDate}', Contract_Value = {contract.Contract_Value}, AmountOwed = {contract.AmountOwed} WHERE Client_ID = {contract.ClientId}");
        }
        public void DeleteContract(int contractId)
        {
            ExecuteSql($"DELETE FROM Contracts WHERE Contract_ID = {contractId}");
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

        private List<Contract> ExecuteReaderSql(string sql)
        {
        List<Contract> contracts = new List<Contract>();

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
                Contract contract = new Contract();
                contract.ContractId = Convert.ToInt32(reader[0].ToString());
                contract.ClientId = Convert.ToInt32(reader[1].ToString());
                contract.StartDate = Convert.ToDateTime(reader[2].ToString());
                contract.EndDate = Convert.ToDateTime(reader[3].ToString());
                contract.Contract_Value = Convert.ToInt32(reader[4].ToString());
                contract.AmountOwed = Convert.ToInt32(reader[5].ToString());
                contracts.Add(contract);
            }
            // close the connection to the database
            connection.Close();

            return contracts;
        }
    }
}