using FinFlow.Data;

namespace FinFlow.Dtos;
public static class CustomerEndpoints
{
    public const string GetCustomerById = "GetCustomerById";

    public static void MapCustomerEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/customers");

        // GET customers
        group.MapGet("/", (FinFlowContext Db) =>
        {
            return Results.Ok(Db.Customers.ToList());
        });

        const string EndpointName = GetCustomerById;

        // GET customer by ID
        group.MapGet("/{id}", (int id, FinFlowContext Db) =>
        {
            var customer = Db.Customers.Find(id);
            if (customer == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(customer);
        }).WithName(EndpointName);

        // POST customers
        group.MapPost("/", (CreateCustomerDto newCustomer, FinFlowContext Db) =>
        {
            var customer = new Customer
            {
                Id = 0,
                FirstName = newCustomer.FirstName,
                LastName = newCustomer.LastName,
                DateOfBirth = newCustomer.DateOfBirth,
                Gender = newCustomer.Gender,
                PhoneNumber = newCustomer.PhoneNumber,
                Email = newCustomer.Email,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            Db.Customers.Add(customer);
            Db.SaveChanges();
            return Results.CreatedAtRoute(EndpointName, new { id = customer.Id }, customer);
        });

        // PUT customers
        group.MapPut("/{id}", (int id, UpdateCustomerDto updatedCustomer, FinFlowContext Db) =>
        {
            var customer = Db.Customers.Find(id);
            if (customer == null)
            {
                return Results.NotFound();
            }

            customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
            customer.DateOfBirth = updatedCustomer.DateOfBirth;
            customer.Gender = updatedCustomer.Gender;
            customer.PhoneNumber = updatedCustomer.PhoneNumber;
            customer.Email = updatedCustomer.Email;
            customer.UpdatedAt = DateTimeOffset.UtcNow;

            Db.SaveChanges();
            return Results.Ok(customer);
        });

        // DELETE customers
        group.MapDelete("/{id}", (int id, FinFlowContext Db) =>
        {
            var customer = Db.Customers.Find(id);
            if (customer == null)
            {
                return Results.NotFound("Customer not found");
            }

            Db.Customers.Remove(customer);
            Db.SaveChanges();
            return Results.NoContent();
        });
    }
}
