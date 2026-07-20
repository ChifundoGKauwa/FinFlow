using FinFlow.Dtos;
using FinFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.Data;
public class FinFlowContext(DbContextOptions<FinFlowContext>options) : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
}