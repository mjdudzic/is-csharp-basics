using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part4Linq.Ex1
{
	public class PlayWithGroupingTest
	{
		private readonly ITestOutputHelper _outputHelper;
		private TestData _testData;

		public PlayWithGroupingTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
			_testData = new TestData();
		}

		[Fact]
		public void GetStudentsGroupedByStudyYear()
		{
			var students = _testData.Students;

			var result = students
				.GroupBy(key => key.StudyingStartYear)
				.ToList();

			foreach (var data in result.OrderBy(i => i.Key))
			{
				_outputHelper.WriteLine($"Year {data.Key}, Numbers of students {data.Count()}");

				foreach (var student in data)
				{
					_outputHelper.WriteLine($"Selected student {student.FirstName} {student.LastName}");
				}
			}

			result.Count().Should().BeLessThan(students.Count);
		}
	}
}