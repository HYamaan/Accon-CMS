using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Page;

public class GetPageQueryHandler : IRequestHandler<GetPageQueryRequest, ResponseModel<GetPageQueryResponse>>
{
    private readonly IGenericRepository<PageEntity> _pageEntity;

    public GetPageQueryHandler(IGenericRepository<PageEntity> pageEntity)
    {
        _pageEntity = pageEntity;
    }

    public async Task<ResponseModel<GetPageQueryResponse>> Handle(GetPageQueryRequest request, CancellationToken cancellationToken)
    {
        var pages = await _pageEntity.GetAll(false)
            .Include(p => (p as AboutPage).Photo)
                                     .ToListAsync(cancellationToken);

        var pageDtos = pages.Select(page => CreatePageDto(page)).ToList();

        var response = new GetPageQueryResponse
        {
            Pages = pageDtos
        };

        return ResponseModel<GetPageQueryResponse>.Success(response);
    }

    private static object CreatePageDto(PageEntity page)
    {
        if (page is AboutPage aboutPage)
        {
            return new AboutPageDto
            {
                Id = aboutPage.Id,
                Page = page.GetType().Name,
                Heading = aboutPage.Heading,
                MetaTitle = aboutPage.MetaTitle,
                MetaDescription = aboutPage.MetaDescription,
                MetaKeywords = aboutPage.MetaKeywords,
                Path = aboutPage.Photo.Path,
                Content = aboutPage.Content,
                MissionHeading = aboutPage.MissionHeading,
                MissionContent = aboutPage.MissionContent,
                VisionHeading = aboutPage.VisionHeading,
                VisionContent = aboutPage.VisionContent
            };
        }
        return new GeneralPageDTOs()
        {
            Id = page.Id,
            Page = page.GetType().Name,
            Heading = page.Heading,
            MetaTitle = page.MetaTitle,
            MetaDescription = page.MetaDescription,
            MetaKeywords = page.MetaKeywords
        };
    }
}
