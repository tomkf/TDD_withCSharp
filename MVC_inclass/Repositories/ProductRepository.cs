using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_inclass.Models;
using MVC_inclass.Repositories;

namespace MVC_inclass.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // Here we create some fake data to make thigs easier but 
        // this could be swapped out easily so the application connects
        // to a live database.
        private static List<Product> products = new List<Product> {
        new Product { ID = 1, Name = "Apples",  Price = 1.50m },
        new Product { ID = 2, Name = "Bananas", Price = 2.00m }
             };

        public List<Product> ProductList()
        {
            return products;
        }
   
        public Product GetProducts(int id)
        {
            return products.FirstOrDefault(p => p.ID == id);
        }

        //add to cart emthod here

        public CartProduct AddToCart(int id)
        {
            return new CartProduct { Product = GetProducts(id) };
        }

}
}