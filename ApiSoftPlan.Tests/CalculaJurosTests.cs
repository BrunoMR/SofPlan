namespace ApiSoftPlan.Tests
{
	using ApiSoftPlan.Controllers;
	using ApiSoftPlan.Core;
	using ApiSoftPlan.Models;
	using Microsoft.AspNetCore.Mvc;
	using Moq;
	using Xunit;

	public class CalculaJurosTests
	{
		[Fact]
		public void ShouldBeRightValue()
		{
			var mathSoft = new MathSoft { InitialValue = 100, Month = 5, TotalValue = (decimal)105.10 };
			var mathCore = new Mock<IMathCore>();

			mathCore.Setup(x => x.CalculateInterest(mathSoft))
				.Returns(mathSoft.TotalValue);

			var controller = new CalculaJurosController(mathCore.Object);

			var result = controller.CalculaJurosPost(mathSoft);

			var okObjectResult = Assert.IsType<OkObjectResult>(result);

			Assert.Equal((decimal)105.10, okObjectResult.Value);
		}

		[Fact]
		public void ShouldBeWrongValue()
		{
			var mathSoft = new MathSoft { InitialValue = 100, Month = 5, TotalValue = (decimal)105.10 };
			var mathCore = new Mock<IMathCore>();

			mathCore.Setup(x => x.CalculateInterest(mathSoft))
				.Returns(mathSoft.TotalValue);

			var controller = new CalculaJurosController(mathCore.Object);

			var result = controller.CalculaJurosPost(mathSoft);

			var okObjectResult = Assert.IsType<OkObjectResult>(result);

			Assert.NotEqual((decimal)110.10, okObjectResult.Value);
		}

		[Fact]
		public void ShouldBeOk()
		{
			var mathSoft = new MathSoft { InitialValue = 100, Month = 10, TotalValue = (decimal)105.10 };
			var mathCore = new Mock<IMathCore>();

			mathCore.Setup(x => x.CalculateInterest(mathSoft))
				.Returns(mathSoft.TotalValue);

			var controller = new CalculaJurosController(mathCore.Object);

			var result = controller.CalculaJurosPost(mathSoft);

			var okObjectResult = Assert.IsType<OkObjectResult>(result);

			Assert.True(((ObjectResult)result).StatusCode == 200);
		}

		[Fact]
		public void ShouldBeBad()
		{
			var mathSoft = new MathSoft { InitialValue = 100, Month = 10, TotalValue = (decimal)105.10 };
			var mathCore = new Mock<IMathCore>();

			mathCore.Setup(x => x.CalculateInterest(null))
				.Returns(mathSoft.TotalValue);

			var controller = new CalculaJurosController(mathCore.Object);

			var result = controller.CalculaJurosPost(null);
			
			Assert.True(((StatusCodeResult)result).StatusCode == 400);
		}
	}
}