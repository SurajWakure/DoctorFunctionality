using DoctorFunctionality.Models;
using System.Data;
using System.Data.SqlClient;

namespace DoctorFunctionality.Repository
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly string _connectionString;

        public DoctorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public int AddDoctor(Doctor doctor)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddDoctor", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", doctor.Name);
                cmd.Parameters.AddWithValue("@Contact", doctor.Contact);
                cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Doctor> GetDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetDoctors", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    doctors.Add(new Doctor
                    {
                        DoctorId = Convert.ToInt32(reader["DoctorId"]),
                        Name = reader["Name"].ToString(),
                        Contact = reader["Contact"].ToString(),
                        Specialization = reader["Specialization"].ToString()
                    });
                }
            }
            return doctors;
        }
        public bool DeleteDoctor(int doctorId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteDoctor", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool UpdateDoctor(Doctor doctor)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateDoctor", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DoctorId", doctor.DoctorId);
                cmd.Parameters.AddWithValue("@Name", doctor.Name);
                cmd.Parameters.AddWithValue("@Contact", doctor.Contact);
                cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
