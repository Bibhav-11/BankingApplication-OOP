using BankingApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace BankingApplication.Data
{
    public class BankingContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-QL8TT9L5\SQLEXPRESS;Initial Catalog=BankingApplicationDatabase;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
