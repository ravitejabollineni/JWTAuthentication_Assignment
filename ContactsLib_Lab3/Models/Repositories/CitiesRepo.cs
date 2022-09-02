using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsLib.Models.Repositories
{
    public class CitiesRepo:ICitiesRepo
    {
        private WebApiCoreAssignmentContext _context;
        public CitiesRepo(WebApiCoreAssignmentContext context)
        {
            _context = context;
        }

        public List<City> GetCities()
        {
            return _context.Cities.ToList();
        }
    }
}
