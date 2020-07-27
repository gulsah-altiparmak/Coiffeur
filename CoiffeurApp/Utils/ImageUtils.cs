using InnoSoft.Clouds.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Utils
{
    public class ImageUtils
    {
        public string GetImageList(string path, string fileName, HttpPostedFileBase postedFile)
        {
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            if (postedFile != null)
            {
                fileName = Path.GetFileName(postedFile.FileName);
                postedFile.SaveAs(path + fileName);

            }

            Cloud cloudApi = new Cloud();
            var uploadedImage = cloudApi.UploadFile("cloudinary", "despc5hjc", "453663378761237", "FyQcgbaSwUUNRybE6ht3xjGGmV0", path + fileName);

            return uploadedImage[0].SecureUri.ToString();
        }
        public string GetDefaultImage(string image, string post)
        {

            if (!Directory.Exists(post))
            {
                DirectoryInfo di = Directory.CreateDirectory(post);
            }
            Cloud cloudApi = new Cloud();

            var uploadedImage = cloudApi.UploadFile("cloudinary", "despc5hjc", "453663378761237", "FyQcgbaSwUUNRybE6ht3xjGGmV0", post + image);

            return uploadedImage[0].SecureUri.ToString();
        }
    }
}