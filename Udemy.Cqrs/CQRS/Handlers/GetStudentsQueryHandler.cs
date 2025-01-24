using MediatR;
using Microsoft.EntityFrameworkCore;
using Udemy.Cqrs.CQRS.Queries;
using Udemy.Cqrs.CQRS.Results;
using Udemy.Cqrs.Data;

namespace Udemy.Cqrs.CQRS.Handlers
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<GetStudentsQueryResult>>
    {
        private readonly StudentContext _context;
        public GetStudentsQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname }).AsNoTracking().ToListAsync();
        }

        //public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery query)
        //{
        //    return _context.Set<Student>().Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname }).AsNoTracking().AsEnumerable();
        //}

    }
}
