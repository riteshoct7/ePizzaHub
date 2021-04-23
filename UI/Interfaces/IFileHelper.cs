using Microsoft.AspNetCore.Http;

namespace UI.Interfaces
{
    public interface IFileHelper
    {
        #region Methods

        void DeleteFile(string imageURL);
        string UploadFile(IFormFile file); 

        #endregion

    }
}
