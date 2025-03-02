using DoctorFunctionality.Models;
using DoctorFunctionality.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFunctionality.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddDoctor([FromBody] Doctor doctor)
        {
            int result = _doctorService.AddDoctor(doctor);
            return Json(new { success = result > 0 });
        }

        [HttpGet]
        public JsonResult GetDoctors()
        {
            var doctors = _doctorService.GetDoctors();
            return Json(doctors);
        }
      
        [HttpPost]
        public JsonResult DeleteDoctor([FromBody] int doctorId)
        {
            if (doctorId == 0)
            {
                return Json(new { success = false, message = "Invalid doctor ID received!" });
            }

            bool isDeleted = _doctorService.DeleteDoctor(doctorId);
            return Json(new { success = isDeleted });
        }

        [HttpPost]
       
        public JsonResult EditDoctor([FromBody] Doctor doctor)
        {
            if (doctor == null || doctor.DoctorId == 0)
            {
                return Json(new { success = false, message = "Invalid doctor data received!" });
            }

            bool isUpdated = _doctorService.EditDoctor(doctor);
            return Json(new { success = isUpdated });
        }

    }
}
