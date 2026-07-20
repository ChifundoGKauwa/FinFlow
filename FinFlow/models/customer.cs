namespace FinFlow.Dtos;
public class Customer
{
    public required int Id {get;set;}
    public string FirstName {get;set;}= string.Empty;
    public string LastName {get;set;}= string.Empty;
    public DateOnly DateOfBirth {get;set;}
    public string Gender {get;set;}= string.Empty;
    public string PhoneNumber {get;set;}= string.Empty;
    public string Email {get;set;}= string.Empty; 
    public DateTimeOffset CreatedAt {get;set;}
    public DateTimeOffset UpdatedAt {get;set;}
    public List<Account> Accounts {get;set;}= new List<Account>();  
}