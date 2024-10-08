using MediatR;
using Reserving.Domain.Abstractions;

namespace Reserving.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
 where TQuery : IQuery<TResponse>
{
}