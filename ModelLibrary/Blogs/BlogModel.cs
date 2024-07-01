using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Blogs
{
	public class BlogModel : Blog
	{

		public IFormFile? ImageFile { get; set; }

		public string? ImageDataUrl { get; set; }
	}
}
