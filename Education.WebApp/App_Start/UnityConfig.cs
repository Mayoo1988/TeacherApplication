using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Education.Core;
using Education.WebApp.Controllers;
using Education.Core.Students;
using Education.Core.Admin;

namespace Education.WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserReposetory,UserReposetory>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            container.RegisterType<IStudentReposetory, StudentReposetory>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            container.RegisterType<IVideoUpload, VideoUpload>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            container.RegisterType<ITestDetailsRepository, TestDetailsRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}