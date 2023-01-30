using Shop.DAL;
using Shope.BL.Dto;

namespace Shope.BL
{
    public interface IProductManager
    {
        List<ProductDto> GetAll();
        ProductDto? GetById(string code);
        void Add(ProductDto entity);
        void Update(ProductDto entity);
        void SaveChanges();
        void Delete(string code);
    }
}
