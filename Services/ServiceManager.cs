using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;

        /*ServiceManager, servisler için gerekli olan repository'lere erişmek zorundadır.
        Repository'ler bir RepositoryManager nesnesi üzerinden yönetildiği için bu nesne,
        constructor aracılığıyla ServiceManager'a geçirilir.*/
        public ServiceManager(IRepositoryManager repositoryManager)
        {

            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager));
            //BookManager sınıfı, IBookService arayüzünün bir implementasyonudur ve oluşturulurken bir repositoryManager nesnesine ihtiyaç duyar.
        }
        public IBookService BookService => _bookService.Value;

    }
}
