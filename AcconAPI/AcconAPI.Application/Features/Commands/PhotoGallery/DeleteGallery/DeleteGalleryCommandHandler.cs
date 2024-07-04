using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Gallery;
using MediatR;

namespace AcconAPI.Application.Features.Commands.PhotoGallery.DeleteGallery;

public class DeleteGalleryCommandHandler:IRequestHandler<DeleteGalleryCommandRequest, ResponseModel<DeleteGalleryCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Gallery.Gallery> _galleryRepository;

    public DeleteGalleryCommandHandler(IGenericRepository<Gallery> galleryRepository)
    {
        _galleryRepository = galleryRepository;
    }

    public async Task<ResponseModel<DeleteGalleryCommandResponse>> Handle(DeleteGalleryCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return  ResponseModel<DeleteGalleryCommandResponse>.Fail("Invalid Id");
        }

        var responseGallery = await _galleryRepository.GetByIdAsync(request.Id.ToString());
        if (responseGallery == null)
        {
            return ResponseModel<DeleteGalleryCommandResponse>.Fail("Gallery not found");
        }
        await _galleryRepository.RemoveAsync(request.Id.ToString());
        await _galleryRepository.SaveAsync();

        return ResponseModel<DeleteGalleryCommandResponse>.Success("Gallery Deleted");


    }
}