using Stockmain.Data.Entities;
using Stockmain.Models;
using System;
using System.Collections.Generic;

namespace Stockmain.Services
{
    public interface IProductRepository
    {
        public bool ProductExists(int  id);


        public List<Product> GetProducts();

        public Product GetProduct(int  id);

        public bool DeleteProduct(int  id);

        public Product EnterProduct(Product newProduct);

        public Product UpdateProduct(Product newProduct);

    }
}