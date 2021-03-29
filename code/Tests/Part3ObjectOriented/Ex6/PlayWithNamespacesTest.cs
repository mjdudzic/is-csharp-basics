using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part3ObjectOriented.Ex6
{
	public class PlayWithNamespacesTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithNamespacesTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void CreateUniversitySystemNamespaces()
		{
			// 1. Create namespace for classes describing university-related areas such as:
			// - University
			// - Dormitory
			// - Campus
			// 2. Create namespace for classes describing university-related people such as:
			// - Teacher
			// - Student
			// - OfficeWorker
			// 3. Replace below objects with proper class types

			object student = null;
			object university = null;

			student.Should().NotBeNull();
			university.Should().NotBeNull();
		}
	}
}
