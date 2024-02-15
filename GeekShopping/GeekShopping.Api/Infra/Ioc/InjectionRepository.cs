﻿


using GeekShopping.Api.Domain.Interfaces.IRepository;
using GeekShopping.Api.Infra.Data.Context;
using GeekShopping.Api.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Api.Infra.Ioc
{
    public static class InjectionRepository
    {
        public static void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            

            //serviceCollection.AddScoped<MySqlContext, MySqlContext>();


            //Pega a Conexao do arquivo lauch.json
            serviceCollection.AddDbContext<MySqlContext>(options => options.UseMySql(
                                                                                        configuration.GetSection("MySqlConfiguration").GetSection("ConnectionString").Value,
                                                                                        new MySqlServerVersion(new Version(8,0,36))));


            serviceCollection.AddScoped<IProductRepository, ProductRepository>();


        }
    }
}
