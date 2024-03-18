using evmanager14905v2.Data;
using evmanager14905v2.Interfaces;
using evmanager14905v2.Repositories;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
     
       
        services.AddScoped<IEventRepository, EventRepository>(); 
        services.AddScoped<IEventRatingRepository, EventRatingRepository>();


        services.AddControllers();
    }

   
}
