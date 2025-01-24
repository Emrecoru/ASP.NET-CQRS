using MediatR;
using Udemy.Cqrs.CQRS.Commands;
using Udemy.Cqrs.Data;

namespace Udemy.Cqrs.CQRS.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _context;

        public CreateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            await _context.Students.AddAsync(new Student { Name = request.Name, Surname = request.Surname, Age = request.Age });
            await _context.SaveChangesAsync();

            return Unit.Value;
        }

        //public void Handle(CreateStudentCommand command)
        //{
        //    _context.Students.Add(new Student { Name = command.Name, Surname = command.Surname, Age = command.Age });
        //    _context.SaveChanges();
        //}

    }
}
