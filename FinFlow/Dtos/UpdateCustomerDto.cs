namespace FinFlow.Dtos;
public record  UpdateCustomerDto(
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string Gender,
    string PhoneNumber,
    string Email
);