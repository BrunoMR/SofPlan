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
		/// <param name="mathSoft">The math soft.</param>
		/// <returns>The <see cref="IActionResult"/>.</returns>
		[HttpGet(Name = nameof(ShowMeTheCodeGet))]
		[Produces("application/json")]
		public IActionResult ShowMeTheCodeGet([FromBody]MathSoft mathSoft)
		{

			return BadRequest();
		}
	}
}