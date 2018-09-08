namespace ApiSoftPlan.Models
{
	/// <summary>The settings.</summary>
	public class Settings
	{
		/// <summary>Gets or sets the interest.</summary>
		public int Interest { get; set; }

		/// <summary>The interest calculated.</summary>
		public double InterestCalculated => (double)Interest / 100;

		/// <summary>Gets or sets the decimal cases.</summary>
		public int DecimalCases { get; set; }
	}
}