using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Musaka.Data;
using Musaka.Services;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Musaka.App
{
    public class StartUp : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
        }

        public void Configure(IList<Route> routeTable)
        {
            var db = new MusakaDbContext();
            db.Database.Migrate();
        }

    }
}