using GestionDesAbsence.Services;
using GestionDesAbsence.ServicesImpl;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace GestionDesAbsence
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IProfesseurService, ProfesseurService>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IAdminService, AdminService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}