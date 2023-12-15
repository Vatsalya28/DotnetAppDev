using ADOBasics.Model;
using ADOBasics.Repository;
using ProductLib;

IProductRepository iProductRepository=new  ProductRepository();
ProductLib productLib = new ProductLib();
List<object>allProducts=iProductRepository.GetProductsAndCategoryName();
//Reading All the Records from Databse
//List<Product>allProducts=iProductRepository.GetAllProducts();
foreach (var item in allProducts)
{
    Console.WriteLine(item);
}
//Product product = new Product() { ProductName = "HeadPhone", Price = 1000, CategoryId = 1, Rating = 4.2f };
//int productaddedStatus=iProductRepository.AddProduct(product);
//if (productaddedStatus > 0)
//{
//    Console.WriteLine("Product Added SucessFully");
//}
//else
//{
//    Console.WriteLine("Product Addition Failed");
//}

//int deleteProductStatus = iProductRepository.DeleteProduct(13);
//if (deleteProductStatus > 0)
//{
//    Console.WriteLine("Product Deleted SucessFully");
//}
//else
//{
//    Console.WriteLine("Product Addition Failed");
//}
