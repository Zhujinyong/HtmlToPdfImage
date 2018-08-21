using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Lib.HtmlToPdfImage
{
    public class ViewAsImage : AsImageResultBase
    {
        private string viewName;



        public new string ViewName
        {
            get => this.viewName ?? string.Empty;
            set => this.viewName = value;
        }

        private string masterName;

        public string MasterName
        {
            get => this.masterName ?? string.Empty;
            set => this.masterName = value;
        }

        public new object Model { get; set; }

        public ViewAsImage()
        {
            this.WkhtmlPath = string.Empty;
            this.MasterName = string.Empty;
            this.ViewName = string.Empty;
            this.Model = null;
        }

        public ViewAsImage(string viewName)
            : this()
        {
            this.ViewName = viewName;
        }

        public ViewAsImage(object model)
            : this()
        {
            this.Model = model;
        }

        public ViewAsImage(string viewName, object model)
            : this()
        {
            this.ViewName = viewName;
            this.Model = model;
        }

        public ViewAsImage(string viewName, string masterName, object model)
            : this(viewName, model)
        {
            this.MasterName = masterName;
        }

        protected override string GetUrl(ActionContext context)
        {
            return string.Empty;
        }

        protected virtual ViewEngineResult GetView(ActionContext context, string viewName, string masterName)
        {
            var engine = context.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
            return engine.FindView(context, viewName, true);
        }

        protected override async Task<byte[]> CallTheDriver(ActionContext context)
        {
            // use action name if the view name was not provided
            string viewName = ViewName;
            if (string.IsNullOrEmpty(ViewName))
            {
                viewName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            }

            ViewEngineResult viewResult = GetView(context, viewName, MasterName);
            var html = new StringBuilder();

            //string html = context.GetHtmlFromView(viewResult, viewName, Model);
            ITempDataProvider tempDataProvider = context.HttpContext.RequestServices.GetService(typeof(ITempDataProvider)) as ITempDataProvider;

            var viewDataDictionary = new ViewDataDictionary(
                metadataProvider: new EmptyModelMetadataProvider(),
                modelState: new ModelStateDictionary())
            {
                Model = this.Model
            };
            if (this.ViewData != null)
            {
                foreach (var item in this.ViewData)
                {
                    viewDataDictionary.Add(item);
                }
            }
            using (var output = new StringWriter())
            {
                var view = viewResult.View;
                var tempDataDictionary = new TempDataDictionary(context.HttpContext, tempDataProvider);
                var viewContext = new ViewContext(
                    context,
                    viewResult.View,
                    viewDataDictionary,
                    tempDataDictionary,
                    output,
                    new HtmlHelperOptions());

                await view.RenderAsync(viewContext);

                html = output.GetStringBuilder();
            }


            string baseUrl = string.Format("{0}://{1}", context.HttpContext.Request.Scheme, context.HttpContext.Request.Host);
            var htmlForWkhtml = Regex.Replace(html.ToString(), "<head>", string.Format("<head><base href=\"{0}\" />", baseUrl), RegexOptions.IgnoreCase);

            byte[] fileContent = WkhtmltoimageDriver.ConvertHtml(this.WkhtmlPath, this.GetConvertOptions(), htmlForWkhtml);
            return fileContent;
            // use action name if the view name was not provided
            //string viewName = this.ViewName;
            //if (string.IsNullOrEmpty(viewName))
            //{
            //    viewName = context.ActionDescriptor.DisplayName;
            //}

            //ViewEngineResult viewResult = this.GetView(context, viewName, this.MasterName);
            //string html = context.GetHtmlFromView(viewResult, viewName, this.Model);
            //byte[] fileContent = WkhtmltoimageDriver.ConvertHtml(this.WkhtmlPath, this.GetConvertOptions(), html);
            //return fileContent;
        }
    }
}