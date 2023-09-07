using System;


namespace BankingApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
