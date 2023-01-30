using Shop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shope.DAL
{
    public class ProductRepo : IProductRepo
    {
        private readonly ShopeContext _context;

        public ProductRepo(ShopeContext context)
        {
            _context = context;
        }


        public void Add(Product entity)
        {
            _context.Set<Product>().Add(entity);
        }

        public void Delete(string code )
        {
            var product = _context.Product.Find(code);
            _context.Product_Version.RemoveRange(_context.Product_Version.Where(x => x.Code == product.Code));
            _context.Remove(product);
        }

        public List<Product> GetAll()
        {
            return _context.Set<Product>().ToList();
        }

        public Product? GetById(string code)
        {
            Product product = _context.Set<Product>().Find(code);
            if (product != null)
            {
                List<Product_Version> product_Versions = _context.Set<Product_Version>().Where(product_Version => product_Version.Code == code).ToList();
                product.Product_Version = product_Versions;
            }
            return product;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Product entity)
        {
            var existingProduct = _context.Set<Product>().Find(entity.Code);
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(entity);
            var existingProductVersions = existingProduct.Product_Version.ToList();
            var updatedProductVersions = entity.Product_Version.ToList();

            //removing deleted product versions
            for (int i = 0; i < existingProductVersions.Count; i++)
            {
                var existingVersion = existingProductVersions[i];
                if (!updatedProductVersions.Any(p => p.Code == existingVersion.Code))
                {
                    _context.Product_Version.Remove(existingVersion);
                }
            }

            //updating or adding new product versions
            for (int i = 0; i < updatedProductVersions.Count; i++)
            {
                var updatedVersion = updatedProductVersions[i];
                var existingVersion = existingProductVersions.SingleOrDefault(p => p.Code == updatedVersion.Code);
                if (existingVersion != null)
                {
                    _context.Entry(existingVersion).CurrentValues.SetValues(updatedVersion);
                }
                else
                {
                    existingProduct.Product_Version.Add(updatedVersion);
                }
            }
            _context.SaveChanges();

        }
    }
}
