using Contractor.API.DbContext;
using Contractor.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Contractor.API
{
    public static class StartupHelperExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IContractorRepository, ContractorRepository>();

            builder.Services.AddDbContext<ContractorDbContext>(options =>
            {
                options.UseSqlite(@"Data Source=ContractorDb.db");
            });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            try
            {
                var context = scope.ServiceProvider.GetService<ContractorDbContext>();

                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "Podczas migracji bazy danych wystąpił błąd");
            }
        }
    }
}
