using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part4Linq.Ex1
{
	public class PlayWithAggregatesTest
	{
		private readonly ITestOutputHelper _outputHelper;
		private TestData _testData;

		public PlayWithAggregatesTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
			_testData = new TestData();
		}

		[Fact]
		public void GetStudentsMaxMinAndAverageScore()
		{
			var students = _testData.Students;

			var maxScore = 0;

			var minScore = 0;

			var avgScore = 0;

			_outputHelper.WriteLine($"Max score is {maxScore}");
			_outputHelper.WriteLine($"Min score is {minScore}");
			_outputHelper.WriteLine($"Average score is {avgScore}");

			maxScore.Should().BeGreaterThan(0);
			minScore.Should().BeGreaterThan(0);
			avgScore.Should().BeGreaterThan(0);
		}

		[Fact]
		public void GetStudentsTotalScore()
		{
			var students = _testData.Students;

			var result = 0;

			_outputHelper.WriteLine($"Total score is {result}");

			result.Should().BeGreaterThan(0);
		}
	}
}
