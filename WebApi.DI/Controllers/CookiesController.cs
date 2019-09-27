using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApi.DI.Controllers
{
    public class CookiesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();

            var cookie = new CookieHeaderValue("session-id-cookie", "12345");
            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            response.Headers.AddCookies(new CookieHeaderValue[] { cookie });

            return response;
        }

        [Route("api/getcookiedata")]
        public IHttpActionResult GetCookieData()
        {
            string sessionId = "";
            CookieHeaderValue cookie = Request.Headers.GetCookies("session-id-cookie").FirstOrDefault();
            if(cookie != null)
            {
                sessionId = cookie["session-id-cookie"].Value;
            }
            return Ok(sessionId);
        }
    }
}
