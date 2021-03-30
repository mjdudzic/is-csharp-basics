using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part4Linq.Ex1
{
	public class PlayWithPartitioningTest
	{
		private readonly ITestOutputHelper _outputHelper;
		private TestData _testData;

		public PlayWithPartitioningTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
			_testData = new TestData();
		}

		[Fact]
		public void GetTopThreeStudentWithTheHighestScore()
		{
			var students = _testData.Students;

			var result = students
				.OrderByDescending(i => i.TotalScore)
				.Take(3);

			foreach (var student in result)
			{
				_outputHelper.WriteLine($"Selected student {student.FirstName} {student.LastName}");
			}

			result.Count().Should().BeLessThan(students.Count);
		}

		[Fact]
		public void GetNexThreeOnesAfterTopThreeStudentWithTheHighestScore()
		{
			var students = _testData.Students;

			var result = students
				.OrderByDescending(i => i.TotalScore)
				.Skip(3)
				.Take(3);

			foreach (var student in result)
			{
				_outputHelper.WriteLine($"Selected student {student.FirstName} {student.LastName}");
			}

			result.Count().Should().BeLessThan(students.Count);
		}
	}
}