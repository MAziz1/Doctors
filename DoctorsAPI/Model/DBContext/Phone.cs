using System;
using System.Collections.Generic;

namespace DoctorsAPI.Model.DBContext
{
    public partial class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int? DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
