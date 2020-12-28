using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp;

namespace Bank.Unit.Tests.Methods
{
    [TestClass]
    public class DebitTest
    {
        private Client _client = new Client()
        {
            ClientID = 1,
            FirstName = "Gabriel",
            LastName = "Pessoa",
            Age = 24
        };

        
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            BankAccount account = new BankAccount(_client);
            double beginningBalance = 11.99;
            account.Credit(beginningBalance);
            double debitAmount = 4.55;
            double expected = 7.44;
            // BankAccount account = new BankAccount("Ytallo Gustavo", 0002, beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Conta não debitada corretamente");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            BankAccount account = new BankAccount(_client);
            double beginningBalance = 11.99;
            account.Credit(beginningBalance);
            double debitAmount = -100.00;
            //BankAccount account = new BankAccount("David Correia", 0003, beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
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
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            BankAccount account = new BankAccount(_client);
            double beginningBalance = 11.99;
            account.Credit(beginningBalance);
            double debitAmount = 100.00;
            //BankAccount account = new BankAccount("Ramon Augusto", 0004, beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                //Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
                StringAssert.Contains(e.Message, BankAccount.AmountExceedsBalanceMessage);
                return;
            }

            //Garante que o metódo falhe sem nenhuma exceção foi gerada
            Assert.Fail("The expected exception was not throw");
        }

        [TestMethod]
        public void Debit_WhenAccountBlocked_ShouldThrowException()
        {
            // Arrange
            BankAccount account = new BankAccount(_client);
            double beginningBalance = 11.99;
            account.Credit(beginningBalance);
            double debitAmount = 11.99;
            //BankAccount account = new BankAccount("Ramon Augusto", 0004, beginningBalance);

            account.BlockedAccount();

            // Act
            try
            {
                account.Debit(debitAmount);
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
