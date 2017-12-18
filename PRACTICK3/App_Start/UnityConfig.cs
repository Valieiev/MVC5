using Microsoft.Practices.Unity;
using System.Web.Mvc;
using PRACTICK3.Repositories;
using PRACTICK3.Service;
using PRACTICK3.Controllers;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;

namespace PRACTICK3
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IBoardgameRepository, BoardgameRepository>();
            container.RegisterType<IBoardgameService, BoardgameService>();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            RegisterTypes(container);
            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {

        }

    }
}