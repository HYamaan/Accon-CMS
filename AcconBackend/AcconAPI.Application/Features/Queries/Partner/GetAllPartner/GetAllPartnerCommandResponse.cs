using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.Partner.GetAllPartner;

public class GetAllPartnerCommandResponse
{
    public List<GetAllPartnerResponseDTOs> Partners { get; set; }
}