using System;
using System.Collections.Generic;

namespace DoctorsAPI.Model.DBContext
{
    public partial class Specialty
    {
        public Specialty()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public string Arname { get; set; }
        public string Enname { get; set; }

        public ICollection<Doctor> Doctor { get; set; }
    }
}
