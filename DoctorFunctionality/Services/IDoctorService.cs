using DoctorFunctionality.Models;

namespace DoctorFunctionality.Services
{
    public interface IDoctorService
    {
        int AddDoctor(Doctor doctor);
        List<Doctor> GetDoctors();
        bool DeleteDoctor(int doctorId);
        bool EditDoctor(Doctor doctor);
    }
}
