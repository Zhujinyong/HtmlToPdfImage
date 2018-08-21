using System;

using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Lib.HtmlToPdfImage
{
    public class UrlAsPdf : AsPdfResultBase
    {
        private readonly string url;

        public UrlAsPdf(string url)
        {
            this.url = url ?? string.Empty;
        }

        protected override string GetUrl(ActionContext context)
        {
            string urlLower = this.url.ToLower();
            if (urlLower.StartsWith("http://") || urlLower.StartsWith("https://"))
            {
                return this.url;
            }

            var currentUri = new Uri(context.HttpContext.Request.GetDisplayUrl());
            var authority = currentUri.GetComponents(UriComponents.StrongAuthority, UriFormat.Unescaped);

            var url = string.Format("{0}://{1}{2}", context.HttpContext.Request.Scheme, authority, this.url);
            return url;
        }
    }
}