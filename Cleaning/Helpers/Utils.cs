using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Cleaning.Helpers
{
    public class Utils
    {
        public static string GetEnumDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DisplayAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute));
            return attribute?.Name ?? value.ToString();
        }

        public static string SaveFormFile(IFormFile file, string directory)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            using (var fileStream = new FileStream(Path.Combine(directory, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }

        public static void DeleteFile(string path)
        {
            if (!String.IsNullOrEmpty(path) && System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }
    }
}
