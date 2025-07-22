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