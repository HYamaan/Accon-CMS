using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.NewsSection.NewsCategory;

public class UpdateNewsCategoryCommandRequest : IRequest<ResponseModel<UpdateNewsCategoryCommandResponse>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}