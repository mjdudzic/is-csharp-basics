using System;
using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ExercisesLibrary.ImageProcessing
{
	public class ImageService
	{
		public void ImageResize(
			string inputPath,
			string outputPath,
			int maxWidthOrHeight)
		{
			using var imageStream = new MemoryStream(File.ReadAllBytes(inputPath));
			using var image = Image.Load(imageStream);
			
			var divisor = image.Width / maxWidthOrHeight;
			var height = divisor == 0 ? 0 : Convert.ToInt32(Math.Round((decimal)(image.Height / divisor)));

			image.Mutate(x => 
				x.Resize(maxWidthOrHeight, height));

			image.Save(outputPath);
		}
	}
}