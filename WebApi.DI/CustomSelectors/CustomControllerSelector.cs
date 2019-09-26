using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebApi.DI.Custom
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        public CustomControllerSelector(HttpConfiguration configuration) : base(configuration)
        {

        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controllers = GetControllerMapping();
            var routeData = request.GetRouteData();

            var controllerName = routeData.Values["controller"].ToString();

            string versionNumber = "1";

            //var versionQuery = HttpUtility.ParseQueryString(request.RequestUri.Query);

            //if(versionQuery["v"] != null)
            //{
            //    versionNumber = versionQuery["v"];
            //}

            string customHeaderName = "X-Employee-Version";

            if(request.Headers.Contains(customHeaderName))
            {
                versionNumber = request.Headers.GetValues(customHeaderName).FirstOrDefault();
            }

            if(versionNumber == "1")
            {
                controllerName = controllerName + "V1";
            }
            else
            {
                controllerName = controllerName + "V2";
            }

            HttpControllerDescriptor controllerDescriptor;
            if(controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }
            return null;
        }
    }
}