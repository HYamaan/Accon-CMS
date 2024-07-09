using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Pages.GalleryPage;

public class GalleryPageQueryHandler: IRequestHandler<GalleryPageQueryRequest, ResponseModel<GalleryPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.GalleryPage> _galleryRepository;

    public GalleryPageQueryHandler(IGenericRepository<Domain.Entities.Page.GalleryPage> galleryRepository)
    {
        _galleryRepository = galleryRepository;
    }

    public async Task<ResponseModel<GalleryPageQueryResponse>> Handle(GalleryPageQueryRequest request, CancellationToken cancellationToken)
    {
        var gallery = await _galleryRepository.GetAll().FirstOrDefaultAsync();
        if (gallery == null)
        {
            return ResponseModel<GalleryPageQueryResponse>.Fail("Gallery not found");
        }

        var response = new GalleryPageQueryResponse()
        {
            Title = gallery.Heading,
            MetaTitle = gallery.MetaTitle,
            MetaDescription = gallery.MetaDescription,
            MetaKeywords = gallery.MetaKeywords
        };
        return  ResponseModel<GalleryPageQueryResponse>.Success(response);
    }
}