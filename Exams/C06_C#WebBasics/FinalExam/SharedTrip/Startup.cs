namespace SharedTrip
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Services;
    using SharedTrip.Services.Interfaces;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ITripsService, TripsService>();
        }

        public void Configure(IList<Route> routeTable)
        {
            using var db = new ApplicationDbContext();
            db.Database.Migrate();
        }
    }
}
