using FinFlow.Models;

namespace FinFlow.Dtos;
public class Account
{
   public int Id { get; set; }
   public string AccountNumber { get; set; } = string.Empty;
   public string AccountType { get; set; } = string.Empty;
   public decimal Balance { get; set; }
   public string BranchName { get; set; } = string.Empty;
   public string AccountStatus { get; set; } = string.Empty;
   public required int CustomerId { get; set; } 
   public DateTimeOffset CreatedAt { get; set; }
   public DateTimeOffset UpdatedAt { get; set; }
   public string CurrencyType { get; set; } = string.Empty;
    public Customer? Customer { get; set; }
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}