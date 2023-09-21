using CQRSAndMediatRDemo.Domain.SeedWork;

namespace CQRSAndMediatRDemo.Models
{
    public class StudentDetails: Entity,IAggregateRoot
    {
        public string? StudentName { get; set; }
        public string? StudentEmail { get; set; }
        public string? StudentAddress { get; set; }
        public int? StudentAge { get; set; }
    }
}
