using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;


namespace Core.Utilities.Interceptors
{
   


    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> //Classın attributlerini oku
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name) //Metotun attributlerini oku
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);


            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); // Otomatik olarak sistemdeki tüm metotları loga dahil et.

            return classAttributes.OrderBy(x => x.Priority).ToArray();


        }
    }

}
