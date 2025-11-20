using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helper
{
    public static class ImageHelper
    {

        public static string Upload(IFormFile img)
        {
            var radomNumber = DateTime.Now.Ticks.ToString();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "Images", "Customer", radomNumber+ "_" + img.FileName.Replace(" ", ""));
            using (var stream = System.IO.File.Create(path))
            {
                img.CopyTo(stream);
            }
            return "\\Uploads\\Images\\Customer\\" + radomNumber + "_" + img.FileName.Replace(" ", "");
        }
    }
}
