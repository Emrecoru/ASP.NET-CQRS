using MediatR;
using Udemy.Cqrs.CQRS.Commands;
using Udemy.Cqrs.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Udemy.Cqrs.CQRS.Handlers
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _context;
        public RemoveStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var deletedEntity = _context.Students.Find(request.Id);
            _context.Students.Remove(deletedEntity);
            _context.SaveChangesAsync();
            return Unit.Value;
        }

        //public void Handle(RemoveStudentCommand command)
        //{
        //    var deletedEntity = _context.Students.Find(command.Id);
        //    _context.Students.Remove(deletedEntity);
        //    _context.SaveChanges();

        //}
    }
}
