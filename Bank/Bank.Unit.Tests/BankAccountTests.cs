using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp;


namespace Bank.Unit.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void IntegrationBankAccountClassWithClientClass()
        {
            //Arrange
            Client _client = new Client()
            {
                ClientID = 1,
                FirstName = "Gabriel",
                LastName = "Pessoa",
                Age = 24
            };
            BankAccount bankAccount = new BankAccount(_client);
           

            //Act
            (int id, string fullName) op = bankAccount.GetClient();

            //Assert
            Assert.AreEqual(1, op.id);
            Assert.AreEqual("GabrielPessoa", op.fullName);
        }
    }
}
