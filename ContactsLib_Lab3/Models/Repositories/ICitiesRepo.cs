using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsLib.Models
{
    public interface ICitiesRepo
    {
        List<City> GetCities();
    }
}
