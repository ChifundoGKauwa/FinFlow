using FinFlow.Data;
using FinFlow.Dtos;
using FinFlow.Models;

public static class TransactionEndpoints
{
    public const string GetTransactionById = "GetTransactionById";

    public static void MapTransactionEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/transactions");

        group.MapGet("/", (FinFlowContext Db) =>
        {
            return Results.Ok(Db.Transactions.ToList());
        });

        group.MapGet("/{id}", (int id, FinFlowContext Db) =>
        {
            var transaction = Db.Transactions.Find(id);
            if (transaction is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(transaction);
        }).WithName(GetTransactionById);

        group.MapPost("/", (CreateTransactionDto newTransaction, FinFlowContext Db) =>
        {
            string transactionReference = $"FT/{Guid.NewGuid().ToString("N")[..5].ToUpper()}/{Guid.NewGuid().ToString("N")[..5].ToUpper()}";
            var transaction = new Transaction
            {
                Id = 0,
                AccountId = newTransaction.AccountId,
                Amount = newTransaction.Amount,
                TransactionType = newTransaction.TransactionType,
                TransactionDate = newTransaction.TransactionDate,
                Description = newTransaction.Description,
                CurrencyType = newTransaction.CurrencyType,
                Channel = newTransaction.Channel,
                TransactionStatus = newTransaction.TransactionStatus,
                TransactionTimestamp = DateTimeOffset.UtcNow,
                TransactionReference = transactionReference,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            Db.Transactions.Add(transaction);
            Db.SaveChanges();

            return Results.CreatedAtRoute(GetTransactionById, new { id = transaction.Id }, transaction);
        });

        group.MapPut("/{id}", (int id, UpdateTransactionDto updatedTransaction, FinFlowContext Db) =>
        {
            var transaction = Db.Transactions.Find(id);
            if (transaction is null)
            {
                return Results.NotFound();
            }

            transaction.AccountId = updatedTransaction.AccountId;
            transaction.Amount = updatedTransaction.Amount;
            transaction.TransactionType = updatedTransaction.TransactionType;
            transaction.TransactionDate = updatedTransaction.TransactionDate;
            transaction.Description = updatedTransaction.Description;
            transaction.CurrencyType = updatedTransaction.CurrencyType;
            transaction.Channel = updatedTransaction.Channel;
            transaction.TransactionStatus = updatedTransaction.TransactionStatus;
            transaction.TransactionTimestamp = DateTimeOffset.UtcNow;
            transaction.TransactionReference = updatedTransaction.TransactionReference;
            transaction.UpdatedAt = DateTimeOffset.UtcNow;

            Db.SaveChanges();
            return Results.Ok(transaction);
        });

        group.MapDelete("/{id}", (int id, FinFlowContext Db) =>
        {
            var transaction = Db.Transactions.Find(id);
            if (transaction is null)
            {
                return Results.NotFound();
            }

            Db.Transactions.Remove(transaction);
            Db.SaveChanges();
            return Results.NoContent();
        });
    }
}
