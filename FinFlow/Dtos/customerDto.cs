using System.ComponentModel.DataAnnotations;

namespace FinFlow.Dtos;
public record  CustomerDto(
    int Id,
   [Required][StringLength(50)] string firstname,
    [Required][StringLength(50)] string lastname,
    [Required] DateOnly date_of_birth,
    [Required][StringLength(10)] string gender,
    [Required][StringLength(20)] string phoneNumber,
    [Required][EmailAddress] string email,
    DateTimeOffset createdAt,
    DateTimeOffset updatedAt
);
