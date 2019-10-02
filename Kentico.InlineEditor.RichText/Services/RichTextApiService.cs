﻿using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using CMS;

using Kentico.Components.Web.Mvc.InlineEditors;
using Kentico.Content.Web.Mvc;
using Kentico.Web.Mvc;

[assembly: RegisterImplementation(typeof(IRichTextApiService), typeof(RichTextApiService))]

namespace Kentico.Components.Web.Mvc.InlineEditors
{
    internal sealed class RichTextApiService : IRichTextApiService
    {
        private const string RICH_TEXT_API_ENDPOINT = "api/RichText";


        public void MapEndpointRoute(RouteCollection routeCollection)
        {
            routeCollection.MapHttpRoute(
                name: "RichTextApi",
                routeTemplate: RICH_TEXT_API_ENDPOINT,
                defaults: new { controller = "RichText", action = "GetPage" }
            );
        }


        public string GetApiEndpointUrl(UrlHelper urlHelper)
        {
            urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));

            return urlHelper.Kentico().AuthenticateUrl($"~/{RICH_TEXT_API_ENDPOINT}").ToString();
        }
    }
}
