using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>//Class'ın attirbute'larını getirir. Cache log vs.
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)//Metot'un attirbute'larını getirir. Cache, log vs.
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(x => x.Priority).ToArray();//Attirbute'ları öncelik sırasına göre sıralar.
        }
    }
}