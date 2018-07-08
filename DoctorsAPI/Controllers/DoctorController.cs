using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorsAPI.Model.DBContext;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAPI.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorsDBContext doctorsDBContext;
        public DoctorController(DoctorsDBContext _doctorsDBContext)
        {
            doctorsDBContext = _doctorsDBContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> Get()
        {
            return doctorsDBContext.Doctor.Include("Email").Include("Phone").ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Doctor> Get(int id)
        {
            return doctorsDBContext.Doctor.FirstOrDefault(doc => doc.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
