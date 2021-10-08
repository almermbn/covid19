using covid19.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace covid19.Controllers
{
	[ApiController]
	[Route("api")]
	public class CovidController : Controller
	{
		protected readonly CovidService _covidService;

		public CovidController(CovidService covidService)
		{
			_covidService = covidService;
		}

		[HttpGet("covid/casos/mensais")]
		public IActionResult Monthly()
		{
			return Ok(_covidService.GetMonthly());
		}

		[HttpGet("covid/casos/todos")]
		public IActionResult All()
		{
			return Ok(_covidService.Get());
		}
	}
}
