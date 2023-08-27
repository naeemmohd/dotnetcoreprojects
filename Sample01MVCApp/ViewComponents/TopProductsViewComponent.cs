using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample01MVCApp.Models;

namespace Sample01MVCApp.ViewComponents
{
	//Create a Class, and it should inherit from ViewComponent class
	public class TopProductsViewComponent : ViewComponent
	{
		private readonly IProductRepository _productRepository;
		public TopProductsViewComponent(IProductRepository productRepository)
		{
			_productRepository= productRepository;
		}

		//The Invoke method for the View component
		public async Task<IViewComponentResult> InvokeAsync(int count)
		{
			var products = _productRepository.GetAllProducts(3);
			await Task.Delay(System.TimeSpan.FromSeconds(1));
			return View(products);
		}
	}
}