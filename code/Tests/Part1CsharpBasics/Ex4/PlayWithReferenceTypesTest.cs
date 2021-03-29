using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part1CsharpBasics.Ex4
{
	public class PlayWithReferenceTypesTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithReferenceTypesTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void RunFunctionToCalculateRectangleArea()
		{
			var price = new Price
			{
				NetValue = 100m
			};

			// Create and run function that will add VAT 23% to provided price
			// Function gets Price object as argument
			// Function must set value for GrossValue in Price object

			_outputHelper.WriteLine($"Price including VAT is {price.GrossValue}");

			price.GrossValue.Should().BeGreaterThan(0);
		}

		public class Price
		{
			public decimal NetValue { get; set; }
			public decimal GrossValue { get; set; }
		}
	}
}
