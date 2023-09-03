using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPIProject.Entities;

namespace MyFirstWebAPIProject.Controllers
{
	[ApiController]
	[Route("api")]

    public class StandardController : ControllerBase
    {
        private readonly IStandardRepository _repository;
        public StandardController(IStandardRepository repository)
        {
			_repository = repository;
        }
        //multiple routes for same end point
        [HttpGet]
		[Route("AllStandards")]
		[Route("Standard/All")]
		public ActionResult<List<Standard>> GetAllStandards()
		{
			return _repository.GetStandards();
		} 
		
		[HttpGet]
		[Route("StandardsById")]
		//token replacement using {id} with routing constraint with range
		[Route("Standard/ById/{id:int:range(1,100)}")]
		//token replacement using {id} with routing constraint with min max
		//[Route("Standard/ById/{id:int:min(100):max(1000)}")]
		public ActionResult<Standard?> GetStandardsById(int id)
		{
			return _repository.GetStandardById(id);
		}
    }
}