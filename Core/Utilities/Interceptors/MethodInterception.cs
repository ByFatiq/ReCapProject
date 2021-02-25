using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {//invocation - Çağrı çağırmak metot anlamına gelir.
            //
            var isSuccess = true;
            OnBefore(invocation); //ilk çalışacak metot.
            try
            {
                invocation.Proceed();//Devam ettir.
            }
            catch (Exception e)
            {
                isSuccess = false; 
                OnException(invocation, e);// Hata var ise burayı çalıştır.
                throw;
            }
            finally
            {
                if (isSuccess) // Çalışsa da hata da verse bu blog çalışır.
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation); // Tüm işlemler gerçekleştikten sonra en son çalışmasını istediğimiz birşey varsa burası çalışır.
        }
    }
}
