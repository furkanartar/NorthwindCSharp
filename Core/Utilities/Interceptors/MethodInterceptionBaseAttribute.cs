using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)] //class, metotlara uygulanabilen attirbute.
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //Cache, log falan hangisi önce olsun diye sıralama yapmamızı sağlıyor

        public virtual void Intercept(IInvocation invocation)//Invocation metot demek.
        {

        }
    }
}