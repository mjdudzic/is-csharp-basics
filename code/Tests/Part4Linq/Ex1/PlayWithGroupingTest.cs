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

			// Group students by study year
			// In output display data grouped by year in following example ormat
			// Year 1999
			// [Student list]
			// Year 2000
			// [Student list]

			var result = students;

			result.Count().Should().BeLessThan(students.Count);
		}
	}
}
