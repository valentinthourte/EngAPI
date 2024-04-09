using AutoMapper;
using eng.api.Automapper;
using eng.application.Services;
using eng.application.Services.Interface;
using eng.repository;
using eng.repository.Helpers;
using eng.repository.Interface;

namespace eng.api.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            // NHibernate
            services.AddSingleton<INHibernateHelper, NHibernateHelper>();

            //Base
            services.AddTransient<IRepository, RepositoryBase>();

            //Services
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddAutoMapper(typeof(AutomapperWebProfile));
        }

    }
}