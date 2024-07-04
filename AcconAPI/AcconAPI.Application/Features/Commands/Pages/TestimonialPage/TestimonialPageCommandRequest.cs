using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Pages.TestimonialPage;

public class TestimonialPageCommandRequest: IRequest<ResponseModel<TestimonialPageCommandResponse>>
{
    public string Heading { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
}