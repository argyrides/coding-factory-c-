using AccountApp.Model;

namespace AccountApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new()
            {
                Id = 1,
                Iban = "GR123",
                Firstname = "Alex",
                Lastname = "Argyrides",
                Balance = 100,
                Ssn = "123"
            };

            try
            {
                account.Deposit(1000M);
                account.Withdraw(400M);
                Console.WriteLine(account);
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }
    }
}