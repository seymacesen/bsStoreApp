using AutoMapper;
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
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger,IMapper mapper)
        {

            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, logger,mapper));
            //BookManager sınıfı, IBookService arayüzünün bir implementasyonudur ve oluşturulurken bir repositoryManager nesnesine ihtiyaç duyar.
        }
        public IBookService BookService => _bookService.Value;

    }
}
// Dependemcy inversion = Üst sınıflar alt sınıflara bağımlı olmamalıdır. bağlantı gerekliyse de interfaceler ile sağlanmalıdır.Repo  ve servisi interface manager nesnesi uzeri den oluştururyoruz. Servise loger eklersem ServiceManager üzerinde de bazı değişiklikler yapmamazı gerekiyor. Configurationlar devam eder.