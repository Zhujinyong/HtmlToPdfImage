using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace Lib.HtmlToPdfImage
{
    public static class WkhtmltoxConfig
    {
        private static string _WkhtmltoxPath;
        internal static string WkhtmltoxPath
        {
            get
            {
                if (string.IsNullOrEmpty(_WkhtmltoxPath))
                {
#if NET45
                    _RotativaUrl = System.Configuration.ConfigurationManager.AppSettings["RotativaUrl"];
#endif
                }
                return _WkhtmltoxPath;
            }
        }
        /// <summary>
        /// Setup wkhtmltox library
        /// </summary>
        /// <param name="env">The IHostingEnvironment object</param>
        /// <param name="wkhtmltopdfRelativePath">Optional. Relative path to the directory containing wkhtmltopdf.exe. Default is "Rotativa". Download at https://wkhtmltopdf.org/downloads.html</param>
        public static void Setup(IHostingEnvironment env, string wkhtmltopdfRelativePath = "Wkhtmltox") 
        {
            var wkhtmltoxPath = Path.Combine(env.WebRootPath, wkhtmltopdfRelativePath);
            if (!Directory.Exists(wkhtmltoxPath))
            {
                throw new ApplicationException("Folder containing wkhtmltopdf.exe not found, searched for " + wkhtmltoxPath);
            }
            _WkhtmltoxPath = wkhtmltoxPath;
        }

    }
}
