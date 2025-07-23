# ASP.NET Core Backend Projesi

Bu proje, basit bir jwt token doğrulama ile etkinlik ekleyebileceğiniz ve silme,güncelleme işlemlerinizi yapabilmek için geliştirilmiş bir ASP.NET Core backend uygulamasıdır.

## Özellikler

- [Özellik 1] (Örnek: JWT tabanlı kimlik doğrulama)
- [Özellik 2] (Örnek: Entity Framework Core ile veritabanı entegrasyonu)
- [Özellik 3] (Örnek: Swagger/OpenAPI desteği)
- [Özellik 4] (Örnek: RESTful API endpoint'leri)


## Teknoloji Yığını

- **Backend Framework**: ASP.NET Core 9.0
- **Veritabanı**: SQLite
- **ORM**: Entity Framework Core
- **Kimlik Doğrulama**: JWT Bearer Token
- **API Dokümantasyon**: Swagger UI
- **Diğer Kütüphaneler**: Google.Apis.Auth,Google.Apis.Calendar

## Kurulum

### Gereksinimler

- [.NET Core SDK](https://dotnet.microsoft.com/download) (versiyon: 9.0)
- Sqlite (https://sqlitebrowser.org/)
-  VS Code

### Adımlar

1. **Depoyu klonlayın** 
     git clone [https://github.com/MehmetUlDG/DepomYeni/tree/main/ToDoApp]
     cd ToDoApp
2. **Bağımlılıkları yükleyin** 
     dotnet restore
     # Dikkat! Google OAuth ve Calendar paketleri uygulamanın güncel haliyle gerek yoktur ama bu paketlere ait sınıflar ayrı olarak verilebilir.(Geliştirme amaçlı)  

 3. **Veritabanı ayarlamasını yapın**
  # appsettings.json dosyasındaki connection string'i düzenleyin
  # Migration'ları çalıştırın:
    dotnet ef database update

 4. **Uygulamayı çalıştırın**
      dotnet run   

 5. **Api Dökümentasyonu için**
 # Tarayıcıda aşağıdaki URL'i açın:
  https://localhost:5144/Swagger

6. **OAuth 2 bağlantısı için**
  # Tarayıcıda aşağıdaki URL'i açın:
  https://console.cloud.google.com/

# Ardından hesap oluşturunuz:
# New Project – Google Cloud Console sayfası üzerinden uygulamanız için Google Cloud’da bir proje oluşturunuz.
- Projeyi oluşturduktan sonra API&Services seçeneği üzerinden ‘Credentials’ sekmesine geliniz ve ardından ‘Create Credentials’ butonuna oradan da açılan pencereden ‘OAuth client ID’ sekmesine tıklayınız.

- Açılan sayfada izin ekranını yapılandırabilmek için sağ taraftaki ‘Configure Consent Screen’ butonuna tıklayınız.

- Asp.NET Core  Eşliğinde Google Login Ardından açılan sayfada aşağıdaki gibi ‘External’i seçerek ilerleyiniz.

- Devamında uygulama bilgilerine dair gelen sayfada aşağıdaki gibi basitçe alanları doldurmak şimdilik yeterli olacaktır.

- Sonra tüm sayfaları hızlıca geçebilirsiniz.

- Artık tekrardan ‘Credentials’ sekmesine gelip ‘Create Credentials’ butonu üzerinden ‘OAuth client ID’ sekmesine tıklarsanız artık bir ‘OAuth client ID’ tanımlama fırsatı elde edebileceksiniz.

- Authorized JavaScript bölümüne uygulamanın ayağa kalktığı https://localhost:5144 portumuzu yazıyoruz.Eğer local’de çalışma sergiliyorsanız, Google Cloud üzerinde tanımlama yaparken tıpkı buradaki gibi port’suz bir bildiride de bulunmayı ihmal etmeyiniz. Bu tanımlamalardan sonra ‘Create’ neticesinde Google API sizlere client id ve client secret keyleri verecektir.

- Client id ve client secret keylerini program.cs dosyasında YOUR_OAUTH_CLIENT_ID ve YOUR_OAUTH_CLIENT_SECRET yerine yazıyoruz.

- Artık swagger üzerinden bu api isteklerine client id ve client secret keyleri ulaşabiliriz.(Test kullanıcıları arasına kendi hesabınızı ekleyip google login ve google calendar api isteklerini kullanabilirsiniz.)

