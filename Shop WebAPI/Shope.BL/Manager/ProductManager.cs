using AutoMapper;
using Shop.DAL;
using Shope.BL.Dto;
using Shope.DAL;
namespace Shope.BL
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepo _ProductRepo;
        public IMapper _Mapper;
        public ProductManager(IProductRepo ProductRepo, IMapper Mapper)
        {
            _ProductRepo = ProductRepo;
            _Mapper= Mapper;
        }

        public void Add(ProductDto entity)
        {
            var product = _Mapper.Map<Product>(entity);
            _ProductRepo.Add(product);
            _ProductRepo.SaveChanges();
            foreach (var productVersion in entity.Product_Versions)
            {
                var product_Version = _Mapper.Map<Product_Version>(productVersion);
                product_Version.Product=product;
                product.Product_Version.Add(product_Version);
                _ProductRepo.SaveChanges();
            }
        }
        public void Delete(string code)
        {
             _ProductRepo.Delete(code);
            _ProductRepo.SaveChanges();
        }

        public List<ProductDto> GetAll()
        {
            #region Declaration and intilalization 
            List<ProductDto> DtoProducts = new List<ProductDto>();
            List<Product> products = _ProductRepo.GetAll();
            #endregion
            // Mapping List Products to List ProductsDto to return it 
            DtoProducts = products.Select(p => _Mapper.Map<ProductDto>(p)).ToList();
            return DtoProducts;
        }

        public ProductDto? GetById(string code)
        {
            ProductDto productDto = new ProductDto();
            List<Product_Version> product_Versions = new List<Product_Version>();

            Product product = _ProductRepo.GetById(code);

            if (product != null)
            {
                productDto = _Mapper.Map<ProductDto>(product);
                productDto.Product_Versions = product.Product_Version.Select(pv => _Mapper.Map<Product_VersionDto>(pv)).ToList();
            }

            return productDto;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductDto entity)
        {
            Product product = _ProductRepo.GetById(entity.Code);
            if (product != null)
            {
                _Mapper.Map(entity, product);
                entity.Product_Versions = product.Product_Version.Select(pv => _Mapper.Map<Product_VersionDto>(pv)).ToList(); 
                _ProductRepo.Update(product);
            }
            else
            {
                throw new Exception("This Product Not Found");
            }
        }
    }
}
