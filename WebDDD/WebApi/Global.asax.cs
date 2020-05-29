
using Aplication.Services.Persona;
using Aplication.Services.Persona.Implementation;
using Autofac;
using Autofac.Features.Variance;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Domain.Core.Event;
using Domain.Core.Model.Persona;
using Domain.Core.Services;
using MediatR;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApi.Areas.HelpPage.Controllers;
using WebApi.Controllers;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // REGISTRO AUTOFAC
            #region REGISTRO AUTOFAC
            var builder = new ContainerBuilder();      

           // builder.RegisterType<PersonasController>().InstancePerRequest();

            // Get your HttpConfiguration.
             //var config = GlobalConfiguration.Configuration;

            var config = new HttpConfiguration();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(WebApiApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // OPTIONAL: Enable action method parameter injection (RARE).
            //  builder.InjectActionInvoker();

            //DEPENDENCIAS DE LA APLICACION
            // APPLICATION SERVICE
            builder.RegisterType<PersonaQueryService>().As<IPersonaQueryService>().InstancePerRequest();
            builder.RegisterType<PersonaCommandService>().As<IPersonaCommandService>().InstancePerRequest();

            //* INFRASTRUCTURE

            //CacheRepository for Ad
            builder.RegisterType<InfrastructureCache.HttpRuntimeCache<IEnumerable<Domain.Core.Model.Persona.Persona>>>().As<ICache<IEnumerable<Domain.Core.Model.Persona.Persona>>>().InstancePerRequest();

            //Sql connection type & connectionString
            builder.RegisterType<Infrastructure.Persistence.SQL.SqlConnectionFactory>()
                .As<Infrastructure.Persistence.SQL.IConnectionFactory>()
                .WithParameter("connectionString", System.Configuration.ConfigurationManager.ConnectionStrings["BDANIMALESEntities"].ConnectionString)
                .InstancePerRequest();

            builder.RegisterType<Infrastructure.Persistence.SQL.Persona.PersonaQueryRepository>().As<IPersonaQueryRepository>().InstancePerRequest();
            builder.RegisterType<Infrastructure.Persistence.SQL.Persona.PersonaCommandRepository>().As<IPersonaCommnadRepository>().InstancePerRequest();
            //*

            //DOMAIN SERVICES - ACL

            //ACL for external API façade
            //builder.RegisterType<ACL.PostalCodeAdapter>().As<Domain.Core.Services.IPostalCodeAdapter>().InstancePerRequest();
            //builder.RegisterType<ACL.PostalCodeTranslator>().As<Domain.Core.Services.IPostalCodeTranslator>().InstancePerRequest();
            //*
            //*


            //MEDIATR
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(Models.Command.Persona.PersonaCommand).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(Models.Query.Persona.PersonaQuery).GetTypeInfo().Assembly).AsImplementedInterfaces();


            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            //**


            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            // GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
            //  config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            // DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            //AQUI
            //// Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            //// Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
            //HASTA AQUI

            #endregion

            DomainEvents.Dispatcher = new Infrastructure.Messaging.MassTransit.Middleware();

            Infrastructure.Messaging.MassTransit.Consumer.PersonaCreated.Listen();
        }
    }
}
