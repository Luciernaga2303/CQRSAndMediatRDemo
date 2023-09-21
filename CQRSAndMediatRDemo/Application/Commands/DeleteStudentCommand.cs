using MediatR;

namespace CQRSAndMediatRDemo.Application.Commands
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}