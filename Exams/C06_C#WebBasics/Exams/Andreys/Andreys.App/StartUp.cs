using System.Collections.Generic;
using Andreys.Data;
using Andreys.Services;
using Andreys.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.App
{
    public class StartUp : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProductsService, ProductsService>();
        }

        public void Configure(IList<Route> routeTable)
        {
            var db = new AndreysDbContex();
            db.Database.Migrate();
        }
    }
}