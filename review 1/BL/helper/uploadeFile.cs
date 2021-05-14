using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace review_1.BL.helper
{
    public static class uploadeFile
    {
        public static string uploade(IFormFile fileurl,string path)
        {
            //save photo
            string photoPath = Directory.GetCurrentDirectory() +path;
            string photoName = Guid.NewGuid() + Path.GetFileName(fileurl.FileName);

            string finalPath = Path.Combine(photoPath, photoName);

            using (var stream = new FileStream(finalPath, FileMode.Create))
            {
                fileurl.CopyTo(stream);
            }

            return photoName;
        }
        public static void delete(string folder,string name)
        {
            string path= Directory.GetCurrentDirectory() +"/wwwroot/files/" +folder + "/" + name;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
