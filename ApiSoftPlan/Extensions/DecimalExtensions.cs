namespace ApiSoftPlan.Extensions
{
	using System;

	public static class DecimalExtensions
	{
		/// <summary>The truncate.</summary>
		/// <param name="_this">The _this.</param>
		/// <param name="precision">The precision.</param>
		/// <returns>The decimal truncated with the decimal cases requested.</returns>
		public static decimal TruncateWithCases(this decimal _this, int precision)
		{
			var step = (decimal)Math.Pow(10, precision);
			var tmp = Math.Truncate(step * _this);
			return tmp / step;
		}
	}
}