using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Demo.DbMigration.DbContexts;

namespace Demo.DbMigration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add DatabaseA Context to DI container
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="connectionString">Connection string for DatabaseA</param>
        /// <returns>Service collection for chaining</returns>
        public static IServiceCollection AddDatabaseAContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<DatabaseAContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory_DatabaseA");
                });
                options.EnableSensitiveDataLogging(false);
                options.EnableDetailedErrors(false);
            });
        }

        /// <summary>
        /// Add DatabaseB Context to DI container
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="connectionString">Connection string for DatabaseB</param>
        /// <returns>Service collection for chaining</returns>
        public static IServiceCollection AddDatabaseBContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<DatabaseBContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory_DatabaseB");
                });
                options.EnableSensitiveDataLogging(false);
                options.EnableDetailedErrors(false);
            });
        }

        /// <summary>
        /// Add DatabaseC Context to DI container
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="connectionString">Connection string for DatabaseC</param>
        /// <returns>Service collection for chaining</returns>
        public static IServiceCollection AddDatabaseCContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<DatabaseCContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory_DatabaseC");
                });
                options.EnableSensitiveDataLogging(false);
                options.EnableDetailedErrors(false);
            });
        }

        /// <summary>
        /// Add multiple database contexts at once
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="connectionStringA">Connection string for DatabaseA</param>
        /// <param name="connectionStringB">Connection string for DatabaseB</param>
        /// <param name="connectionStringC">Connection string for DatabaseC</param>
        /// <returns>Service collection for chaining</returns>
        public static IServiceCollection AddDemoDbContexts(this IServiceCollection services,
            string connectionStringA,
            string connectionStringB,
            string connectionStringC)
        {
            services.AddDatabaseAContext(connectionStringA);
            services.AddDatabaseBContext(connectionStringB);
            services.AddDatabaseCContext(connectionStringC);

            return services;
        }
    }
}
