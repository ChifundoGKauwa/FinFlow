namespace FinFlow.Dtos;
public record UpdateAccountDto(
    string AccountNumber,
    string AccountType,
    decimal Balance,
    string BranchName,
    string AccountStatus,
    int CustomerId,
    string CurrencyType
);