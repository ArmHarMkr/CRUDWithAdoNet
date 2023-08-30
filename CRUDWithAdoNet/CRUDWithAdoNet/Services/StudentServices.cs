using CRUDWithAdoNet.Models;
using Microsoft.Data.SqlClient;

namespace CRUDWithAdoNet.Services
{
    public class StudentServices : IStudentServices
    {
        public string Constr { get; set; }
        public IConfiguration _configuration { get; set; }
        public SqlConnection con;

        public StudentServices(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DBConnection");
        }

        public List<Students> GetStudentsRecord()
        {
            List<Students> studentList = new List<Students>();
            try
            {
                using (con = new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd = new SqlCommand("SP_GetStudentsRecords", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        Students std = new Students();
                        std.StudentId = Convert.ToInt32(rdr["StudentId"]);
                        std.StudentName = rdr["StudentName"].ToString();
                        std.EmailAddress = rdr["EmailAddress"].ToString();

                        studentList.Add(std);
                    }
                }
                return studentList.ToList();
                
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

    public interface IStudentServices
    {
        public List<Students> GetStudentsRecord();
    }
}
