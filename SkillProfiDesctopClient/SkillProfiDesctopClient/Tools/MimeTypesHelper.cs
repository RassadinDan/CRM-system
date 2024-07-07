using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillProfiDesctopClient.Tools
{
    public static class MimeTypesHelper
    {
        public static string GetContentType(string fileExtension)
        {
            var mimeTypes = new Dictionary<string, string>
            {
                {".bmp", "image/bmp"},
                {".gif", "image/gif"},
                {".jpeg", "image/jpeg"},
                {".jpg", "image/jpeg"},
                {".png", "image/png"},
                {".tif", "image/tiff"},
                {".tiff", "image/tiff"}
            };

            return mimeTypes.ContainsKey(fileExtension) ? mimeTypes[fileExtension] : null;
        }
    }
}
