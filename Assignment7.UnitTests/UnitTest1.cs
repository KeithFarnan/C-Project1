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
                ClientName = "Test",
                Address = "TestLand",
                DateOfBirth = new DateTime(1969, 6, 09)
            };
            Client test2 = new Client()
            {
                ClientName = "Test2",
                Address = "TestLand",
                DateOfBirth = new DateTime(1969, 6, 09)
            };
            Client test3 = new Client()
            {
                ClientName = "Test3",
                Address = "TestLand",
                DateOfBirth = new DateTime(1969, 6, 09)
            };
            Client test4 = new Client()
            {
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
                Contract_Value = 100,
                AmountOwed = 90
            };
            crud.contracts.Add(contract1);
            crud.contracts.Add(contract2);
            crud.contracts.Add(contract3);
            crud.contracts.Add(contract4);
            return crud;
        }
        [TestMethod]
        public void CalculateAverageNumberOfContractsPerClient_ContractsAreOpen_ReturnsTrue()
        {
            DummyCRUD dummyClientCrud = GetDummyClientCRUD();
            DummyCRUD dummyContractCrud = GetDummyContractCRUD();

            BusinessRules businessRulesObject = new BusinessRules(dummyClientCrud, dummyContractCrud);

            var actualResult = businessRulesObject.CalculateNumberOfOpenContracts();
            var expectedResult = 4;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
