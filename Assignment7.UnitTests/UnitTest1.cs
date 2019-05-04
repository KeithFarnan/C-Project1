using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace Assignment7.UnitTests
{
    [TestClass]
    public class BusinessRulesTests
    {
        private DummyCRUD GetDummyClientCRUD()
        {
            DummyCRUD crud = new DummyCRUD();
            Client test = new Client()
            {
                ClientId = 1,
                ClientName = "Test",
                Address = "TestLand",
                DateOfBirth = new DateTime(1969, 6, 09)
            };
            Client test2 = new Client()
            {
                ClientId = 2,
                ClientName = "Test2",
                Address = "TestLand",
                DateOfBirth = new DateTime(1969, 6, 09)
            };
            Client test3 = new Client()
            {
                ClientId = 3,
                ClientName = "Test3",
                Address = "TestLand",
                DateOfBirth = new DateTime(1969, 6, 09)
            };
            Client test4 = new Client()
            {
                ClientId = 4,
                ClientName = "Test4",
                Address = "TestLand",
                DateOfBirth = new DateTime(1969, 6, 09)
            };
            crud.clients.Add(test);
            crud.clients.Add(test2);
            crud.clients.Add(test3);
            crud.clients.Add(test4);
            return crud;

        }
        private DummyCRUD GetDummyContractCRUD()
        {
            DummyCRUD crud = new DummyCRUD();
            Contract contract1 = new Contract
            {
                ClientId = 1,
                StartDate = new DateTime(1969, 6, 09),
                EndDate = new DateTime(2019, 6, 09),
                Contract_Value = 100,
                AmountOwed = 90
            };
            Contract contract2 = new Contract
            {
                ClientId = 1,
                StartDate = new DateTime(1969, 6, 09),
                EndDate = new DateTime(2019, 6, 09),
                Contract_Value = 100,
                AmountOwed = 90
            };
            Contract contract3 = new Contract
            {
                ClientId = 2,
                StartDate = new DateTime(1969, 6, 09),
                EndDate = new DateTime(2019, 6, 09),
                Contract_Value = 100,
                AmountOwed = 90
            };
            Contract contract4 = new Contract
            {
                ClientId = 3,
                StartDate = new DateTime(1969, 6, 09),
                EndDate = new DateTime(2019, 6, 09),
                Contract_Value = 100,
                AmountOwed = 90
            };
            Contract contract5 = new Contract
            {
                ClientId = 4,
                StartDate = new DateTime(1969, 6, 09),
                EndDate = new DateTime(2019, 6, 09),
                Contract_Value = 100,
                AmountOwed = 90
            };
            crud.contracts.Add(contract1);
            crud.contracts.Add(contract2);
            crud.contracts.Add(contract3);
            crud.contracts.Add(contract4);
            crud.contracts.Add(contract5);
            return crud;
        }

        [TestMethod]
        public void CalculateAverageNumberOfContractsPerClient_ContractsAreOpen_ReturnsTrue()
        {
            DummyCRUD dummyClientCrud = GetDummyClientCRUD();
            DummyCRUD dummyContractCrud = GetDummyContractCRUD();
            BusinessRules businessRulesObject = new BusinessRules(dummyClientCrud, dummyContractCrud);

            var actualResult = businessRulesObject.CalculateAverageNumberOfContractsPerClient();
            var expectedResult = 1;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CalculateAverageContractDuration_ContractsAreOpen_ReturnsTrue()
        {
            DummyCRUD dummyClientCrud = GetDummyClientCRUD();
            DummyCRUD dummyContractCrud = GetDummyContractCRUD();
            BusinessRules businessRulesObject = new BusinessRules(dummyClientCrud, dummyContractCrud);
            double actualResult = businessRulesObject.CalculateAverageContractDuration();
            double expectedResult = 18262;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void CalculateEstimatedRemainingTimeOnContract_ContractsAreOpen_ReturnsTrue()
        {
            DummyCRUD dummyClientCrud = GetDummyClientCRUD();
            DummyCRUD dummyContractCrud = GetDummyContractCRUD();
            BusinessRules businessRulesObject = new BusinessRules(dummyClientCrud, dummyContractCrud);

            var actualResult = businessRulesObject.CalculateEstimatedRemainingTimeOnContract(dummyContractCrud.contracts[0].ContractId);
            var expectedResult = 18262;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CalculateAverageContractValuePerClient_ContractsAreOpen_ReturnsTrue()
        {
            DummyCRUD dummyClientCrud = GetDummyClientCRUD();
            DummyCRUD dummyContractCrud = GetDummyContractCRUD();
            BusinessRules businessRulesObject = new BusinessRules(dummyClientCrud, dummyContractCrud);
            var actualResult = businessRulesObject.CalculateAverageContractValuePerClient();

            double clientOneExpectedResult = 100;
            double clienttwoExpectedResult = 100;
            double clientthreeExpectedResult = 100;
            double clientfourexpectedResult = 100;

            double clientOneActualResult = actualResult[1];
            double clienttwoActualResult = actualResult[2];
            double clientthreeActualResult = actualResult[3];
            double clientfourActualResult = actualResult[4];
            
            Assert.AreEqual(clientOneExpectedResult, clientOneActualResult);
            Assert.AreEqual(clienttwoExpectedResult, clienttwoActualResult);
            Assert.AreEqual(clientthreeExpectedResult, clientthreeActualResult);
            Assert.AreEqual(clientfourexpectedResult, clientfourActualResult);
        }
        [TestMethod]
        public void CalculateNumberOfOpenContracts_ContractsAreOpen_ReturnsTrue()
        {
            DummyCRUD dummyClientCrud = GetDummyClientCRUD();
            DummyCRUD dummyContractCrud = GetDummyContractCRUD();
            BusinessRules businessRulesObject = new BusinessRules(dummyClientCrud, dummyContractCrud);
            var actualResult = businessRulesObject.CalculateNumberOfOpenContracts();
            var expectedResult = 0;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

}
