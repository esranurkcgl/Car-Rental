using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            containerBuilder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            containerBuilder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            containerBuilder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            containerBuilder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            containerBuilder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance(); 
            containerBuilder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            containerBuilder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            containerBuilder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            containerBuilder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            containerBuilder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            containerBuilder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            containerBuilder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            containerBuilder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            containerBuilder.RegisterType<AuthManager>().As<IAuthService>();
            containerBuilder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            containerBuilder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
