using Entities;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICountryService
    {
        #region Methods
        IEnumerable<Country> GetCountries(); 
        #endregion
    }
}
