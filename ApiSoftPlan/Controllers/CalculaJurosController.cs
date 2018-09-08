namespace ApiSoftPlan.Controllers
{
	using ApiSoftPlan.Core;
	using ApiSoftPlan.Models;
	using Microsoft.AspNetCore.Mvc;

	/// <summary>The calcula juros controller.</summary>
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class CalculaJurosController : Controller
	{
		/// <summary>Gets the math core.</summary>
		private readonly IMathCore MathCore;

		/// <summary>Initializes a new instance of the <see cref="CalculaJurosController"/> class.</summary>
		/// <param name="mathCore">The math core.</param>
		public CalculaJurosController(IMathCore mathCore)
		{
			this.MathCore = mathCore;
		}
		
		// POST api/CalculaJuros
		[HttpPost(Name = nameof(CalculaJurosPost))]
		[Produces("application/json")]
		public IActionResult CalculaJurosPost([FromBody]MathSoft mathSoft)
		{
			if (mathSoft == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			
			return Ok(this.MathCore.CalculateInterest(mathSoft));
		}
	}
}