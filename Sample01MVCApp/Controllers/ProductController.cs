using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sample01MVCApp.Models;

namespace Sample01MVCApp.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;
		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		
		[Route("Product/All")]
		public ActionResult Index()
		{
			return View(_productRepository.GetAllProducts());
		}
		
		[Route("Product/Details/{Id=1}")]
		public ActionResult Details(int Id)
		{
			var ProductDetails = _productRepository.GetProductById(Id);
			return View(ProductDetails);
		}
	}
}