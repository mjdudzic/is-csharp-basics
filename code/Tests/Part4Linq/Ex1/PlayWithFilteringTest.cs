using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part4Linq.Ex1
{
	public class PlayWithFilteringTest
	{
		private readonly ITestOutputHelper _outputHelper;
		private TestData _testData;

		public PlayWithFilteringTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
			_testData = new TestData();
		}

		[Fact]
		public void GetAllStudentsThatStartedStudyingIn2000()
		{
			var students = _testData.Students;

			var result = students
				.Where(i => i.StudyingStartYear >= 2000)
				.ToList();

			_outputHelper.WriteLine($"Selected students count is {result.Count}");

			foreach (var student in result)
			{
				_outputHelper.WriteLine($"Selected student {student.FirstName} {student.LastName}");
			}

			result.Count.Should().BeLessThan(students.Count);
		}

		[Fact]
		public void GetStudentsBeforeThirdSemesterWithScoreAbove100()
		{
			var students = _testData.Students;

			var result = students
				.Where(i => i.CurrentSemester < 3 && i.TotalScore > 100);

			//var result2 = students
			//	.Where(i => i.CurrentSemester < 3)
			//	.Where(i => i.TotalScore > 100)
			//	.ToList();

			_outputHelper.WriteLine($"Selected students count is {result.Count()}");

			foreach (var student in result)
			{
				_outputHelper.WriteLine($"Selected student {student.FirstName} {student.LastName}");
			}

			result.Count().Should().BeGreaterThan(0);
		}
	}
}
