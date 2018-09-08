namespace ApiSoftPlan.Controllers
{
	using ApiSoftPlan.Core;
	using ApiSoftPlan.Extensions;
	using ApiSoftPlan.Models;
	using Microsoft.AspNetCore.Mvc;

	/// <summary>The calcula juros controller.</summary>
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class CalculaJurosController : Controller
	{
		/// <summary>Gets the math core.</summary>
		private readonly IMathCore MathCore;

		public CalculaJurosController(IMathCore mathCore)
		{
			this.MathCore = mathCore;
		}
		
		// POST api/CalculaJuros
		[HttpPost(Name = nameof(CalculaJurosPost))]
		[Produces("application/json")]
		public void CalculaJurosPost([FromBody]MathSoft mathSoft)
		{
			var opa = this.MathCore.CalculateInterest(mathSoft);
		}
	}
}