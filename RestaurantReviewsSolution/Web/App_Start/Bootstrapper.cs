using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Repository;
using BusinessLogic;
using Web.Models;
using System.Reflection;

namespace Web.App_Start
{
    public class Bootstrapper
    {
        private static IContainer _container;

        public static IContainer RegisterTypes()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new RestMapper()); });
            var mapper = mapperConfiguration.CreateMapper();

            //EntityFramework Context
            builder.RegisterType<RepositoryContext>().AsSelf().InstancePerLifetimeScope();

            //Automapper
            builder.RegisterInstance(mapper).As<IMapper>();

            //Repositories
            builder.RegisterType<RestaurantRepository>().As<IRestaurantRepository>();
            builder.RegisterType<ReviewRepository>().As<IReviewRepository>();

            //Services
            builder.RegisterType<RestServices>().As<IRestServ>();
            builder.RegisterType<RevServices>().As<IRevServ>();

            _container = builder.Build();

            return _container;
        }
    }
}