using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Cashing;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Cashing
{
    public class CasheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICasheManager _cacheManager;

        public CasheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICasheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
