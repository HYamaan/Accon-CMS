using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.SocialMedia;

public class GetAllSocialMediaQueryResponse
{
    public List<GetAllSocialMediaResponseDTOs> socials { get; set; }
}