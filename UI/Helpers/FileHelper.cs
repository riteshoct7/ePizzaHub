using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using UI.Interfaces;

namespace UI.Helpers
{
    public class FileHelper : IFileHelper
    {
        #region Properties
        IWebHostEnvironment env;
        #endregion

        #region Constructors
        public FileHelper(IWebHostEnvironment env)
        {
            this.env = env;
        }
        #endregion

        #region Methods

        public void DeleteFile(string imageURL)
        {
            if (File.Exists(env.WebRootPath+imageURL))
            {
                File.Delete(env.WebRootPath + imageURL);
            }
        }

        private string GenerateFileName(string fileName)
        {
            string[] strName = fileName.Split(',');
            string strFileName = DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff")+"." + strName[strName.Length - 1];
            return strFileName;
        }

        public string UploadFile(IFormFile file)
        {
            var uploads = Path.Combine(env.WebRootPath, "images");
            bool exists = Directory.Exists(uploads);
            if (!exists)
                Directory.CreateDirectory(uploads);

            var fileName = GenerateFileName(file.FileName);
            var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
            file.CopyToAsync(fileStream);

            return "/images/" + fileName;
        } 

        #endregion
    }
}
