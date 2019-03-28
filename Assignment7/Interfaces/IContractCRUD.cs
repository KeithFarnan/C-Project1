using System.Collections.Generic;

namespace Assignment7.Interfaces
{
    public interface IContractCRUD
    {
        void CreateContract(Contract contract);
        Contract GetContract(int contractId);
        List<Contract> GetAllContracts();
        void UpdateContract(Contract contract);
        void DeleteContract(int contractId);
    }
}