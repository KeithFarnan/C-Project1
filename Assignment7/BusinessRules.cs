using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment7.Interfaces;

namespace Assignment7
{
    public class BusinessRules
    {
        private IClientCRUD _clientCRUD;
        private IContractCRUD _contractCRUD;

        public BusinessRules(IClientCRUD clientCRUD, IContractCRUD contractCRUD)
        {
            _clientCRUD = clientCRUD;
            _contractCRUD = contractCRUD;
        }

        public int CalculateAverageNumberOfContractsPerClient()
        {
            List<Contract> contracts = _contractCRUD.GetAllContracts();
            List<Client> clients = _clientCRUD.GetAllClients();
            int averageContractsPerClient = contracts.Count / clients.Count;
            return averageContractsPerClient;
        }

        public double CalculateAverageContractDuration()
        {
            List<Contract> contracts = _contractCRUD.GetAllContracts();
            double totalDuration = 0;
            foreach (var contract in contracts)
            {
                DateTime endDate = (contract.EndDate ?? DateTime.Now);

                TimeSpan contractDuration = endDate - (contract.StartDate);

                totalDuration += contractDuration.TotalDays;

            }
            double averageDuration = totalDuration / contracts.Count;
            return averageDuration;

        }

        public double CalculateEstimatedRemainingTimeOnContract(int contractId)
        {
            Contract selectedContract = _contractCRUD.GetContract(contractId);
            double remainingTimeOnContract = 0;
            DateTime endDate = (selectedContract.EndDate ?? DateTime.Now);
            TimeSpan contractDuration = endDate - (selectedContract.StartDate);
            remainingTimeOnContract = contractDuration.TotalDays;
            return remainingTimeOnContract;
        }

        public Dictionary<int, double> CalculateAverageContractValuePerClient()
        {
            List<Client> clients = _clientCRUD.GetAllClients();
            List<Contract> contracts = _contractCRUD.GetAllContracts();

            Dictionary<int, double> dictionary = new Dictionary<int, double>();
            
            foreach (Client client in clients)
            {
                double totalValue = 0;
                double counter = 0;
                foreach (Contract contract in contracts)
                {
                    if (contract.ClientId == client.ClientId)
                    {
                        totalValue += contract.Contract_Value;
                        counter ++;
                    }
                }
                double averageValue = totalValue / counter;
                dictionary.Add(client.ClientId, averageValue);
            }
            return dictionary;
        }

        public int CalculateNumberOfOpenContracts()
        {
            List<Contract> contracts = _contractCRUD.GetAllContracts();
            int totalNumber = 0;
            foreach (Contract contract in contracts)
            {
                if (contract.EndDate == null)
                {
                    totalNumber++;
                }
            }
            return totalNumber;
        }
    }
}