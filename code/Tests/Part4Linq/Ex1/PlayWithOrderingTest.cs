using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part4Linq.Ex1
{
	public class PlayWithOrderingTest
	{
		private readonly ITestOutputHelper _outputHelper;
		private TestData _testData;

		public PlayWithOrderingTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
			_testData = new TestData();
		}

		[Fact]
		public void GetStudentsOrderedByScore()
		{
			var students = _testData.Students;

			var result = students;

			foreach (var student in result)
			{
				_outputHelper.WriteLine($"Selected student {student.FirstName} {student.LastName}");
			}

			result.Count().Should().BeGreaterThan(0);
		}

		[Fact]
		public void GetStudentsOrderedByScoreWithTheHighestOneAtTheBeginning()
		{
			var students = _testData.Students;

			var result = students;

			foreach (var student in result)
			{
				_outputHelper.WriteLine($"Selected student {student.FirstName} {student.LastName}");
			}

			result.Count().Should().BeGreaterThan(0);
		}

		[Fact]
		public void GetStudentWithTheHighestScore()
		{
			var students = _testData.Students;

			Student result = null;

			_outputHelper.WriteLine($"Selected student {result.FirstName} {result.LastName}");

			result.Should().NotBeNull();
		}
	}
}
