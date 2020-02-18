using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using SIS.HTTP;
using SIS.MvcFramework;

using SULS.Data;
using SULS.Services;

namespace SULS.App
{
    public class StartUp : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }

        public void Configure(IList<Route> routeTable)
        {
            var db = new SULSContext();
            db.Database.Migrate();
        }

    }
}