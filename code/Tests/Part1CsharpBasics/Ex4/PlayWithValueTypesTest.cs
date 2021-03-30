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
		public void GetPriceWithVat()
		{
			var priceNet = 100d;

			// Create and run function that will add VAT 23% to provided price
			var result = GetGrossPrice(priceNet); // priceNet + 23% VAT

			_outputHelper.WriteLine($"Price including VAT is {result}");
			_outputHelper.WriteLine($"Price without VAT is {priceNet}");

			result.Should().BeGreaterThan(0);
			priceNet.Should().Equals(100d);
		}

		public double GetGrossPrice(double priceNet)
		{
			priceNet += priceNet * 0.23;

			return priceNet;
		}
	}
}
