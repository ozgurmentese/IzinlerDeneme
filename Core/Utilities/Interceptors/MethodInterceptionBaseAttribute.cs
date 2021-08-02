using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    /// <summary>
    /// class'lara methodlara ekleyebilirsin
    /// Bir methot veya class'a birden fazla attribüt yazabilrisin. Örnğ; 
    /// IInvocation Method demek (Castle.DynamicProxy; dan geliyor)
    /// Priority(Öncelik demek) önce hangi attribüt çalışsın
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

}
