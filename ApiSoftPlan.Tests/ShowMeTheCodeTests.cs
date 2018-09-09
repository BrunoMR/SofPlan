namespace ApiSoftPlan.Tests
{
	using ApiSoftPlan.Controllers;
	using Xunit;

	public class ShowMeTheCodeTests
	{
		[Fact]
		public void SouldGetTheUrl()
		{
			var contoller = new ShowMeTheCodeController();
			var result = contoller.ShowMeTheCodeGet();

			Assert.Equal("https://github.com/BrunoMR/SofPlan", result);
		}
	}
}