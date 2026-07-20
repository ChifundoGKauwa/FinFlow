namespace FinFlow.Models;
using FinFlow.Dtos;


public class Transaction 
{
    public required int Id {get;set;}
    public string TransactionType {get;set;}= string.Empty;
    public decimal Amount {get;set;}
    public DateTime TransactionDate {get;set;}
    public string? Description {get;set;}
    public int AccountId {get;set;}
    public DateTimeOffset CreatedAt {get;set;}
    public DateTimeOffset UpdatedAt {get;set;}
    public string CurrencyType {get;set;}= string.Empty;
    public string Channel {get;set;}= string.Empty;
    public string TransactionStatus {get;set;}= string.Empty;
    public DateTimeOffset TransactionTimestamp {get;set;}
    public string TransactionReference {get;set;}= string.Empty;
    public Account ?Account { get; set; } 
    
}