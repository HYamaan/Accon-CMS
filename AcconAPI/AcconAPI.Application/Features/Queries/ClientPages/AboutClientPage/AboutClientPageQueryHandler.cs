using AcconAPI.Application.Features.Queries.Pages.AboutPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.AboutPage;

public class AboutClientPageQueryHandler:IRequestHandler<AboutClientPageQueryRequest,ResponseModel<AboutClientPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.AboutPage> _aboutPageRepository;

    public AboutClientPageQueryHandler(IGenericRepository<Domain.Entities.Page.AboutPage> aboutPageRepository)
    {
        _aboutPageRepository = aboutPageRepository;
    }

    public async Task<ResponseModel<AboutClientPageQueryResponse>> Handle(AboutClientPageQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _aboutPageRepository.GetWhere(x=>x.IsPublished == true)
            .Include(x => x.Photo)
            .FirstOrDefaultAsync();

        if (result == null)
            return ResponseModel<AboutClientPageQueryResponse>.Fail("About Page null");

        var response = new AboutClientPageQueryResponse()
        {
            Content = result.Content,
            Title = result.Heading,
            MetaDescription = result.MetaDescription,
            MetaKeywords = result.MetaKeywords,
            MetaTitle = result.MetaTitle,
            MissionContent = result.MissionContent,
            MissionTitle = result.MissionHeading,
            VisionContent = result.VisionContent,
            VisionTitle = result.VisionHeading,
            Photo = result.Photo.Path
        };
        return ResponseModel<AboutClientPageQueryResponse>.Success(response);
    }
}