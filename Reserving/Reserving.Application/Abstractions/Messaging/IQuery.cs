using MediatR;
using Reserving.Domain.Abstractions;

namespace Reserving.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}