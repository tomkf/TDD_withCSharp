using MVC_inclass.Models;
using System.Collections.Generic;

namespace MVC_inclass.Repositories
{
    public interface IProductRepository
    {
        List<Product> ProductList();
    }
}