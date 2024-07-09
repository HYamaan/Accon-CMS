using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.NewsSection.UpdateNews;

public class UpdateNewsCommandRequest : IRequest<ResponseModel<UpdateNewsCommandResponse>>
{   
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string ShortContent { get; set; }
    public string Content { get; set; }
    public bool IsPublished { get; set; }
    public DateTime PublishDate { get; set; }
    public Guid NewsCategoryId { get; set; }
    public bool CommentShow { get; set; }

    public IFormFile? FeaturedPhoto { get; set; }
    public IFormFile? BannerPhoto { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeyword { get; set; }
}