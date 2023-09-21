using CQRSAndMediatRDemo.Domain.SeedWork;
using CQRSAndMediatRDemo.Models;

namespace CQRSAndMediatRDemo.Domain.AggregatesModel
{
    public interface IStudentRepository : IRepository<StudentDetails>
    {
        public Task<List<StudentDetails>> GetStudentListAsync();
        public Task<StudentDetails> GetStudentByIdAsync(int Id);
        public Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails);
        public Task<int> UpdateStudentAsync(StudentDetails studentDetails);
        public Task<int> DeleteStudentAsync(int Id);
    }
}