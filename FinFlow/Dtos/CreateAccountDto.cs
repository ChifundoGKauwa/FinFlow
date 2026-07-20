using System.ComponentModel.DataAnnotations;
namespace FinFlow.Dtos;
public record CreateAccountDto(
    [Required][StringLength(50)] string AccountNumber,
    [Required][StringLength(50)] string AccountType,
    [Required] decimal Balance,
    [Required][StringLength(50)] string BranchName,
    [Required][StringLength(50)] string AccountStatus,
    [Required] int CustomerId,
    [Required][StringLength(10)] string CurrencyType
);