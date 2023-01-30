using Shop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL
{
    public interface IProductRepo
    {
        List<Product> GetAll();
        Product? GetById(string code);
        void Add(Product entity);
        void Update(Product entity);
        void Delete(string code);
        void SaveChanges();
    }
}
