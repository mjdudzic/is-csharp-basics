using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part1CsharpBasics.Ex1
{
	public class PlayWithTextTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithTextTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void HowLongIsYourName()
		{
			//firstName = Your first name
			//lastName = Your last name
			//full name = firstName lastName

			var result = 0; //result = full name length (with space in between)

;			_outputHelper.WriteLine($"Your full name length is {result}");

			result.Should().BeGreaterThan(0);
		}

		[Fact]
		public void EncodeMessage()
		{
			var message = "The quickest way to a man's heart is with Chuck Norris' fist.";

			var result = message; //in message replace 'a' with 'x' and b with y

			_outputHelper.WriteLine($"Encoded message is {result}");

			result.Length.Should().BeGreaterThan(0);
		}
	}
}
