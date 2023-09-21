using CQRSAndMediatRDemo.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CQRSAndMediatRDemo.Application.Queries
{
    public class StudentQuery : IStudentQuery
    {
        private readonly string _connectionstring;
        public StudentQuery(string connectionstring) { _connectionstring = connectionstring; }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   

        public async Task<List<StudentDetails>> GetAllStudents()
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionstring);
            sqlConnection.Open();
            var students = await sqlConnection.QueryAsync<StudentDetails>("SELECT * FROM StudentDetails");
            sqlConnection.Close();
            return (List<StudentDetails>)students;
        }

        public async Task<StudentDetails> GetStudentByEmail(string email)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionstring);
            sqlConnection.Open();
            var students = await sqlConnection.QueryFirstOrDefaultAsync<StudentDetails>("SELECT * FROM StudentDetails WHERE StudentEmail=@email", new {email});
            sqlConnection.Close();
            return students;
        }

        public async Task<StudentDetails> GetStudentById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionstring);
            sqlConnection.Open();
            var students = await sqlConnection.QueryFirstOrDefaultAsync<StudentDetails>("SELECT * FROM StudentDetails WHERE id=@id", new { id });
            sqlConnection.Close();
            return students;
        }
    }
}
