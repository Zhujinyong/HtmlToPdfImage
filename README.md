# HtmlToPdfImage
###    It is base on wkhtmltox and dotnet core 2.0 which supports running on windows and linux which can transfer html to pdf and image for free .

### Open broswer and visit <a href="http://xxxx:5001/api/html/image">http://xxxx:5001/api/html/image</a> which can transfer html to image.

<img src="/HtmlToImagePdf/wwwroot/Image/image.png"  alt="transform Html to image" width="550" height="300"  />

### And visit <a href="http://xxxx:5001/api/html/pdf">http://xxxx:5001/api/html/pdf</a> which can transfer html to pdf.
<img src="/HtmlToImagePdf/wwwroot/Image/pdf.png"  alt="transform Html to pdf" width="600" height="300"  />

### Notes:
* if you want to publish it to linux ,you should replace wwwroot\Wkhtmltox\wkhtmltoimage.exe with wwwroot\Linux\wkhtmltoimage.exe,
replace wwwroot\Wkhtmltox\wkhtmltopdf.exe with wwwroot\Linux\wkhtmltopdf.exe.
* The folder you publish on linux should has high permission by executing command: chmod -R 777 *

