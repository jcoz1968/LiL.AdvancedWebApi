using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApi.DI.CustomHandlers
{
    public class SessionIdHandler : DelegatingHandler
    {
        public static string SessionIdToken = "session-id-token";
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string sessionId;
            var cookie = request.Headers.GetCookies(SessionIdToken).FirstOrDefault();
            if(cookie == null)
            {
                sessionId = Guid.NewGuid().ToString();
            }
            else
            {
                sessionId = cookie["session-id-token"].Value;
                try
                {
                    Guid guid = Guid.Parse(sessionId);
                }
                catch (FormatException)
                {
                    sessionId = Guid.NewGuid().ToString();
                    throw;
                }
            }

            request.Properties[SessionIdToken] = sessionId;

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            response.Headers.AddCookies(new CookieHeaderValue[] { new CookieHeaderValue(SessionIdToken, sessionId) });
            return response;
        }
    }
}