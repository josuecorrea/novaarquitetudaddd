using Arquitetura.Aplicacao.Services;
using Arquitetura.Aplicacao.Services.Interface;
using Arquitetura.Dominio.Repositories.Interfaces;
using Arquitetura.Infraestrutura.Adapter;
using Arquitetura.Infraestrutura.Logging;
using Arquitetura.Infraestrutura.Repositories;
using Arquitetura.Infraestrutura.UnitOfWork;
using Arquitetura.Infraestrutura.Validator;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arquitetura.Web
{
    public class DependencyResolverConfig
    {
        private static UnityContainer _container;

        public static void RegisterDependency()
        {
            // criando nosso container de dependencias e registrando uma dependencia de exemplo.
            _container = new UnityContainer();
            _container.AddNewExtension<Interception>();

            //-> Unit of Work and repositories
            _container.RegisterType(typeof(MainBCUnitOfWork), new PerResolveLifetimeManager());

            _container.RegisterType(typeof(ITypeAdapterFactory), typeof(AutomapperTypeAdapterFactory));
            var typeAdapterFactory = _container.Resolve<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);

            #region RegisterType

            // Repositórios
            _container.RegisterType(typeof(IMunicipioRepository), typeof(MunicipioRepository));

            // Serviços
            _container.RegisterType(typeof(IMunicipioAppService), typeof(MunicipioAppService));//.Configure<Interception>().SetInterceptorFor<IUsuarioAppService>(new InterfaceInterceptor());

            #endregion

            //modificando o DependencyResolver para a nossa customização passando o container.
            DependencyResolver.SetResolver(new UnityDependencyResolver(_container));

            LoggerFactory.SetCurrent(new EmailTraceSourceLogFactory());
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
        }
    }
}