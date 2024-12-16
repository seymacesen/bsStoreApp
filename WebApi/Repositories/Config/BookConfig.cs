using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Repositories.Config
{
    public class BookConfig:IEntityTypeConfiguration<Book>
    {
       public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Karagöz ve Hacivat", Price = 75 },
                new Book { Id = 2, Title = "Soytarı Çiçekleri", Price = 100 },
                new Book { Id = 3, Title = "Beni Asla Bırakma", Price = 150 }
                );
        }
    
    }
}
