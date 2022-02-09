using Stockmain.Data;
using Stockmain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stockmain.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;
        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
        }

        public bool ProductExists(int  id)
        {
            return _productContext.Stock.Any(p => p.ID_PRODUCTO == id);
        }

        public List<Product> GetProducts()
        {
            return _productContext.Stock.ToList();
        }

        public Product GetProduct(int  id)
        {
            return _productContext.Stock.Where(p => p.ID_PRODUCTO == id).First();
        }

        public bool DeleteProduct(int  id)
        {
            var product = GetProduct(id);
            _productContext.Stock.Remove(product);
            return Save();
        }

        public Product EnterProduct(Product newProduct)
        {
            var product = _productContext.Add(newProduct);
            Save();
            return product.Entity;
        }

        public Product UpdateProduct(Product newProduct)
        {
            if (!ProductExists(newProduct.ID_PRODUCTO)) { return null; }
            else
            {
                var product = GetProduct(newProduct.ID_PRODUCTO);
                _productContext.Entry(product).CurrentValues.SetValues(newProduct);
                Save();
                return GetProduct(newProduct.ID_PRODUCTO);
            }
        }
        public bool Save()
        {
            return _productContext.SaveChanges() > 0;
        }

        
    }
}
