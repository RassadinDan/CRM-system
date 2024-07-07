using ModelLibrary.Projects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SkillProfiDesctopClient.Tools
{
	internal static class ImageLoader
	{
		public static BitmapImage LoadImage(byte[] imageData)
		{
			if (imageData == null || imageData.Length == 0) return null;
			var image = new BitmapImage();
			using (var mem = new MemoryStream(imageData))
			{
				mem.Position = 0;
				image.BeginInit();
				image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
				image.CacheOption = BitmapCacheOption.OnLoad;
				image.UriSource = null;
				image.StreamSource = mem;
				image.EndInit();
			}
			image.Freeze();
			return image;
		}

		public static byte[] ByteFromBitmapImage(BitmapImage image)
		{
			Stream stream = image.StreamSource;
			byte[] imagebyte = null;
			Console.WriteLine(stream != null);

            if (stream != null && stream.Length > 0)
			{
				using (BinaryReader br = new BinaryReader(stream))
				{
					imagebyte = br.ReadBytes((Int32)stream.Length);
				}
			}

			return imagebyte;
		}
	}
}
