using System;
using System.Collections.Generic;

#nullable disable

namespace ContactsLib.Models
{
    public partial class Contact
    {
        public int ContactNo { get; set; }
        public string ContactName { get; set; }
        public string CityName { get; set; }
        public long CellNo { get; set; }
    }
}
