using System.Formats.Asn1;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.FluentValidation;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.WhyChooseUs;
using AcconAPI.Domain.Entities.WhyChooseUs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.WhyChooseUs.UpdateWhyChooseUs;

public class UpdateWhyChooseUsCommandHandler : IRequestHandler<UpdateWhyChooseUsCommandRequest, ResponseModel<UpdateWhyChooseUsCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.WhyChooseUs.WhyChoose> _whyChooseUsRepository;
    private readonly IGenericRepository<Domain.Entities.File.WhyChooseUs.ChooseUsIconPhoto> _chooseUsIconPhotoRepository;
    private readonly IFileCheckHelper _imageFileCheckHelper;
    private readonly IStorageService _storageService;

    private readonly ICreateWhyChooseUsCommandRequestValidator _createWhyChooseUsCommandRequestValidator;
    private readonly IUpdateWhyChooseUsCommandRequestValidator _updateWhyChooseUsCommandRequestValidator;

    public UpdateWhyChooseUsCommandHandler(IGenericRepository<WhyChoose> whyChooseUsRepository, IGenericRepository<ChooseUsIconPhoto> chooseUsIconPhotoRepository, IFileCheckHelper imageFileCheckHelper, IStorageService storageService, ICreateWhyChooseUsCommandRequestValidator createWhyChooseUsCommandRequestValidator, IUpdateWhyChooseUsCommandRequestValidator updateWhyChooseUsCommandRequestValidator)
    {
        _whyChooseUsRepository = whyChooseUsRepository;
        _chooseUsIconPhotoRepository = chooseUsIconPhotoRepository;
        _imageFileCheckHelper = imageFileCheckHelper;
        _storageService = storageService;
        _createWhyChooseUsCommandRequestValidator = createWhyChooseUsCommandRequestValidator;
        _updateWhyChooseUsCommandRequestValidator = updateWhyChooseUsCommandRequestValidator;
    }

    public async Task<ResponseModel<UpdateWhyChooseUsCommandResponse>> Handle(UpdateWhyChooseUsCommandRequest request, CancellationToken cancellationToken)
    {
        if(request.Id == null)
            return await CreateChooseUs(request, cancellationToken);
        return await UpdateChooseUs(request, cancellationToken);
    }
    private async Task<ResponseModel<UpdateWhyChooseUsCommandResponse>> CreateChooseUs(UpdateWhyChooseUsCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validationResult = await _createWhyChooseUsCommandRequestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return ResponseModel<UpdateWhyChooseUsCommandResponse>.Fail(validationResult.Errors.First().ErrorMessage);

            if (!await _imageFileCheckHelper.CheckImageFormat(request.Photo))
                return ResponseModel<UpdateWhyChooseUsCommandResponse>.Fail("Icon photo is not valid");

            await _chooseUsIconPhotoRepository.BeginTransactionAsync();
            var iconPhoto = await _storageService.UploadAsync("files", request.Photo);
            var iconPhotoModel = new ChooseUsIconPhoto()
            {
                Path = iconPhoto.pathOrContainerName,
                FileName = iconPhoto.fileName,
                Storage = _storageService.StorageName

            };
            await _chooseUsIconPhotoRepository.AddAsync(iconPhotoModel);
            await _chooseUsIconPhotoRepository.CommitTransactionAsync();

            await _whyChooseUsRepository.BeginTransactionAsync();
            var createChoose = new WhyChoose()
            {
                Title = request.Title,
                Content = request.Content,
                IconPhoto = iconPhotoModel

            };
            await _whyChooseUsRepository.AddAsync(createChoose);
            await _chooseUsIconPhotoRepository.SaveAsync();
            await _whyChooseUsRepository.CommitTransactionAsync();
            return ResponseModel<UpdateWhyChooseUsCommandResponse>.Success();

        }
        catch (Exception e)
        {
            await _chooseUsIconPhotoRepository.RollbackTransactionAsync();
            return ResponseModel<UpdateWhyChooseUsCommandResponse>.Fail(e.Message);
        }

    }
    private async Task<ResponseModel<UpdateWhyChooseUsCommandResponse>> UpdateChooseUs(UpdateWhyChooseUsCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _updateWhyChooseUsCommandRequestValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return ResponseModel<UpdateWhyChooseUsCommandResponse>.Fail(validationResult.Errors.First().ErrorMessage);
        try
        {
            var chooseUs = await _whyChooseUsRepository.GetWhere(x => x.Id == request.Id)
                .Include(x => x.IconPhoto)
                .FirstOrDefaultAsync();

            if (chooseUs == null)
                return ResponseModel<UpdateWhyChooseUsCommandResponse>.Fail("Choose us not found");
            if (chooseUs.Title != request.Title)
                chooseUs.Title = request.Title;
            if (chooseUs.Content != request.Content)
                chooseUs.Content = request.Content;
            if (request.Photo != null)
            {
                if (!await _imageFileCheckHelper.CheckImageFormat(request.Photo))
                    return ResponseModel<UpdateWhyChooseUsCommandResponse>.Fail("Icon photo is not valid");

                if (chooseUs.IconPhoto.FileName != request.Photo.FileName)
                {
                    await _chooseUsIconPhotoRepository.BeginTransactionAsync();
                    var iconPhoto = await _storageService.UploadAsync("files", request.Photo);
                    var iconPhotoModel = new ChooseUsIconPhoto()
                    {
                        Path = iconPhoto.pathOrContainerName,
                        FileName = iconPhoto.fileName,
                        Storage = _storageService.StorageName

                    };
                    await _chooseUsIconPhotoRepository.AddAsync(iconPhotoModel);
                    await _chooseUsIconPhotoRepository.CommitTransactionAsync();
                    chooseUs.IconPhoto = iconPhotoModel;
                }
            }

            _whyChooseUsRepository.Update(chooseUs);
            await _whyChooseUsRepository.SaveAsync();
            return ResponseModel<UpdateWhyChooseUsCommandResponse>.Success();

        }
        catch (Exception e)
        {
           return ResponseModel<UpdateWhyChooseUsCommandResponse>.Fail(e.Message);
        }
    }
}