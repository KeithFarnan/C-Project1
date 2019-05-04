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
                totalDuration += Convert.ToDouble(contract.EndDate - contract.StartDate);
            }
            double averageDuration = totalDuration / contracts.Count;
            return averageDuration;

        }

        public double CalculateEstimatedRemainingTimeOnContract(int contractId)
        {
            Contract selectedContract = _contractCRUD.GetContract(contractId);
            double remainingTimeOnContract = 0;

            if (selectedContract.EndDate != null) {
                remainingTimeOnContract = Convert.ToDouble(selectedContract.EndDate - DateTime.Now);
            }
            else {
                remainingTimeOnContract = (selectedContract.Contract_Value / ( selectedContract.Contract_Value - selectedContract.AmountOwed )) * Convert.ToDouble(DateTime.Now - selectedContract.StartDate);
            }
            return remainingTimeOnContract;
        }

        public Dictionary<Client, double> CalculateAverageContractValuePerClient()
        {
            List<Client> clients = _clientCRUD.GetAllClients();
            List<Contract> contracts = _contractCRUD.GetAllContracts();
            Dictionary<Client, double> dictionary = new Dictionary<Client, double>();

            foreach (Client client in clients)
            {
                double totalValue = 0;
                foreach (Contract contract in contracts)
                {
                    if (contract.ClientId == client.ClientId)
                    totalValue += contract.Contract_Value;
                }
                double averageValue = totalValue / Convert.ToDouble(contracts.Count);
                dictionary.Add(client, averageValue);
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