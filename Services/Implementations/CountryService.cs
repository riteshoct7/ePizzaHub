using Entities;
using Repository.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Implementations
{
    public class CountryService : ICountryService
    {

        #region Properties

        ICountryRepository countryRepository;

        #endregion

        #region Constructors

        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        #endregion

        #region Methods

        public IEnumerable<Country> GetCountries()
        {
            return countryRepository.GetAll();
        } 

        #endregion
    }
}
