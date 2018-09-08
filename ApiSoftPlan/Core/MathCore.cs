namespace ApiSoftPlan.Core
{
	using System;
	using ApiSoftPlan.Models;
	using Extensions;

	using Microsoft.Extensions.Options;

	public class MathCore : IMathCore
	{
		/// <summary>
		/// The settings.
		/// </summary>
		private readonly Settings settings;

		/// <summary>Initializes a new instance of the <see cref="MathCore"/> class.</summary>
		/// <param name="optionsSnapshot">The options snapshot.</param>
		public MathCore(IOptionsSnapshot<Settings> optionsSnapshot)
		{
			this.settings = optionsSnapshot.Value;
		}

		/// <summary>The calculate interest.</summary>
		/// <param name="mathSoft">The math soft.</param>
		/// <returns>The <see cref="decimal"/>.</returns>
		public decimal CalculateInterest(MathSoft mathSoft)
		{
			mathSoft.TotalValue = mathSoft.InitialValue;

			for (var i = 0; i < mathSoft.Month; i++)
			{
				mathSoft.TotalValue *= (decimal)(1 + this.settings.InterestCalculated);
			}
			
			return mathSoft.TotalValue.TruncateWithCases(this.settings.DecimalCases);
		}
	}
}