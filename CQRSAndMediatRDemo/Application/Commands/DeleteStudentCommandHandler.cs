using CQRSAndMediatRDemo.Domain.AggregatesModel;
using MediatR;

namespace CQRSAndMediatRDemo.Application.Commands
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (studentDetails == null)
                return default;

            return await _studentRepository.DeleteStudentAsync(studentDetails.Id);
        }
    }
}