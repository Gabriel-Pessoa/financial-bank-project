using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
   public interface IClient
    {
        (int clientID, string clientFullName) GetClient();
    }
}
