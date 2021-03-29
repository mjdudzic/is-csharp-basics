using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part1CsharpBasics.Ex2
{
	public class PlayWithDictionariesTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithDictionariesTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void FindBookByIsbn()
		{
			// Create dictionary of books where ISBN (some unique number) is a key and book name is a value
			// One of books should have isbn equal to 12345 
			const string isbnToSearchFor = "12345";

			var result = string.Empty; //result = book name

			_outputHelper.WriteLine($"Book name for ISBN {isbnToSearchFor} is {result}");

			result.Should().NotBeNullOrWhiteSpace();
		}
	}
}
