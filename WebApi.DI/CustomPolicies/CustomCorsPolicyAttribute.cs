using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace WebApi.DI.CustomPolicies
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CustomCorsPolicyAttribute : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;

        public CustomCorsPolicyAttribute()
        {
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true,
            };

            _policy.Origins.Add("http://test.com");
            _policy.Origins.Add("http://localhost:58969");
        }
        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}