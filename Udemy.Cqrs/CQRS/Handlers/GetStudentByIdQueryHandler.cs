using MediatR;
using Udemy.Cqrs.CQRS.Queries;
using Udemy.Cqrs.CQRS.Results;
using Udemy.Cqrs.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Udemy.Cqrs.CQRS.Handlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentByIdQueryResult>
    {
        private readonly StudentContext _context;

        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(request.Id);

            return new GetStudentByIdQueryResult { Name = student.Name, Surname = student.Surname, Age = student.Age };
        }

    }
}
