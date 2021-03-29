using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part1CsharpBasics.Ex1
{
	public class PlayWithIntegersTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithIntegersTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CalculatePythagorasTheorem()
		{
			//a = some integer
			//b = some integer
			
			var result = 0; //result = a2 + b2

			_outputHelper.WriteLine($"c2 = {result}");

			result.Should().BeGreaterThan(0);
		}
	}
}
