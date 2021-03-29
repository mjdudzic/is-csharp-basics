using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part2FlowControl.Ex2
{
	public class PlayWithWhileLoop
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithWhileLoop(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CalculateFactorialNumber()
		{
			// define variable e.g. 'n' with some integer
			// create function that will calculate n! (factorial number)
			// eg. 3! = 1 * 2 * 3 = 6

			var number = 3;
			var result = 0;

			_outputHelper.WriteLine($"Factorial number for {number} is {result}");

			result.Should().BeGreaterThan(0);
		}
	}
}
