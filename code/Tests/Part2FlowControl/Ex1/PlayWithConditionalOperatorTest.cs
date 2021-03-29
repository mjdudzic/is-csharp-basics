using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part2FlowControl.Ex1
{
	public class PlayWithConditionalOperatorTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithConditionalOperatorTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void AreYouAnAdult()
		{
			// define variable with your or someone's age
			// create function that returns
			// - text "not adult" if age is below 18
			// - text "adult" if age is 18 or more

			var result = string.Empty;

			_outputHelper.WriteLine($"Provided age means you are {result}");

			result.Should().NotBeNullOrWhiteSpace();
		}
	}
}
