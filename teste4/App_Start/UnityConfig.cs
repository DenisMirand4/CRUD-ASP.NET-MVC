using ClassLibrary3.Servico;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using ClassLibrary3.Interface;

namespace teste4
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            
            container.RegisterType<IAdicionarProduto, AdicionarProduto>();
            container.RegisterType<IEditarProduto, EditarProduto>();
            container.RegisterType<IExcluirProduto, ExcluirProduto>();
            container.RegisterType<ILocalizarID, LocalizarID>();
            container.RegisterType<IObterProdutos, ObterProdutos>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}