using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
   public class Client : IClient
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public (int clientID, string clientFullName) GetClient()
        {
            (int clientID, string clientFullName) resultOperation;
            int ID = this.ClientID;
            string fullName = this.FirstName + this.LastName;
            resultOperation = (ID, fullName);

            return resultOperation;
        }
    }
}
