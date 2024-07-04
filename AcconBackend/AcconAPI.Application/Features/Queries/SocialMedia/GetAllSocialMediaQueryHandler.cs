using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.SocialMedia;

public class GetAllSocialMediaQueryHandler:IRequestHandler<GetAllSocialMediaQueryRequest,ResponseModel<GetAllSocialMediaQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.SocialMedia.SocialMedia> _socialMediaRepository;

    public GetAllSocialMediaQueryHandler(IGenericRepository<Domain.Entities.SocialMedia.SocialMedia> socialMediaRepository)
    {
        _socialMediaRepository = socialMediaRepository;
    }

    public async Task<ResponseModel<GetAllSocialMediaQueryResponse>> Handle(GetAllSocialMediaQueryRequest request, CancellationToken cancellationToken)
    {
        var socialMediaList = await _socialMediaRepository.GetAll()
            .Select(x=> new GetAllSocialMediaResponseDTOs()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
            }).ToListAsync(cancellationToken);

        var response = new GetAllSocialMediaQueryResponse()
        {
            socials = socialMediaList
        };

        return ResponseModel<GetAllSocialMediaQueryResponse>.Success(response);
    }
}