using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Pages.TermsPage;

public class TermsPageCommandRequest: IRequest<ResponseModel<TermsPageCommandResponse>>
{
    public string Heading { get; set; }
    public string Content { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
}