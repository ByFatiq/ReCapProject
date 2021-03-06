﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Core.Utilities.Interceptors;


namespace Business.DependencyResolvers.Autofac
{
   public class AutofacBussinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {//Servisi kullanarak Manager'ı instanse'ını atıyor. yani newleyerek objeyi veriyor.
            
            
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); // Çalışan Uygulama içerisine bak 

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()// içerisinde kayıtlı interfaceleri bul ve onlar için 
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector() // AspectInterceptor'u çağır. 
                }).SingleInstance();

            //Genel olarak 
        }
    }
}
