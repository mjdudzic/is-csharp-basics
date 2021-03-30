using System.Collections.Generic;
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
				NetValue = 100m,
				GrossValue = 0
			};

			var list = new List<int> { 2, 1};
			AddToList(list);

			// Create and run function that will add VAT 23% to provided price
			// Function gets Price object as argument
			// Function must set value for GrossValue in Price object
			GetGrossPrice(price);

			_outputHelper.WriteLine($"Price including VAT is {price.GrossValue}");

			price.GrossValue.Should().BeGreaterThan(0);
		}

		public void GetGrossPrice(Price price)
		{
			price.GrossValue = price.NetValue + price.NetValue * 0.23m;
		}

		public void AddToList(List<int> list)
		{
			list.Add(100);
			list.Sort();
		}

		public class Price
		{
			public decimal NetValue { get; set; }
			public decimal GrossValue { get; set; }
		}
	}
}
