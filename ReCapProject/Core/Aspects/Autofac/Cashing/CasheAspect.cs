using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Cashing;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Cashing
{
    public class CasheAspect : MethodInterception
    {
        private int _duration;
        private ICasheManager _casheManager;

        public CasheAspect(int duration = 60)
        {
            _duration = duration;
            _casheManager = ServiceTool.ServiceProvider.GetService<ICasheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_casheManager.isAdd(key))
            {
                invocation.ReturnValue = _casheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _casheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
