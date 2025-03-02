using DoctorFunctionality.Models;

namespace DoctorFunctionality.Repository
{
    public interface IDoctorRepository
    {
        int AddDoctor(Doctor doctor);
        List<Doctor> GetDoctors();
        bool DeleteDoctor(int doctorId);
        bool UpdateDoctor(Doctor doctor);
        
    }
}
