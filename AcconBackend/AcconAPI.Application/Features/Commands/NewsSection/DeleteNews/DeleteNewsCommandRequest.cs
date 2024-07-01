using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.NewsSection.DeleteNews;

public class DeleteNewsCommandRequest : IRequest<ResponseModel<DeleteNewsCommandResponse>>
{
    public Guid Id { get; set; }
}