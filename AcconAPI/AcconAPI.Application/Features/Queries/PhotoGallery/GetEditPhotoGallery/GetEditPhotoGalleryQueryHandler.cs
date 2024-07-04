using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Gallery;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.PhotoGallery.GetEditPhotoGallery;

public class GetEditPhotoGalleryQueryHandler:IRequestHandler<GetEditPhotoGalleryQueryRequest,ResponseModel<GetEditPhotoGalleryQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Gallery.Gallery> _galleryRepository;

    public GetEditPhotoGalleryQueryHandler(IGenericRepository<Gallery> galleryRepository)
    {
        _galleryRepository = galleryRepository;
    }

    public async Task<ResponseModel<GetEditPhotoGalleryQueryResponse>> Handle(GetEditPhotoGalleryQueryRequest request, CancellationToken cancellationToken)
    {
        if(request.Id==Guid.Empty)
            return  ResponseModel<GetEditPhotoGalleryQueryResponse>.Fail("Id is required");

        var gallery = await _galleryRepository.GetWhere(x => x.Id == request.Id)
            .Include(x => x.GalleryPhoto)
            .Select(x => new GetEditPhotoGalleryQueryResponse()
            {
                Id = x.Id,
                Title = x.Title,
                Photo = x.GalleryPhoto.Path,
                VisiblePlace = x.IsVisible

            })
            .FirstOrDefaultAsync();


        return ResponseModel<GetEditPhotoGalleryQueryResponse>.Success(gallery);
    }
}