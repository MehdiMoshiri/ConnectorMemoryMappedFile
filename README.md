# ConnectorMemoryMappedFile
Demonstrates how to integrate with our scale software via Windows MemoryMappedFile. The application writes Weight, Length, ScaleNumber, and a UTC Timestamp into shared memory, enabling external systems to read real-time data without network communication or temporary files. Ideal for high-performance industrial environments.


معرفی

در این پروژه نحوه ارتباط با نرم‌افزار ترازو Connector از طریق MemoryMappedFile توضیح داده شده است.


دوستان برای اینکه بدانید این روش انتقال داده چطور کار میکنه می تونید نمونه کد و توضیحات رو در لینک زیر مشاهده نمایید 
https://github.com/MehdiMoshiri/Memory-Mapped-Files


نرم‌افزار اصلی ما اطلاعات زیر را در حافظه مشترک ذخیره می‌کند:

استمپ زمان (UTC)  -  نوع long

وزن (Weight) — نوع double

متراژ (Length) — نوع double

شماره ترازو (ScaleNumber) — نوع int


سایر نرم‌افزارها می‌توانند این اطلاعات را بدون نیاز به فایل یا شبکه، مستقیماً از حافظه بخوانند.

🔧 نام حافظه مشترک برای ترازوی اول می باشد و برای ترازو های بعدی 2 و3  
Global\ConnectorMemory1

⚠️ توجه:

در صورت استفاده از سیستم چندکاربره یا سرویس ویندوز، استفاده از پیشوند Global\ ضروری است.
 
 ✅ ساختار حافظه
Offset	Type	Size            	توضیح
0	      long	  8          	Timestamp (UTC Ticks)
8	    double	  8	          Weight
16	   double 	8         	Length
24	      int 	4         	ScaleNumber

مجموع: 28 بایت


✅نمونه کد خواندن وزن به زبان سی شارپ و نمونه پروژه سی شارپ در این ریپازیتوری قرار میگیرد 

⚙ نکات مهم

نرم‌افزار Connector  باید قبل از نرم افزار شما اجرا شده باشد.

اگر Map پیدا نشد، خطا دریافت خواهید کرد.

در صورت توسعه آینده (اضافه شدن فیلد جدید)، Offset ها باید به‌روزرسانی شوند.




