using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnExeption(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        //OnBefore demek metod calismadan once sen calis demek
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
             
            }

            catch(Exception e)
            {
                isSuccess = false;
                OnExeption(invocation);
                throw;
            }
            finally { 
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }

            }
            OnAfter(invocation);
        }
    }
}
