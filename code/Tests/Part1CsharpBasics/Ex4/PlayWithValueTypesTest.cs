using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part1CsharpBasics.Ex4
{
	public class PlayWithValueTypesTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithValueTypesTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void RunFunctionToCalculateRectangleArea()
		{
			var priceNet = 100d;

			// Create and run function that will add VAT 23% to provided price
			var result = 0; // priceNet + 23% VAT

			_outputHelper.WriteLine($"Price including VAT is {result}");

			result.Should().BeGreaterThan(0);
		}
	}
}
