using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Pages.AboutPage;

public class AboutPageQueryHandler:IRequestHandler<AboutPageQueryRequest, ResponseModel<AboutPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.AboutPage> _aboutPageRepository;

    public AboutPageQueryHandler(IGenericRepository<Domain.Entities.Page.AboutPage> aboutPageRepository)
    {
        _aboutPageRepository = aboutPageRepository;
    }

    public async Task<ResponseModel<AboutPageQueryResponse>> Handle(AboutPageQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _aboutPageRepository.GetAll()
            .Include(x => x.Photo)
            .FirstOrDefaultAsync();

        if(result == null)
            return ResponseModel<AboutPageQueryResponse>.Fail("About Page null");

        var response = new AboutPageQueryResponse()
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
        return ResponseModel<AboutPageQueryResponse>.Success(response);
    }
}