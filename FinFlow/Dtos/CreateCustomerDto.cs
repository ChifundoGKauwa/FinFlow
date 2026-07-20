using System.ComponentModel.DataAnnotations;

namespace FinFlow.Dtos;
public record CreateCustomerDto(
    [Required][StringLength(50)]string FirstName,
    [Required][StringLength(50)]string LastName,
    [Required]DateOnly DateOfBirth,
    [Required][StringLength(10)]string Gender,
    [Required][StringLength(20)]string PhoneNumber,
    [Required][EmailAddress]string Email

);