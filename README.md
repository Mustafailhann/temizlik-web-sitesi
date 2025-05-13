# SoftCleaner – Temizlik Hizmetleri Web Sitesi

Bu proje, C# ile geliştirilmiş bir ASP.NET MVC web uygulamasıdır. Amaç, temizlik hizmetleri sunan bir şirketin müşteri, personel ve sipariş yönetimini web üzerinden yapmasını sağlamaktır.

## 🧰 Kullanılan Teknolojiler

- ASP.NET MVC 5
- Entity Framework
- Katmanlı Mimari (Business, DataAccess, Entities, UI)
- SQL Server
- Razor View Engine
- LINQ
- C#

## 📁 Katman Yapısı

- **UI** – Kullanıcı arayüzü (MVC)
- **Business** – İş mantığı katmanı
- **DataAccess** – Veri erişim katmanı
- **Entities** – Entity sınıfları

## 🚀 Kurulum ve Çalıştırma

1. Bu projeyi klonlayın veya zip olarak indirin:
   ```bash
   git clone https://github.com/Mustafailhann/temizlik-web-sitesi-demo.git
2.Visual Studio ile SoftCleaner.sln dosyasını açın.

3.web.config dosyasından veritabanı bağlantı cümlesini yapılandırın.

4.SQL Server'da gerekli tabloları oluşturun (migrations veya SQL script ile).

5.Ana proje olarak UI'ı seçin ve çalıştırın.

🧼 Özellikler
Müşteri kayıt ve giriş işlemleri

Temizlik hizmetlerinin listelenmesi

Sipariş oluşturma ve takibi

Personel yönetimi

Yorum ve değerlendirme sistemi

Katmanlı yapı ile sürdürülebilir mimari

✨ Geliştirme Önerileri
Admin paneline detaylı istatistikler eklenebilir

Hizmet rezervasyon takvimi entegre edilebilir

Email/SMS bildirim sistemi kurulabilir

Kullanıcı rollerine göre yetkilendirme yapılabilir
