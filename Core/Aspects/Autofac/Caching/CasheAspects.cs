using Castle.DynamicProxy;
using Core.CrossCutingConcern.Cashing;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CasheAspects:MethodInterception
    {
       private int _duration;
        private ICacheManager _cacheManager;//hangi cachemanager i kullanacaksin
        public CasheAspects(int duration=60)
        { 
           _duration=duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//key degerinin baslangici
            var arguments = invocation.Arguments.ToList();//parametreler
            var key = $"{methodName}({string.Join(",",arguments.Select(x=> x?.ToString()??"<Null>"))})";
            if(_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue=_cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
