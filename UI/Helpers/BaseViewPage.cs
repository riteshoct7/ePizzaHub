using Entities;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using UI.Interfaces;

namespace UI.Helpers
{
    public abstract class BaseViewPage<TModel> : RazorPage<TModel>
    {
        #region Properties

        [RazorInject]
        public IUserAccessor userAccessor { get; set; }

        public User CurrentUser
        {
            get
            {
                if (User != null)
                    return userAccessor.GetUser();
                else
                    return null;
            }
        } 
        #endregion
    }
}
