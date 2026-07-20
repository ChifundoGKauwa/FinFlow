namespace FinFlow.Dtos;

public record TransactionDto(
    int Id,
    int AccountId,
    decimal Amount,
    string TransactionType,
    DateTime TransactionDate,
    string? Description,
    string CurrencyType,
    string Channel,
    string TransactionStatus,
    DateTimeOffset TransactionTimestamp,
    string TransactionReference
);