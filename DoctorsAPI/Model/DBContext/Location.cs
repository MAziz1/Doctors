using System;
using System.Collections.Generic;

namespace DoctorsAPI.Model.DBContext
{
    public partial class Location
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ArlocationName { get; set; }
        public string EnlocationName { get; set; }
        public int? DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
