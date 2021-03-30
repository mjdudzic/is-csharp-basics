using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part5Async.Ex1
{
	public class PlayWithFilesTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithFilesTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public async Task ReadFileContent()
		{
			var filePath = Path.Combine("Part5Async", "TestData", "file3.txt");
			//var filePath = "Part5Async/Ex1/TestData/file1.txt";
			//var filePath = "Part5Async\\Ex1\\TestData\\file1.txt";

			var result = await File.ReadAllTextAsync(filePath);

			_outputHelper.WriteLine(result);

			result.Should().NotBeNullOrWhiteSpace();
		}

		[Fact]
		public async Task ReadTwoFilesSimultaneously()
		{
			var file1Path = Path.Combine("Part5Async", "TestData", "file1.txt");
			var file2Path = Path.Combine("Part5Async", "TestData", "file2.txt");

			var tasks = new List<Task<string>>
			{
				File.ReadAllTextAsync(file1Path),
				File.ReadAllTextAsync(file2Path)
			};

			var result = await Task.WhenAll(tasks);

			_outputHelper.WriteLine(result.First());
			_outputHelper.WriteLine(result.Last());

			result.Length.Should().BeGreaterThan(0);
		}

		[Fact]
		public async Task ReadFileContentAsStream()
		{
			var filePath = Path.Combine("Part5Async", "TestData", "file3.txt");
			//var filePath = "Part5Async/Ex1/TestData/file1.txt";
			//var filePath = "Part5Async\\Ex1\\TestData\\file1.txt";

			var result = string.Empty;
			using var streamReader = File.OpenText(filePath);
			while (streamReader.EndOfStream == false)
			{
				result = await streamReader.ReadLineAsync();
				_outputHelper.WriteLine(result);
				break;
			}

			result.Should().NotBeNullOrWhiteSpace();
		}

		[Fact]
		public void ReadFileAsyncSynchronously()
		{
			var result = ReadTestFile("file3.txt").GetAwaiter().GetResult();

			try
			{
				//DoSomeAsync().Wait();
				DoSomeAsync().GetAwaiter().GetResult();
			}
			catch (Exception e)
			{
				_outputHelper.WriteLine(e.Message);
			}
			
			
			_outputHelper.WriteLine(result);

			result.Should().NotBeNullOrWhiteSpace();
		}

		public Task<string> ReadTestFile(string fileName)
		{
			var filePath = Path.Combine("Part5Async", "TestData", fileName);

			return File.ReadAllTextAsync(filePath);
		}

		public async Task DoSomeAsync()
		{
			await Task.CompletedTask;
			throw new Exception("async1");
		}
	}
}
