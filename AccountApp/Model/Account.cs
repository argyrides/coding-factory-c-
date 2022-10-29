using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp.Model
{
    internal class Account
    {
        public int Id { get; set; }
        public string? Iban { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Ssn { get; set; }
        public decimal Balance { get; set; }

        public void Withdraw(decimal amount)
        {
            try
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Logger(ex);
                throw;
            }
        }

        public void Deposit(decimal amount)
        {
            try
            {
                if (amount > 0)
                {
                    Balance += amount;
                }
                else
                {
                    throw new Exception("The amount is negative");
                }
            }
            catch (Exception ex)
            {
                Logger(ex);
                throw;
            }

        }

        private static void Logger(Exception e)
        {
            FileStream fs = new FileStream(@"C:\tmp\log.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.AutoFlush = true;    
            sw.WriteLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}, {e}");
        }

    }   
}
