using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Faq.UpdateFaq;

public class FaqCommandResponse : IRequest<ResponseModel<FaqCommandRequest>>
{

}