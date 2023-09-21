using CQRSAndMediatRDemo.Models;

namespace CQRSAndMediatRDemo.Application.Queries
{
    public interface IStudentQuery 
    {
        Task<StudentDetails> GetStudentById(int id);
        Task<StudentDetails> GetStudentByEmail(string email);      
        Task<List<StudentDetails>> GetAllStudents();
    }
}
