using System;
using System.Collections.Generic;
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
				.Where(i => i.StudyingStartYear >= 2021)
				.ToList();

			//var result3 =
			//	from student in students
			//	where student.StudyingStartYear > 200
			//	select student;

			//var result2 = new List<Student>();
			//for (int i = 0; i < students.Count; i++)
			//{
			//	var student = students[i];
			//	if (student.StudyingStartYear >= 2000)
			//	{
			//		result2.Add(student);
			//	}
			//}

			_outputHelper.WriteLine($"Selected students count is {result.Count()}");

			foreach (var student in result)
			{
				_outputHelper.WriteLine($"Selected student {student.FirstName} {student.LastName}");
			}

			result.Count().Should().BeLessThan(students.Count);
		}

		public bool Expr(Student student)
		{
			return student.StudyingStartYear >= 2000;
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
