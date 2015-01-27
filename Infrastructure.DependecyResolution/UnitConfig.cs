using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Viainternet.IndustrieQuebec.Core.Models;
using Viainternet.OnionArchitecture.Core.Interfaces;
using Viainternet.OnionArchitecture.Core.Interfaces.IRepositories;
using Viainternet.OnionArchitecture.Core.Interfaces.IServices;
using Viainternet.OnionArchitecture.Core.Services;
using Viainternet.OnionArchitecture.Infrastructure;
using Viainternet.OnionArchitecture.Infrastructure.Factories;

namespace Viainternet.OnionArchitecture.Infrastructure.DependecyResolution
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterComponents(container);
            return container;
        });
        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        private static void RegisterComponents(UnityContainer container)
        {
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container
                .RegisterType<IDataContextAsync, ApplicationDbContext>(new PerRequestLifetimeManager())
               .RegisterType<IRepositoryProvider, RepositoryProvider>(
                   new PerRequestLifetimeManager(),
                   new InjectionConstructor(new object[] { new RepositoryFactories() })
                   )
               .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
               .RegisterType<IRepositoryAsync<Movie>, Repository<Movie>>()
               .RegisterType<IMovieService, MovieService>()
               .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager());

            DependencyResolver.SetResolver(new Microsoft.Practices.Unity.Mvc.UnityDependencyResolver(container));
        }
    }
}
