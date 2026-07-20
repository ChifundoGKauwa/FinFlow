namespace FinFlow.Dtos;

public record CreateTransactionDto(
    int AccountId,
    decimal Amount,
    string TransactionType,
    DateTime TransactionDate,
    string? Description,
    string CurrencyType,
    string Channel,
    string TransactionStatus,
    string TransactionReference
);