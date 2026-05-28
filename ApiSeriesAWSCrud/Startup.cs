using Amazon.Lambda.Annotations;
using ApiSeriesAWSCrud.Data;
using ApiSeriesAWSCrud.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiSeriesAWSCrud;

[LambdaStartup]
public class Startup
{
    
    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString =
            @"server=mysqlpaco.c0pu6q8om1qt.us-east-1.rds.amazonaws.com;port=3306;user id=adminsql;password=Admin123;database=seriesmarta";
        services.AddTransient<RepositorySeries>();
        services.AddDbContext<SeriesContext>(options => options.UseMySQL(connectionString));
    }
}
