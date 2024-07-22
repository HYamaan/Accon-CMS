using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Settings.EmailSettings;

public class EmailSettingsQueryRequest : IRequest<ResponseModel<EmailSettingsQueryResponse>>
{
    
}