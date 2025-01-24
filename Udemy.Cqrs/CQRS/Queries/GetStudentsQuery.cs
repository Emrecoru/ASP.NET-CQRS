using MediatR;
using Udemy.Cqrs.CQRS.Results;

namespace Udemy.Cqrs.CQRS.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<GetStudentsQueryResult>>
    {
    }
}
