using FinFlow.Data;
using FinFlow.Dtos;

public static class AccountEndpoints
{
    public const string GetAccountById = "GetAccountById";

    public static void MapAccountEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/accounts");

        group.MapGet("/", (FinFlowContext Db) =>
        {
            return Results.Ok(Db.Accounts.ToList());
        });

        const string EndpointName = GetAccountById;

        group.MapGet("/{id}", (int id, FinFlowContext Db) =>
        {
            var account = Db.Accounts.Find(id);
            if (account == null)
            {
                return Results.NotFound("Account not found");
            }
            return Results.Ok(account);
        }).WithName(EndpointName);

        group.MapPost("/", (CreateAccountDto newAccount, FinFlowContext Db) =>
        {
            var account = new Account
            {
                AccountNumber = newAccount.AccountNumber,
                AccountType = newAccount.AccountType,
                BranchName = newAccount.BranchName,
                AccountStatus = newAccount.AccountStatus,
                Balance = newAccount.Balance,
                CustomerId = newAccount.CustomerId,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow,
                CurrencyType = newAccount.CurrencyType
            };

            Db.Accounts.Add(account);
            Db.SaveChanges();
            return Results.CreatedAtRoute(EndpointName, new { id = account.Id }, account);
        });

        group.MapPut("/{id}", (int id, UpdateAccountDto updatedAccount, FinFlowContext Db) =>
        {
            var account = Db.Accounts.Find(id);
            if (account == null)
            {
                return Results.NotFound("Account not found");
            }

            account.AccountNumber = updatedAccount.AccountNumber;
            account.AccountType = updatedAccount.AccountType;
            account.BranchName = updatedAccount.BranchName;
            account.AccountStatus = updatedAccount.AccountStatus;
            account.Balance = updatedAccount.Balance;
            account.CustomerId = updatedAccount.CustomerId;
            account.CurrencyType = updatedAccount.CurrencyType;
            account.UpdatedAt = DateTimeOffset.UtcNow;

            Db.SaveChanges();
            return Results.Ok(account);

        });

        group.MapDelete("/{id}", (int id, FinFlowContext Db) =>
        {
            var account = Db.Accounts.Find(id);
            if (account == null)
            {
                return Results.NotFound("Account not found");
            }
            Db.Accounts.Remove(account);
            Db.SaveChanges();
            return Results.NoContent();
        });
    }
}
