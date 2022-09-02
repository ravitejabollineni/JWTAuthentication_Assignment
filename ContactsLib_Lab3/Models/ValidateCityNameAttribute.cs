using ContactsLib.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ContactsLib.Models
{
    public class ValidateCityNameAttribute : ValidationAttribute
    {
        WebApiCoreAssignmentContext context = new WebApiCoreAssignmentContext();
        CitiesRepo citiesRepo;
        public ValidateCityNameAttribute()
        {
            citiesRepo = new CitiesRepo(context);
        }


        public override bool IsValid(object value)
        {
            bool Isfound = false;
            string city = value.ToString().ToLower();
            List<City> list = citiesRepo.GetCities();
            int c = list.Count(x => x.CityName.ToLower() == city);
            if (c > 0)
                Isfound = true;
            return Isfound;

        }
    }
}
