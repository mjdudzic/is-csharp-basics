using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part1CsharpBasics.Ex2
{
	public class PlayWithArraysTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithArraysTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void GetLastItemInArray()
		{
			// define array of integers with some random numbers
			// get value of the last element 
			var array = new[] {1, 2, 3, 47, 8};

			var result = array[^1]; // last itm in array

			_outputHelper.WriteLine($"Last element is {result}");

			result.Should().BeGreaterThan(0);
		}
	}
}
