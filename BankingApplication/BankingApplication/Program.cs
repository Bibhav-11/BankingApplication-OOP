using BankingApplication.Data;
using BankingApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingApplication
{
     class Program
    {
        static void Main()
        {
            using BankingContext context = new();
            Customer John = new()
            {
                FirstName = "John",
                LastName = "Smith",
            };

            SavingsAccount JohnSavings = new(0, John);

            JohnSavings.Deposit(10000);
            JohnSavings.ShowAccountInfo();

            Customer Max = new()
            {
                FirstName = "Max",
                LastName = "Donalds",
            };

            SavingsAccount MaxSavings = new(0, Max);

            JohnSavings.Deposit(500000);
            JohnSavings.ShowAccountInfo();

            context.Accounts.Add(JohnSavings);
            context.Customers.Add(John);
            context.SaveChanges();
        }
    }
}
