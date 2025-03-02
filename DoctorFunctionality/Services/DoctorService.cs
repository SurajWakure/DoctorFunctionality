using DoctorFunctionality.Models;
using DoctorFunctionality.Repository;

namespace DoctorFunctionality.Services
{
    public class DoctorService:IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public int AddDoctor(Doctor doctor)
        {
            return _doctorRepository.AddDoctor(doctor);
        }

        public List<Doctor> GetDoctors()
        {
            return _doctorRepository.GetDoctors();
        }
        public bool DeleteDoctor(int doctorId)
        {
            return _doctorRepository.DeleteDoctor(doctorId);
        }
        public bool EditDoctor(Doctor doctor)
        {
            return _doctorRepository.UpdateDoctor(doctor);
        }


    }
}
