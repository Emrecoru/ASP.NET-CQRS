using MediatR;
using Udemy.Cqrs.CQRS.Commands;
using Udemy.Cqrs.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Udemy.Cqrs.CQRS.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _context;

        public UpdateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updatedEntity = await _context.Students.FindAsync(request.Id);

            updatedEntity.Name = request.Name;
            updatedEntity.Surname = request.Surname;
            updatedEntity.Age = request.Age;
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
        //public void Handle(UpdateStudentCommand command)
        //{
        //    var updatedEntity = _context.Students.Find(command.Id);
        //    updatedEntity.Name = command.Name;
        //    updatedEntity.Surname = command.Surname;
        //    updatedEntity.Age = command.Age;
        //    _context.SaveChanges();
        //}
    }
}
