using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //invocation :  business method
        /// <summary>
        /// Metho'un Başında çalışsın
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnBefore(IInvocation invocation) { }
        /// <summary>
        /// Methot'un sonunda Çalışsın
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnAfter(IInvocation invocation) { }
        /// <summary>
        /// Methot'un hata verdiğinde Çalışsın
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        /// <summary>
        /// Methot'un da her halükarda çalışacak
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }

}
