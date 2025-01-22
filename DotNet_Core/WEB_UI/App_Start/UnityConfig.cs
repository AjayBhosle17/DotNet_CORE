using BAL;
using DAL;
using Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace WEB_UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ApplicationDbContext, ApplicationDbContext>();
            container.RegisterType<IcategoryRepository, CategoryRepository>();
            container.RegisterType<ICategoryService, CategoryService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}