using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Project.COMMON.Tools
{
    public static class ImageUploader
    {
        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if (file !=null)
            {
                Guid uniqueName = Guid.NewGuid();

                serverPath = serverPath.Replace("~", string.Empty);

                string[] fileArray = file.FileName.Split('.');

                string extension = fileArray[fileArray.Length - 1].ToLower();

                string fileName = $"{uniqueName}.{extension}";

                if (extension == "jpg" || extension == "gif" || extension == "png" || extension == "jpeg")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1"; //dosyanı ismini sorgular aynı ismi kullanmaması için
                    }
                    else
                    {
                        string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    return "2"; //uygun formatta değil
                }
            }
            else
            {
                return "3"; //dosya boş
            }
        }
    }
}
