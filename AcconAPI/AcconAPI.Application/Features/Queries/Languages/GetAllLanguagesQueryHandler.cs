using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Language;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Languages;

public class GetAllLanguagesQueryHandler:IRequestHandler<GetAllLanguagesQueryRequest, ResponseModel<GetAllLanguagesQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Language.Language> _languageRepository;

    public GetAllLanguagesQueryHandler(IGenericRepository<Language> languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public async Task<ResponseModel<GetAllLanguagesQueryResponse>> Handle(GetAllLanguagesQueryRequest request, CancellationToken cancellationToken)
    {
        var languages = await _languageRepository.GetAll()
            .Select(x => new GetAllLanguageResponseDTOs()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content
            }).ToListAsync()
            ;
        var response = new GetAllLanguagesQueryResponse()
        {
            Languages = languages
        };
        return  ResponseModel<GetAllLanguagesQueryResponse>.Success(response);
    }
}