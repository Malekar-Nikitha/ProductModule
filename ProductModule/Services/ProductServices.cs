using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ProductModule.IServices;
using ProductModule.Models;
using System.Text;
using System.Timers;

namespace ProductModule.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ProductDBContext _context;

        public ProductServices(ProductDBContext context) 
        { 
            _context = context; 
        }
       // [Route("[api/ProductControlller]")]
        public async Task<string>AddNewProduct(Product product)
        {
            string result = "";
            try
            {
                if(product!=null)
                {
                    await _context.Products.AddAsync(product);
                    _context.SaveChanges();
                    result = "Product Added Successfully";

                }
                else
                {
                    result= "Product Not Added";
                }
                return result;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message); 
            }
            
        }

        public async Task<string> DeleteProduct(int productId)
        {
            Product product = _context.Products.Where(p => p.ProductId == productId).FirstOrDefault();
            try
            {
               if(product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    return "Product Removed";
                }
                else
                {
                    throw new Exception("Id is not found");
                }
                
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public async Task<string> GetCategoryName(string brandname)
        //{
        //    var brandnam = _context.
        //}
        public async Task<List<Product>> GetAllProducts(Product product)
        {

            var products = await _context.Products.ToListAsync();

            //var categeryname = await GetCategoryName(product);
            //if (product != null)
            //    return product;
            
                return products  ;
        }

        public async Task< Product> GetProductByBrand(string brand)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Brand.BrandName == brand);
                if (product != null)
                    return product;
                else
                    return null;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Product> GetProductByCategory(string category)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Category.CategoryName == category);
                if (product != null)
                    return product;
                else
                    return null;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            

            //var producr = await _context.Products.Where(p => p.Brand.Category.Contains(category));
        }

        public async Task <Product> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p =>p.ProductId==id);
            try
            {
                if (product != null)
                    return product;
                else
                    return null;
            }
            catch(Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<Product> GetProductBySearch(string productName,double price,string category,string brand)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(productName))
            {
                query = query.Where(p => p.ProductName == productName);
                
            }

            else if (price!=0)
            {
                query = query.Where(p => p.Price == price);
            }

            else if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category.CategoryName == category);  // Assuming Category is a navigation property
            }

            else if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(p => p.Brand.BrandName == brand);  // Assuming Brand is a field in the Product entity
            }

            // Execute the query and return the first matching product (or null if no match is found)
            return await query.FirstOrDefaultAsync();

        }

        public async Task<string> UpdateProduct(Product updateProduct)
        {
            string result = "";
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == updateProduct.ProductId);
                if (product != null)
                {
                    product.ProductName = updateProduct.ProductName;
                    product.Price = updateProduct.Price;
                    product.Description = updateProduct.Description;
                    product.StockQuatity = updateProduct.StockQuatity;
                    _context.SaveChanges();
                    result = "Product Updated";


                }
                else
                {
                    result = "Product not found";
                }
                return result;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
           

        }
    }
}
