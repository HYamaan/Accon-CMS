using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.NewsSection.DeleteNewsCategory;

public class DeleteNewsCategoryCommandRequest : IRequest<ResponseModel<DeleteNewsCategoryCommandResponse>>
{
    public Guid Id { get; set; }
}