using BlazingShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Services
{
    public class ProductService
    {
        //Connect to Database
        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        // Get Product item from database
        public Product GetProduct(int productId)
        {
            Product obj = new Product();
            return _db.Products.Include(u => u.Category).FirstOrDefault(u => u.Id == productId);
        }

        // Get Product items list from database
        public List<Product> GetProducts()
        {
           return _db.Products.Include(u => u.Category).ToList();        
        }

        // Get Category items list from database
        public List<Category> GetCategoryList()
        {
            return _db.Categories.ToList();
        }

        // Create New Product
        public bool CreateProduct(Product objProduct)
        {
            _db.Products.Add(objProduct);
            _db.SaveChanges();
            return true;
        }

        // Update Product
        public bool UpdateProduct(Product objProduct)
        {
            var ExistingProduct = _db.Products.FirstOrDefault(u => u.Id == objProduct.Id);
            if (ExistingProduct != null)
            {
                if (objProduct.Image == null)
                {
                    objProduct.Image = ExistingProduct.Image;
                }
                _db.Products.Update(objProduct);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }            
            return true;
        }

        public bool DeleteProduct(Product objProduct)
        {
            var ExistingProduct = _db.Products.FirstOrDefault(u => u.Id == objProduct.Id);
            if (ExistingProduct != null)
            {
                _db.Products.Remove(ExistingProduct);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;

        }
    }
}
