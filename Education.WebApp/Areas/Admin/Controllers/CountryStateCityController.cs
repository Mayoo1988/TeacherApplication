using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Education.Core.CountryStateCity;
using Education.Entity.CountryEntity;

namespace Education.WebApp.Areas.Admin.Controllers
{
    public class CountryStateCityController : Controller
    {
        ICountryStateCityReposetory _CountryStateCityReposetory;

        public CountryStateCityController(ICountryStateCityReposetory reposetory)
        {
            
          this. _CountryStateCityReposetory = reposetory;
        }

        // GET: Admin/CountryStateCity

        public List<Country> GetCountry()
        {

            return _CountryStateCityReposetory.GetCountry();
        }
        [HttpPost]
        public List<State> GetState(int CountryID)
        {

            return _CountryStateCityReposetory.GetState(CountryID);
        }
        [HttpPost]
        public List<City> GetCity(int StateID)
        {

            return _CountryStateCityReposetory.GetCity(StateID);
        }
    }
}