using ADOBasics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOBasics.Repository
{
    internal interface IProductRepository
    {
        List<Product> GetAllProducts();
        int AddProduct(Product product);
        int DeleteProduct(int productId);
        List<object> GetProductsAndCategoryName();
    }
}
