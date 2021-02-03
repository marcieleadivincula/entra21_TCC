using NUnit.Framework;
using System;
using System.Transactions;

namespace Domain.IntegrationTests
{
    [SetUpFixture]
    public class DomainSetUpFixture
    {
        private TransactionScope _transactionScope;

        [OneTimeSetUp]
        public void SetUp()
        {
            _transactionScope = new TransactionScope();
            Console.WriteLine("---------- BEGIN TRANSACTION ----------");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _transactionScope.Dispose();
            Console.WriteLine("---------- ROLLBACK TRANSACTION ----------");
        }
    }

}