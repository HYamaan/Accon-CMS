using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.Languages;

public class GetAllLanguagesQueryResponse
{
    public List<GetAllLanguageResponseDTOs> Languages { get; set; }
}