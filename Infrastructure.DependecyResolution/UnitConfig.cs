using Infrastructure.Caching;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Web.Mvc;

namespace Viainternet.OnionArchitecture.Infrastructure.DependecyResolution
{
    using Core.Domain.Models;
    using Core.Interfaces;
    using Core.Interfaces.IRepositories;
    using Core.Interfaces.IServices;
    using Core.Services;
    using Infrastructure.Factories;

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
            container.AddNewExtension<Interception>();
            container
                .RegisterType<IDataContextAsync, ApplicationDbContext>(new PerRequestLifetimeManager())
               .RegisterType<IRepositoryProvider, RepositoryProvider>(
                   new PerRequestLifetimeManager(),
                   new InjectionConstructor(new object[] { new RepositoryFactories() }))
               .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
               .RegisterType<IRepositoryAsync<Movie>, Repository<Movie>>()
               .RegisterType<IRepositoryAsync<UserMembership>, Repository<UserMembership>>()
               .RegisterType<IMovieService, MovieService>(
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<CachingInterceptorAttribute>())
                .RegisterType<IUserMembershipService, UserMembershipService>(
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<CachingInterceptorAttribute>())
               .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
            .RegisterType<CachingInterceptorAttribute>(new InjectionConstructor(CachingAction.Add));

            DependencyResolver.SetResolver(new Microsoft.Practices.Unity.Mvc.UnityDependencyResolver(container));
        }
    }
}
