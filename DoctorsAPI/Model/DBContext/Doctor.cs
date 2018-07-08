using System;
using System.Collections.Generic;

namespace DoctorsAPI.Model.DBContext
{
    public partial class Doctor
    {
        public Doctor()
        {
            Email = new HashSet<Email>();
            Location = new HashSet<Location>();
            Phone = new HashSet<Phone>();
        }

        public int Id { get; set; }
        public string Fname { get; set; }
        public string MiddleName { get; set; }
        public string Lname { get; set; }
        public string PhotosUrl { get; set; }
        public int? Rates { get; set; }
        public int? SpecialityId { get; set; }
        public string Description { get; set; }

        public Specialty Speciality { get; set; }
        public ICollection<Email> Email { get; set; }
        public ICollection<Location> Location { get; set; }
        public ICollection<Phone> Phone { get; set; }
    }
}
