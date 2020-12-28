using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class BankAccount
    {
        private readonly IClient _client;


        private double _Balance = 0;
        private bool _Blocked = false;

        public BankAccount(IClient client)
        {
            this._client = client;
        }

        public (int clientID, string clientFullName) GetClient()
        {
            return _client.GetClient();
        }

        public double Balance
        {
            get => _Balance;
        }

        public bool Blocked
        {
            get => _Blocked;
        }

        public void BlockedAccount()
        {
            _Blocked = true;
        }

        public void UnblockedAccount()
        {
            _Blocked = false;
        }

        public const string AmountExceedsBalanceMessage = "Amount exceeds balance";
        public const string AmountLessThanZeroMessage = "Amount is less than zero";
        public const string AccountBlockedMessage = "Account blocked";

        public void Debit(double amount)
        {
            if(_Blocked)
            {
                throw new Exception(AccountBlockedMessage);
            }

            if (amount > _Balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, AmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, AmountLessThanZeroMessage);
            }

            _Balance -= amount; // código corrigido
        }

        public void Credit(double amount)
        {
            if (_Blocked)
            {
                throw new Exception(AccountBlockedMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, AmountLessThanZeroMessage);
            }

            _Balance += amount;
        }
    }
}
