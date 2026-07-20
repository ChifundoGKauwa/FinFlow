using System.ComponentModel.DataAnnotations;

namespace FinFlow.Dtos;

public record AccountDto(
    [Required] int Id,
    [Required][StringLength(50)] string accountNumber,
    [Required][StringLength(50)] string accountType,
    [Required][StringLength(50)] string branchName,
    [Required][StringLength(50)] string accountStatus,
    [Required] decimal accountBalance,
    [Required] int CustomerId,
    [Required] DateTimeOffset createdAt,
    [Required] DateTimeOffset updatedAt,
    [Required] string currencyType

);
