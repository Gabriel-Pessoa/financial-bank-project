using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client cliGabriel = new Client() 
            {
                ClientID = 1,
                FirstName = "Gabriel",
                LastName = "Pessoa",
                Age = 24
            };

            BankAccount ba = new BankAccount(cliGabriel);

            (int id, string name) client = ba.GetClient();

            Console.WriteLine(client.id);
            Console.WriteLine(client.name);

            Console.WriteLine(Equals(1, client.id));
            Console.WriteLine(Equals("GabrielPessoa", client.name));
        }
    }
}
