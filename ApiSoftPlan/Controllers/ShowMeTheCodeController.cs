namespace ApiSoftPlan.Controllers
{
	using ApiSoftPlan.Models;
	using Microsoft.AspNetCore.Mvc;

	/// <summary>The calcula juros controller.</summary>
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class ShowMeTheCodeController : Controller
	{
		/// <summary>The show me the code get.</summary>
		/// <returns>The <see cref="IActionResult"/>.</returns>
		[HttpGet(Name = nameof(ShowMeTheCodeGet))]
		[Produces("application/json")]
		public string ShowMeTheCodeGet()
		{

			return "https://github.com/BrunoMR/SofPlan";
		}
	}
}