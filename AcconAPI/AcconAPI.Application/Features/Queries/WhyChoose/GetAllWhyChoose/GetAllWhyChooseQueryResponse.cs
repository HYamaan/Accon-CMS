using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.WhyChoose.GetAllWhyChoose;

public class GetAllWhyChooseQueryResponse
{
    public List<GetAllWhyChooseUsResponseDTOs> WhyChoose { get; set; }
}