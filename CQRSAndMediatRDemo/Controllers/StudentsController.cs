using CQRSAndMediatRDemo.Application.Commands;
using CQRSAndMediatRDemo.Application.Queries;
using CQRSAndMediatRDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CQRSAndMediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IStudentQuery _StudentQuery;

        public StudentsController(IMediator mediator, IStudentQuery studentQuery)
        {
            this.mediator = mediator;
            _StudentQuery = studentQuery;
        }

        [HttpGet]
        public async Task<List<StudentDetails>> GetStudentListAsync()
        {

            return await _StudentQuery.GetAllStudents();
        }

        [HttpGet("{studentId}")]
        public async Task<StudentDetails> GetStudentByIdAsync([FromRoute] int studentId)
        {
            return await _StudentQuery.GetStudentById(studentId);
        }

        [HttpGet("studentEmail")]

        public async Task<StudentDetails> GetStudentByEmailAsync( string studentEmail)
        {
            return await _StudentQuery.GetStudentByEmail(studentEmail);
        }

        [HttpPost]
        public async Task<StudentDetails> AddStudentAsync(CreateStudentCommand createStudentCommand)
        {
           return await mediator.Send(createStudentCommand);
        }

        [HttpPut]
        public async Task<int> UpdateStudentAsync(UpdateStudentCommand updateStudentCommand)
        {
            return await mediator.Send(updateStudentCommand);
        }

        [HttpDelete]
        public async Task<int> DeleteStudentAsync(DeleteStudentCommand deleteStudentCommand)
        {
            return await mediator.Send(deleteStudentCommand);
        }
    }
}