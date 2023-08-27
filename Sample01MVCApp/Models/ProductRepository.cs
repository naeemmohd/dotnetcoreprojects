using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample01MVCApp.Models
{
	public class ProductRepository : IProductRepository
	{
		public List<Product> DataSource()
		{
			List<Product> products = new List<Product>()

			{
				new Product { ProductID =1, Name ="Product 1", Category = "Category 1", Description ="Description 1", Price = 10m},
				new Product { ProductID =2, Name ="Product 2", Category = "Category 1", Description ="Description 2", Price = 20m},
				new Product { ProductID =3, Name ="Product 3", Category = "Category 1", Description ="Description 3", Price = 30m},
				new Product { ProductID =4, Name ="Product 4", Category = "Category 2", Description ="Description 4", Price = 40m},
				new Product { ProductID =5, Name ="Product 5", Category = "Category 2", Description ="Description 5", Price = 50m},
				new Product { ProductID =6, Name ="Product 6", Category = "Category 2", Description ="Description 6", Price = 50m}
			};
			return products;
		}
		public Product GetProductById(int ProductId)
		{
			return DataSource().FirstOrDefault(prd => prd.ProductID == ProductId);
			
		}

        List<Product> IProductRepository.GetAllProducts(int? count=0)
        {
            var products = DataSource();
			if(count>0)
				return products.Take(Convert.ToInt32(count)).ToList();
			return products.ToList();
        }
    }
}