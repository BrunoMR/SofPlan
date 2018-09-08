namespace ApiSoftPlan.Core
{
	using ApiSoftPlan.Models;
	
	public interface IMathCore
	{
		/// <summary>The calculate interest.</summary>
		/// <param name="mathSoft">The math soft.</param>
		/// <returns>The <see cref="decimal"/>.</returns>
		decimal CalculateInterest(MathSoft mathSoft);
	}
}