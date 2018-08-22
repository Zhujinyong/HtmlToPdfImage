using Lib.HtmlToPdfImage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Web.HtmlToImagePdf.Controllers
{
    [Route("api/[controller]")]
    public class HtmlController : Controller
    {
        /// <summary>
        /// save image on server and response as image
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet("image")]
        public IActionResult Image(string url = "http://news.baidu.com")
        {
            // way 1:
            //ViewData["Message"] = "Your application description page.";
            //var model = new TestModel { Name = "Giorgio" };
            //var image= new ViewAsImage("About",model);
            //image.PageWidth = 800;
            //image.PageHeight = 600;
            //return image;

            //way 2:
            var image = new UrlAsImage(url);
            image.SaveOnServerPath = Path.Combine("wwwroot/files/image", DateTime.Now.ToString("yyyyMMddhhmmss") + ".png");
            return image;
        }

        /// <summary>
        /// save image to server and return savePath not image
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet("imagefile")]
        public async Task<object> ImageFile(string url = "http://news.baidu.com")
        {
            var image = new UrlAsImage(url);
            var path= Path.Combine("wwwroot/files/image", DateTime.Now.ToString("yyyyMMddhhmmss") + ".png");
            image.SaveOnServerPath = path;
            await image.BuildFile(url);
            return new { FileName = path };

        }

        /// <summary>
        /// return pdf without saving to server
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet("pdf")]
        public IActionResult Pdf(string url = "http://news.baidu.com")
        {
            var pdf = new UrlAsPdf(url);
            //pdf.SaveOnServerPath = Path.Combine("wwwroot/files/image", DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf");
            return pdf;
        }
    }
}
