using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Demo.DbMigration.DbContexts;

namespace Demo.DbMigration;

/// <summary>
/// Helper class for Design-Time Factories
/// </summary>
public static class DesignTimeHelper
{
    public static string? TryGetConnectionStringFromConfig(string startPath, string connectionName)
    {
        var currentPath = startPath;

        // Search up to 3 levels up
        for (int i = 0; i < 3; i++)
        {
            var configPath = Path.Combine(currentPath, "appsettings.json");

            if (File.Exists(configPath))
            {
                try
                {
                    var config = new ConfigurationBuilder()
                        .AddJsonFile(configPath)
                        .Build();

                    var connectionString = config.GetConnectionString(connectionName);
                    if (!string.IsNullOrEmpty(connectionString))
                    {
                        Console.WriteLine($"[Design-Time Factory] Found appsettings.json at: {configPath}");
                        return connectionString;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Design-Time Factory] Error reading config from {configPath}: {ex.Message}");
                }
            }

            var parentPath = Directory.GetParent(currentPath)?.FullName;
            if (parentPath == null) break;
            currentPath = parentPath;
        }

        return null;
    }
}

/// <summary>
/// Smart Design-time factory for DatabaseAContext
/// </summary>
public class DatabaseAContextFactory : IDesignTimeDbContextFactory<DatabaseAContext>
{
    public DatabaseAContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseAContext>();

        var currentDir = Directory.GetCurrentDirectory();
        var connectionString = DesignTimeHelper.TryGetConnectionStringFromConfig(currentDir, "DatabaseA");

        if (string.IsNullOrEmpty(connectionString))
        {
            connectionString = "Server=localhost,1442;Database=DatabaseA;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;";
            Console.WriteLine($"[Design-Time Factory] Using default connection string for DatabaseA");
        }
        else
        {
            Console.WriteLine($"[Design-Time Factory] Found connection string in appsettings.json: {connectionString.Substring(0, Math.Min(50, connectionString.Length))}...");
        }

        optionsBuilder.UseSqlServer(connectionString);
        return new DatabaseAContext(optionsBuilder.Options);
    }
}

/// <summary>
/// Smart Design-time factory for DatabaseBContext
/// </summary>
public class DatabaseBContextFactory : IDesignTimeDbContextFactory<DatabaseBContext>
{
    public DatabaseBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseBContext>();

        var currentDir = Directory.GetCurrentDirectory();
        var connectionString = DesignTimeHelper.TryGetConnectionStringFromConfig(currentDir, "DatabaseB");

        if (string.IsNullOrEmpty(connectionString))
        {
            connectionString = "Server=localhost,1442;Database=DatabaseB;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;";
            Console.WriteLine($"[Design-Time Factory] Using default connection string for DatabaseB");
        }
        else
        {
            Console.WriteLine($"[Design-Time Factory] Found connection string in appsettings.json: {connectionString.Substring(0, Math.Min(50, connectionString.Length))}...");
        }

        optionsBuilder.UseSqlServer(connectionString);
        return new DatabaseBContext(optionsBuilder.Options);
    }
}

/// <summary>
/// Smart Design-time factory for DatabaseCContext
/// </summary>
public class DatabaseCContextFactory : IDesignTimeDbContextFactory<DatabaseCContext>
{
    public DatabaseCContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseCContext>();

        var currentDir = Directory.GetCurrentDirectory();
        var connectionString = DesignTimeHelper.TryGetConnectionStringFromConfig(currentDir, "DatabaseC");

        if (string.IsNullOrEmpty(connectionString))
        {
            connectionString = "Server=localhost,1443;Database=DatabaseC;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;";
            Console.WriteLine($"[Design-Time Factory] Using default connection string for DatabaseC");
        }
        else
        {
            Console.WriteLine($"[Design-Time Factory] Found connection string in appsettings.json: {connectionString.Substring(0, Math.Min(50, connectionString.Length))}...");
        }

        optionsBuilder.UseSqlServer(connectionString);
        return new DatabaseCContext(optionsBuilder.Options);
    }
}