using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<PersonelManager>().As<IPersonelService>().SingleInstance();
            builder.RegisterType<EfPersonelDal>().As<IPersonelDal>().SingleInstance();
            
            builder.RegisterType<PersonelIzinManager>().As<IPersonelIzinService>().SingleInstance();
            builder.RegisterType<EfPersonelIzinDal>().As<IPersonelIzinDal>().SingleInstance();
            
            builder.RegisterType<PersonelRaporManager>().As<IPersonelRaporService>().SingleInstance();
            builder.RegisterType<EfPersonelRaporDal>().As<IPersonelRaporDal>().SingleInstance();
            

         

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
