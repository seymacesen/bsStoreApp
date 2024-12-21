using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EFCore;

namespace WebApi.ContextFactroy
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext> //esign-time (tasarım zamanı) sırasında bir DbContext nesnesi oluşturmak için kullanılır.
    {
        public RepositoryContext CreateDbContext(string[] args) //metot, design-time sırasında bir RepositoryContext nesnesi oluşturur ve döner.
        {
            var configuration = new ConfigurationBuilder() //Bu sınıf, appsettings.json dosyasından yapılandırma ayarlarını okumak için kullanılır.
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build(); //Yapılandırmayı derler ve bir IConfiguration nesnesi oluşturur.

            //DbConextOptionBuilder
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),//appsettings.json dosyasındaki DefaultConnection connStringi alır ve dB bağlantısını yapılandırır.
                prj =>prj.MigrationsAssembly("WebApi"));//Migration dosyalarının hangi projede oluşturulacağını belirtir. WebApi projesinde oluşturulacaktır.
            return new RepositoryContext(builder.Options);/*builder.Options:
            DbContextOptionsBuilder ile yapılandırılmış DbContextOptions nesnesidir.
            RepositoryContext nesnesine bu seçenekler aktarılır.*/

        }
    }
}
