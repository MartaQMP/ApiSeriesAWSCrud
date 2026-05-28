using Amazon.Lambda.Annotations;
using ApiSeriesAWSCrud.Data;
using ApiSeriesAWSCrud.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiSeriesAWSCrud;

[LambdaStartup]
public class Startup
{
    
    public void ConfigureServices(IServiceCollection services)
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true);
        var configuration = builder.Build();
        string connectionString = configuration.GetConnectionString("MySqlConnection");
        services.AddTransient<RepositorySeries>();
        services.AddDbContext<SeriesContext>(options => options.UseMySQL(connectionString));
    }
}
