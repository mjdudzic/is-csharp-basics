using System;
using System.IO;
using System.Threading.Tasks;
using ExercisesLibrary.ImageProcessing;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part5Async.Ex2
{
	public class PlayWithMultiThreadingTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithMultiThreadingTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public async Task ExecuteCalculationInSeparatedThread()
		{
			var inputData = "test";
			var task = Task.Run(() =>
			{
				if (string.IsNullOrWhiteSpace(inputData) == false)
				{
					_outputHelper.WriteLine($"Input data is {inputData}");
				}
				var randomNumber = new Random().Next(1, 100);
				return randomNumber;
			});
			
			var result = await task;

			_outputHelper.WriteLine($"Result is {result}");

			result.Should().BeGreaterThan(0);
		}

		[Fact]
		public async Task ResizeImageInSeparateThread()
		{
			var inputData = Path.Combine("Part5Async", "TestData", "images", "image1.png");
			var outputData = Path.Combine("Part5Async", "TestData", "images", "image1-min.png");
			var task = Task.Run(() =>
			{
				var imageService = new ImageService();
				imageService.ImageResize(inputData, outputData, 100);
			});

			await task;

			var result = File.Exists(outputData);

			_outputHelper.WriteLine($"Result is {result}");

			result.Should().BeTrue();
		}

		public async Task<int> DoSomeComplexCalculation()
		{
			await Task.Delay(1000);

			return new Random().Next(1, 100);
		}

		public async Task<int> DoSomeComplexCalculation(int startNumber)
		{
			await Task.Delay(1000);

			return new Random().Next(startNumber, startNumber * 100);
		}

		public class TestData
		{
			public int Id { get; set; }
		}
	}
}
