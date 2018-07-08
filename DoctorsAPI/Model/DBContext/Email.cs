using System;
using System.Collections.Generic;

namespace DoctorsAPI.Model.DBContext
{
    public partial class Email
    {
        public int Id { get; set; }
        public string MailId { get; set; }
        public int? DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
