using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.ClientPages.ServiceClientContentPage;

public class ServiceClientContentPageQueryRequest : IRequest<ResponseModel<ServiceClientContentPageQueryResponse>>
{
 public Guid Id { get; set; }
}