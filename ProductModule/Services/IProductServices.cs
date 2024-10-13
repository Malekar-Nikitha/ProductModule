using ProductModule.Models;

namespace ProductModule.IServices
{
    public interface IProductServices
    {
       Task<string> AddNewProduct(Product product);
        Task<string> UpdateProduct(Product updateProduct);
        Task<string> DeleteProduct(int productId);
        Task<List<Product>> GetAllProducts(Product product);
        Task<Product> GetProductById(int id);
       Task< Product> GetProductByCategory(string category);
        Task<Product> GetProductByBrand(string brand);
        Task<Product> GetProductBySearch(string productName,double price,string category,string brand);
    }
}
