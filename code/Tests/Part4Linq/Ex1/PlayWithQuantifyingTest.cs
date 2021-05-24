using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part4Linq.Ex1
{
	public class PlayWithQuantifyingTest
	{
		private readonly ITestOutputHelper _outputHelper;
		private TestData _testData;

		public PlayWithQuantifyingTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
			_testData = new TestData();
		}

		[Fact]
		public void VerifyAllStudentsHaveScore()
		{
			var students = _testData.Students;

			var result = students
				.All(i => i.TotalScore > 0);

			_outputHelper.WriteLine($"Total score is {result}");

			result.Should().BeTrue();
		}

		[Fact]
		public void VerifyWhetherExistsStudentWithScoreAbove300()
		{
			var students = _testData.Students;

			var result = students
				.Any(i => i.CurrentSemester > 1 && i.TotalScore > 100);

			if (students.Count > 0)
			{
			}

			if (students.Any())
			{
			}

			_outputHelper.WriteLine($"Total score is {result}");

			result.Should().BeTrue();
		}
	}
}