using System.Web;
using Library.Identity;
using Library.Repositories;
using Library.Repositories.Interfaces;
using Library.Services;
using Library.Services.Interfaces;
using Microsoft.Practices.Unity;
using Unity.WebForms;

[assembly: WebActivatorEx.PostApplicationStartMethod( typeof(ASP.App_Start.UnityWebFormsStart), "PostStart" )]
namespace ASP.App_Start
{
	internal static class UnityWebFormsStart
	{
		internal static void PostStart()
		{
			IUnityContainer container = new UnityContainer();
			HttpContext.Current.Application.SetContainer( container );

			RegisterDependencies( container );
		}

		private static void RegisterDependencies( IUnityContainer container )
		{
			container.RegisterType<UserManager>();
			container.RegisterType<IBookService,BookService>();
			container.RegisterType<IUnitOfWork, LibraryUnitOfWork>();
		}
	}
}