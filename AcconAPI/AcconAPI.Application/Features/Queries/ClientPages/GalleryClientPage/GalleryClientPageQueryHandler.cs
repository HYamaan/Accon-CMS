using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Models.DTOs.Response.ClientPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.GalleryPage;

public class GalleryClientPageQueryHandler:IRequestHandler<GalleryClientPageQueryRequest,ResponseModel<GalleryClientPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.GalleryPage> _galleryPageRepository;

    public GalleryClientPageQueryHandler(IGenericRepository<Domain.Entities.Page.GalleryPage> galleryPageRepository)
    {
        _galleryPageRepository = galleryPageRepository;
    }

    public async Task<ResponseModel<GalleryClientPageQueryResponse>> Handle(GalleryClientPageQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _galleryPageRepository.GetWhere(x => x.IsPublished == true)
                .Include(x => x.Galleries)
                .ThenInclude(x => x.GalleryPhoto)
                .FirstOrDefaultAsync();


            if (result == null)
                return ResponseModel<GalleryClientPageQueryResponse>.Fail("Gallery Page null");

            var response = new GalleryClientPageQueryResponse()
            {
                Heading = result.Heading,
                MetaTitle = result.MetaTitle,
                MetaDescription = result.MetaDescription,
                MetaKeywords = result.MetaKeywords,
                Galleries = result.Galleries.Select(x => new GetClientGalleryDTOs()
                {
                    Title = x.Title,
                    Photo = x.GalleryPhoto.Path,
                }).ToList()

            };

            return ResponseModel<GalleryClientPageQueryResponse>.Success(response);
        }
        catch (Exception e)
        {
            return ResponseModel<GalleryClientPageQueryResponse>.Fail(e.Message);
        }
    }
}