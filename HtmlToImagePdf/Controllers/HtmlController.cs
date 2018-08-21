using Lib.HtmlToPdfImage;
using Microsoft.AspNetCore.Mvc;

namespace Web.HtmlToImagePdf.Controllers
{
    [Route("api/[controller]")]
    public class HtmlController : Controller
    {
        /// <summary>
        /// GET api/html
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet("image")]
        public IActionResult Image(string url = "http://news.baidu.com")
        {
            //第一种，传视图
            //ViewData["Message"] = "Your application description page.";
            //var model = new TestModel { Name = "Giorgio" };
            //var image= new ViewAsImage("About",model);
            //image.PageWidth = 800;
            //image.PageHeight = 600;
            //return image;

            //第二种，传Url
            var image = new UrlAsImage(url);
            // image.PageWidth = 800;
            // image.PageHeight = 600;
            return image;
        }

        /// <summary>
        /// GET api/html
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet("pdf")]
        public IActionResult Pdf(string url = "http://news.baidu.com")
        {
            var pdf = new UrlAsPdf(url);
            return pdf;
        }

    }
}
