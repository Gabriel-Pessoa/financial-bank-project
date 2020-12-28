using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp;


namespace Bank.Unit.Tests.Methods
{
    [TestClass]
    public class CreditTest
    {
        private Client _client = new Client()
        {
            ClientID = 1,
            FirstName = "Gabriel",
            LastName = "Pessoa",
            Age = 24
        };


        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            BankAccount account = new BankAccount(_client);
            double beginningBalance = 11.99;
            account.Credit(beginningBalance);
            double creditAmount = 4.55;
            double expected = 16.54;
            //BankAccount account = new BankAccount("Ivanildo Gustavo", 0001, beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Conta não creditada corretamente");
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            BankAccount account = new BankAccount(_client);
            double beginningBalance = 0;
            account.Credit(beginningBalance);
            double creditAmount = -100.00;
           //BankAccount account = new BankAccount("David Correia", 0003, beginningBalance);

            // Act
            try
            {
                account.Credit(creditAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                //Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
                StringAssert.Contains(e.Message, BankAccount.AmountLessThanZeroMessage);
                return;
            }

            //Garante que o metódo falhe sem nenhuma exceção foi gerada
            Assert.Fail("The expected exception was not throw");
        }

        [TestMethod]
        public void Credit_WhenAccountBlocked_ShouldThrowException()
        {
            // Arrange
            BankAccount account = new BankAccount(_client);
            double beginningBalance = 0;
            account.Credit(beginningBalance);
            double creditAmount = 20;
            //BankAccount account = new BankAccount("Ramon Augusto", 0004, beginningBalance);

            account.BlockedAccount();

            // Act
            try
            {
                account.Credit(creditAmount);
            }
            catch (System.Exception e)
            {
                //Assert.ThrowsException<System.Exception>(() => account.Debit(debitAmount));
                StringAssert.Contains(e.Message, BankAccount.AccountBlockedMessage);
                return;
            }

            //Garante que o metódo falhe sem nenhuma exceção foi gerada
            Assert.Fail("The expected exception was not throw");
        }
    }
}
