using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.Pages.AboutPage;

public class AboutPageCommandRequest: IRequest<ResponseModel<AboutPageCommandResponse>>
{

    public string? Id { get; set; }
    public IFormFile? Photo { get; set; }
    public string AboutHeader { get; set; }
    public string AboutContent { get; set; }
    public string MissionHeader { get; set; }
    public string MissionContent { get; set; }
    public string VisionHeader { get; set; }
    public string VisionContent { get; set; }

    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }


}
