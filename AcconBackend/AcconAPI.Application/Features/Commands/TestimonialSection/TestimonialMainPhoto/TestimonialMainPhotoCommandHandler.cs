using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.TestimonialSection.TestimonialMainPhoto;

public class TestimonialMainPhotoCommandHandler : IRequestHandler<TestimonialMainPhotoCommandRequest,
    ResponseModel<TestimonialMainPhotoCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.Testimonial.TestimonialMainPhoto> _testimonialMainPhotoRepository;
    private readonly IFileCheckHelper _fileCheckHelper;
    private readonly IStorageService _storageService;

    public TestimonialMainPhotoCommandHandler(IGenericRepository<Domain.Entities.File.Testimonial.TestimonialMainPhoto> testimonialMainPhotoRepository,
        IFileCheckHelper fileCheckHelper, IStorageService storageService)
    {
        _testimonialMainPhotoRepository = testimonialMainPhotoRepository;
        _fileCheckHelper = fileCheckHelper;
        _storageService = storageService;
    }

    public async Task<ResponseModel<TestimonialMainPhotoCommandResponse>> Handle(
        TestimonialMainPhotoCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if(!await _fileCheckHelper.CheckImageFormat(request.Photo))
                return ResponseModel<TestimonialMainPhotoCommandResponse>.Fail("File extension is not valid.");

            var getMainPhoto = await _testimonialMainPhotoRepository.GetAll().FirstOrDefaultAsync();
            await _testimonialMainPhotoRepository.BeginTransactionAsync();
            if (getMainPhoto != null)
            {
                await _storageService.DeleteAsync(getMainPhoto.Path, getMainPhoto.FileName);
                await _testimonialMainPhotoRepository.RemoveAsync(getMainPhoto.Id.ToString());
            }
            else
            {
                var storage = await _storageService.UploadAsync("files", request.Photo);
                var testimonialMainPhoto = new Domain.Entities.File.Testimonial.TestimonialMainPhoto
                {
                    Path = storage.pathOrContainerName,
                    FileName = storage.fileName,
                    Storage = _storageService.StorageName
                };
                await _testimonialMainPhotoRepository.AddAsync(testimonialMainPhoto);
            }

            await _testimonialMainPhotoRepository.CommitTransactionAsync();
            await _testimonialMainPhotoRepository.SaveAsync();
            return ResponseModel<TestimonialMainPhotoCommandResponse>.Success();
        }
        catch (Exception e)
        {
            await _testimonialMainPhotoRepository.RollbackTransactionAsync();
            return ResponseModel<TestimonialMainPhotoCommandResponse>.Fail(e.Message);
        }

    }
}
