namespace BankingApplication.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public string? Description { get; set; }

        public Transaction()
        {
            
        }
        public Transaction(string message, decimal amount)
        {
            Description = message;
            Amount = amount;
        }
    }

   
}