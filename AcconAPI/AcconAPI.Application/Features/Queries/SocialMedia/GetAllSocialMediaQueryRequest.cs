using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.SocialMedia;

public class GetAllSocialMediaQueryRequest : IRequest<ResponseModel<GetAllSocialMediaQueryResponse>>
{

}