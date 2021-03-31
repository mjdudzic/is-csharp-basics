using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using NSubstitute.Exceptions;

namespace Tests.Part4Linq.Ex1
{
	public class TestData
	{
		private Random _random = new Random();
		private readonly Fixture _fixture = new Fixture();

		public List<int> Scores => _fixture.CreateMany<int>(100).ToList();

		public List<Student> Students => _fixture
			.Build<Student>()
			.With(
				x => x.StudyingStartYear, 
				() => _random.Next(1999, 2020))
			.With(
				x => x.CurrentSemester,
				() => _random.Next(1, 10))
			.With(
				x => x.TotalScore,
				() => _random.Next(100, 600))
			.CreateMany(20)
			.ToList();
	}

	public class Student
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int StudyingStartYear { get; set; }
		public int CurrentSemester { get; set; }
		public double TotalScore { get; set; }
	}
}