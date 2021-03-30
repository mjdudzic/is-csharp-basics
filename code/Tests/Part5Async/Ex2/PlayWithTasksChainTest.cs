using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Part5Async.Ex2
{
	public class PlayWithTasksChainTest
	{
		private readonly ITestOutputHelper _outputHelper;

		public PlayWithTasksChainTest(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public async Task ReadFileAndWriteFile()
		{
			var existingFilePath = Path.Combine("Part5Async", "TestData", "file1.txt");
			var newFilePath = Path.Combine("Part5Async", "TestData", $"file1-{Guid.NewGuid():N}.txt");
			//var filePath = "Part5Async/Ex1/TestData/file1.txt";
			//var filePath = "Part5Async\\Ex1\\TestData\\file1.txt";

			var existingFileReadTask = File.ReadAllTextAsync(existingFilePath);

			var newFileWriteTask = existingFileReadTask
				.ContinueWith(sourceTask => File.WriteAllTextAsync(newFilePath, sourceTask.Result));

			await newFileWriteTask;

			var result = await File.ReadAllTextAsync(newFilePath);

			_outputHelper.WriteLine(result);

			result.Should().NotBeNullOrWhiteSpace();
		}

		[Fact]
		public async Task ReadFileAndWriteFileOnlyIfReadSucceeded()
		{
			var existingFilePath = Path.Combine("Part5Async", "TestData", "file1.txt");
			var newFilePath = Path.Combine("Part5Async", "TestData", $"file1-{Guid.NewGuid():N}.txt");
			//var filePath = "Part5Async/Ex1/TestData/file1.txt";
			//var filePath = "Part5Async\\Ex1\\TestData\\file1.txt";

			var existingFileReadTask = File.ReadAllTextAsync(existingFilePath);

			var newFileWriteTask = existingFileReadTask
				.ContinueWith(
					sourceTask => File.WriteAllTextAsync(newFilePath, sourceTask.Result),
					TaskContinuationOptions.OnlyOnRanToCompletion);

			var runAlwaysTask = newFileWriteTask.ContinueWith(_ =>
			{
				_outputHelper.WriteLine("result");
			});

			await runAlwaysTask;

			var result = await File.ReadAllTextAsync(newFilePath);

			_outputHelper.WriteLine(result);

			result.Should().NotBeNullOrWhiteSpace();
		}

		[Fact]
		public async Task ReadManyFilesInLoop()
		{
			var fileBasePath = Path.Combine("Part5Async", "TestData");
			var filesToReadCount = 3;

			var fileContents = new ConcurrentDictionary<string, string>();
			//Parallel.For(1, filesToReadCount, async (index) =>
			//{
			//	var filePath = Path.Combine(fileBasePath, $"file{index}.txt");
			//	var fileContent = await File.ReadAllTextAsync(filePath);
			//	fileContents.TryAdd(filePath, fileContent);

			//	_outputHelper.WriteLine($"{filePath} - current thread number is {Thread.CurrentThread.ManagedThreadId}");
			//});

			await Task.Run(() =>
			{
				Parallel.For(1, filesToReadCount, async (index) =>
				{
					var filePath = Path.Combine(fileBasePath, $"file{index}.txt");
					var fileContent = await File.ReadAllTextAsync(filePath);
					fileContents.TryAdd(filePath, fileContent);

					_outputHelper.WriteLine(
						$"{filePath} - current thread number is {Thread.CurrentThread.ManagedThreadId}");
				});
			});

			foreach (var fileContent in fileContents)
			{
				_outputHelper.WriteLine($"{fileContent.Key} - {fileContent.Value}");
			}

			var result = fileContents.Count;

			result.Should().BeGreaterThan(0);
		}
	}
}
