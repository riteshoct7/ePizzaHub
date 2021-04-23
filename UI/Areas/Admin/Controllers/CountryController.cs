using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace UI.Areas.Admin.Controllers
{    
    public class CountryController : BaseController
    {

        #region Properties

        ICountryService countryService;

        #endregion

        #region Constructors

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        #endregion

        #region Methods

        public IActionResult AllCountries()
        {
            return View(countryService.GetCountries());        } 

        #endregion
    }
}
