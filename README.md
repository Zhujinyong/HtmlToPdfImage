# HtmlToPdfImage
###    It is base on dotnet core 2.0 ,which supports running on windows and linux which can transfer html to pdf and image for free .

### Open broswer and visit <a href="http://xxxx:5001/api/html/image">http://xxxx:5001/api/html/image</a> which can transfer html to image,and visit <a href="http://xxxx:5001/api/html/pdf">http://xxxx:5001/api/html/pdf</a> which can transfer html to pdf.

### Notes:
* if you want to publish it to linux ,you should replace wwwroot\Wkhtmltox\wkhtmltoimage.exe with wwwroot\Linux\wkhtmltoimage.exe,
replace wwwroot\Wkhtmltox\wkhtmltopdf.exe with wwwroot\Linux\wkhtmltopdf.exe.
* The folder you publish on linux should has high permission by executing command:run chmod -R 777 *

