using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class Account
    {
        //Encapsulation
        private decimal Balance { get; set; }
        [Key]
        public int AccountNumber { get; set; }
        
        public Customer Owner { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Account()
        {
            Balance = 0;
        }
        public Account(decimal balance, Customer owner) : this()
        {
            Balance = balance;
            Owner = owner;
        } 


        //Abstraction
        public virtual void Deposit(decimal amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("The amount you are trying to deposit is invalid.");
            }

            Balance += amount;
            Transactions.Add(new Transaction($"Successfully deposited {amount} to account {AccountNumber}", amount));
        }

        public void WithDraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("The amount you are trying to withdraw the current balance");
            }

            Balance += amount;
            Transactions.Add(new Transaction($"Successfully withdrawn {amount} from account {AccountNumber}", amount));
        }

        public void ShowAccountInfo()
        {
            Console.WriteLine($"Account Id: {AccountNumber}");
            Console.WriteLine($"Account Holder's Name: {Owner.FirstName} {Owner.LastName}");
            Console.WriteLine($"Account Balance: {Balance}");
            Console.WriteLine("Transactions: ");
            foreach(var transaction in Transactions)
            {
                Console.WriteLine($"Transaction Description: {transaction.Description}");
                Console.WriteLine($"Transaction Amount: {transaction.Amount}");
                Console.WriteLine($"Transaction Time: {transaction.Time}");
            }
        }

        public decimal GetBalance()
        {
            return Balance;
        }
    }

    //Inheritance
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; } = 0.08m; // 8% interest 

        public SavingsAccount(decimal balance, Customer owner) : base(balance, owner)
        {
            
        }

        
        public void AddInterest(decimal amount)
        {
            decimal interestAmount = amount * InterestRate;
            base.Deposit(interestAmount);
            Transactions.Add(new Transaction($"Successfully added interest {interestAmount} to account {AccountNumber}", amount));
        }

        //Polymorphism
        public override void Deposit(decimal amount)
        {
            AddInterest(amount);
            base.Deposit(amount);
        }
    }
}