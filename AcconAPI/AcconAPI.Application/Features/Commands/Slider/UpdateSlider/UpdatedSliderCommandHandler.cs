using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Slider.UpdateSlider;

public class UpdatedSliderCommandHandler : IRequestHandler<UpdatedSliderCommandRequest, ResponseModel<UpdatedSliderCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Slider.Slider> _sliderRepository;
    private readonly IFileCheckHelper _imageFileCheckHelper;
    private readonly IStorageService _storageService;
    private readonly IValidator<UpdatedSliderCommandRequest> _validator;

    public UpdatedSliderCommandHandler(IGenericRepository<Domain.Entities.Slider.Slider> slider, IStorageService storageService, IFileCheckHelper imageFileCheckHelper, IValidator<UpdatedSliderCommandRequest> validator)
    {
        _sliderRepository = slider;
        _storageService = storageService;
        _imageFileCheckHelper = imageFileCheckHelper;
        _validator = validator;
    }

    public async Task<ResponseModel<UpdatedSliderCommandResponse>> Handle(UpdatedSliderCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == null)
        {
            return await AddSlider(request, cancellationToken);
        }
        else
        {
            try
            {
                var sliderInfo = await _sliderRepository.GetWhere(p => p.Id == request.Id)
                    .Include(p => p.Photo).FirstOrDefaultAsync();

                if (sliderInfo == null)
                {
                    return await AddSlider(request, cancellationToken);
                }

                if (sliderInfo.Title != request.Heading) sliderInfo.Title = request.Heading;
                if (sliderInfo.Content != request.Content) sliderInfo.Content = request.Content;
                if (sliderInfo.Button1Text != request.Button1Text) sliderInfo.Button1Text = request.Button1Text;
                if (sliderInfo.Button1Link != request.Button1Link) sliderInfo.Button1Link = request.Button1Link;
                if (sliderInfo.Button2Text != request.Button2Text) sliderInfo.Button2Text = request.Button2Text;
                if (sliderInfo.Button2Link != request.Button2Link) sliderInfo.Button2Link = request.Button2Link;

                if (request.Photo != null && (sliderInfo.Photo.FileName != request.Photo.FileName && request.Photo.Length > 0))
                {
                    if (!await _imageFileCheckHelper.CheckImageFormat(request.Photo))
                    {
                        return ResponseModel<UpdatedSliderCommandResponse>.Fail("Invalid Image Format");
                    }

                    var photoData = await _storageService.UploadAsync("files", request.Photo);
                    var sliderPhotoModel = new SliderPhoto()
                    {
                        FileName = photoData.fileName,
                        Path = photoData.pathOrContainerName,
                        Storage = _storageService.StorageName,
                    };
                   sliderInfo.Photo = sliderPhotoModel;
                }

                _sliderRepository.Update(sliderInfo);
                await _sliderRepository.SaveAsync();

                return ResponseModel<UpdatedSliderCommandResponse>.Success();

            }
            catch (Exception e)
            {
                return ResponseModel<UpdatedSliderCommandResponse>.Fail(e.Message);
            }
        }

    }


    private async Task<ResponseModel<UpdatedSliderCommandResponse>> AddSlider(UpdatedSliderCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ResponseModel<UpdatedSliderCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }
        if (!await _imageFileCheckHelper.CheckImageFormat(request.Photo))
        {
            return ResponseModel<UpdatedSliderCommandResponse>.Fail("Invalid Image Format");
        }
        await _sliderRepository.BeginTransactionAsync();
        try
        {
            var photoData = await _storageService.UploadAsync("files", request.Photo);
            var sliderPhotoModel = new SliderPhoto()
            {
                FileName = photoData.fileName,
                Path = photoData.pathOrContainerName,
                Storage = _storageService.StorageName,
            };
            var sliderModel = new Domain.Entities.Slider.Slider()
            {
                Title = request.Heading,
                Content = request.Content,
                Button1Text = request.Button1Text,
                Button1Link = request.Button1Link,
                Button2Text = request.Button2Text,
                Button2Link = request.Button2Link,
                Photo = sliderPhotoModel
            };
            await _sliderRepository.AddAsync(sliderModel);
            await _sliderRepository.CommitTransactionAsync();
            await _sliderRepository.SaveAsync();

            return ResponseModel<UpdatedSliderCommandResponse>.Success();
        }
        catch (Exception e)
        {
            await _sliderRepository.RollbackTransactionAsync();
            return ResponseModel<UpdatedSliderCommandResponse>.Fail(e.Message);
        }
    }
}