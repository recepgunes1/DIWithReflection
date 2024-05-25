# DIWithReflection

Bu proje, .NET uygulamasında Reflection kullanarak Dependency Injection (DI) servislerini yönetmeyi göstermektedir. Aşağıdaki adımları takip ederek projeyi kurabilir ve test edebilirsiniz.

## Kurulum
1. Repoyu klonlayın:
   ```sh
   git clone https://github.com/recepgunes1/DIWithReflection.git
   cd DIWithReflection
   ```

2. .NET bağımlılıklarını yükleyin:
   ```sh
   dotnet restore
   ```

3. Projeyi derleyin:
   ```sh
   dotnet build
   ```

## Kullanım
1. `Program.cs` dosyasında servislerinizi kaydetmek için aşağıdaki örnekte olduğu gibi istediğiniz extension metodunuzu çağırın:
   ```csharp
   using Business;

   var builder = WebApplication.CreateBuilder(args);

   // Extension method ile servisleri kaydet
   builder.Services.LoadServicesUsingReflectionWithLifeTime_Strict();

   var app = builder.Build();

   // Endpoints

   app.Run();
   ```

2. Uygulama endpoint'lerini test etmek için sağlanan bash scriptini kullanabilirsiniz. Uygulama çalışırken scripti çalıştırın:
   ```sh
   bash api_requests.sh
   ```

---

Bu talimatları takip ederek `DIWithReflection` projesini kurabilir, kullanabilir ve test edebilirsiniz. İyi çalışmalar!
