using AcconAPI.Domain.Common;
using MediatR;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace AcconAPI.Application.Features.Commands.Settings.GeneralContent.GeneralInformation;

public class GeneralContentCommandRequest : IRequest<ResponseModel<GeneralContentCommandResponse>>
{
    public string FooterCopyRight { get; set; }
    public string FooterAdress { get; set; }
    public string FooterPhone { get; set; }
    public string FooterWorkingHours { get; set; }
    public string FooterAboutUs { get; set; }
    public string TopBarEmail { get; set; }
    public string TopBarPhone { get; set; }
    public string ContactMap { get; set; }

}