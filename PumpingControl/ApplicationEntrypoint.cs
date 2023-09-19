using Microsoft.EntityFrameworkCore;

namespace PumpingControl;

public class ApplicationEntrypoint
{
    public static void RunMigration<T>(IApplicationBuilder app) where T : DbContext
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<T>();
        context?.Database.Migrate();
    }
}