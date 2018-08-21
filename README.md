# HtmlToPdfImage
It is base on dotnet core 2.0 ,which supports running on windows and linux .
It can transfer html to pdf and image for free .
Open broswer and visit http://xxxx:5001/api/html/image which can transfer html to image,and 
visit http://xxxx:5001/api/html/pdf ,which can transfer html to pdf.
Notes:
1.if you want to publish it to linux ,you should replace wwwroot\Wkhtmltox\wkhtmltoimage.exe with wwwroot\Linux\wkhtmltoimage.exe,
replace wwwroot\Wkhtmltox\wkhtmltopdf.exe with wwwroot\Linux\wkhtmltopdf.exe.
2.The folder you publish on linux should has high permission by executing command:run chmod -R 777 *

