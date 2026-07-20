using Microsoft.EntityFrameworkCore;

namespace FinFlow.Data;
public static class DataExtension
{public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<FinFlowContext>();
        dbContext.Database.Migrate();
    }
}