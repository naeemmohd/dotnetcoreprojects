using System.Collections.Generic;

namespace Sample01MVCApp.Models
{
    public interface IProductRepository
    {
        Product GetProductById(int ProductId);
        List<Product> GetAllProducts(int? count=0);
    }
}