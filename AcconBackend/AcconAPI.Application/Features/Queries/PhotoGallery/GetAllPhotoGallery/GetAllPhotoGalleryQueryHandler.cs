using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.PhotoGallery.GetAllPhotoGallery;

public class GetAllPhotoGalleryQueryHandler : IRequestHandler<GetAllPhotoGalleryQueryRequest, ResponseModel<GetAllPhotoGalleryQueryResponse>>
{
    private readonly IGenericRepository<GalleryPage> _galeryPageRepository;
    private readonly IGenericRepository<Domain.Entities.Gallery.Gallery> _galleryRepository;

    public GetAllPhotoGalleryQueryHandler(IGenericRepository<GalleryPage> galeryPageRepository, IGenericRepository<Domain.Entities.Gallery.Gallery> galleryRepository)
    {
        _galeryPageRepository = galeryPageRepository;
        _galleryRepository = galleryRepository;
    }

    public async Task<ResponseModel<GetAllPhotoGalleryQueryResponse>> Handle(GetAllPhotoGalleryQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _galeryPageRepository.GetAll().FirstOrDefaultAsync();
        var gallery = await _galleryRepository.GetAll()
            .Include(x => x.GalleryPhoto)
            .Select(x => new GetAllGalleryResponseDTOs()
            {
                Id = x.Id,
                Title = x.Title,
                Photo = x.GalleryPhoto.Path,
                VisiblePlace = x.IsVisible
            }).ToListAsync();

        var response = new GetAllPhotoGalleryQueryResponse()
        {
            MetaTitle = result.MetaTitle,
            MetaDescription = result.MetaDescription,
            MetaKeywords = result.MetaKeywords,
            gallery = gallery
        };


        return ResponseModel<GetAllPhotoGalleryQueryResponse>.Success(response);
    }
}