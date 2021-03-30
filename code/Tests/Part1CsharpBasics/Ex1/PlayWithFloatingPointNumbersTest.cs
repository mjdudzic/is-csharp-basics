using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part1CsharpBasics.Ex1
{
	public class PlayWithFloatingPointNumbersTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithFloatingPointNumbersTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CalculateGrossPrice()
		{
			//price = some double
			//vat = some double
			var price = 10.0d;
			var vat = 0.23;
			
			var result = price + price * vat; //result = price with vat

			_outputHelper.WriteLine($"gross price = {result}");

			result.Should().BeGreaterThan(0);
		}

		[Fact]
		public void CalculateTriangleArea()
		{
			//triangleBase = some integer
			//triangleHeight = some integer
			var triangleBase = 10;
			var triangleHeight = 12;

			var result = 0.5 * triangleBase * triangleHeight; //result = 1/2 * triangleBase * triangleHeight

			_outputHelper.WriteLine($"triangle area = {result}");

			result.Should().BeGreaterThan(0);
		}
	}
}
