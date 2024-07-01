using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Partner.UpdatePartner;

public class UpdatePartnerCommandHandler : IRequestHandler<UpdatePartnerCommandRequest, ResponseModel<UpdatePartnerCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Partner.Partner> _partnerRepository;
    private readonly IGenericRepository<Domain.Entities.File.PartnerPhoto> _partnerPhotoRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    public UpdatePartnerCommandHandler(IGenericRepository<Domain.Entities.Partner.Partner> partnerRepository, IFileCheckHelper fileCheckHelper, IStorageService storageService, IGenericRepository<PartnerPhoto> partnerPhotoRepository)
    {
        _partnerRepository = partnerRepository;
        _fileCheckHelper = fileCheckHelper;
        _storageService = storageService;
        _partnerPhotoRepository = partnerPhotoRepository;
    }

    public async Task<ResponseModel<UpdatePartnerCommandResponse>> Handle(UpdatePartnerCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == null)
            return await CreatePartner(request, cancellationToken);
        return await UpdatePartner(request, cancellationToken);
    }
    private async Task<ResponseModel<UpdatePartnerCommandResponse>> CreatePartner(UpdatePartnerCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Photo == null && request.Name == null)
            return ResponseModel<UpdatePartnerCommandResponse>.Fail("Name and Photo can not be null");

        if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
            return ResponseModel<UpdatePartnerCommandResponse>.Fail("Photo format is not valid");

        var storedPhoto = await _storageService.UploadAsync("files", request.Photo);
        var partnerPhoto = new PartnerPhoto()
        {
            FileName = storedPhoto.fileName,
            Path = storedPhoto.pathOrContainerName,
            Storage = _storageService.StorageName
        };
        await _partnerPhotoRepository.AddAsync(partnerPhoto);


        var partner = new Domain.Entities.Partner.Partner()
        {
            Name = request.Name,
            Photo = partnerPhoto
        };
        await _partnerRepository.AddAsync(partner);
        await _partnerRepository.SaveAsync();
        await _partnerPhotoRepository.SaveAsync();
        return ResponseModel<UpdatePartnerCommandResponse>.Success();
    }
    private async Task<ResponseModel<UpdatePartnerCommandResponse>> UpdatePartner(UpdatePartnerCommandRequest request, CancellationToken cancellationToken)
    {
        if(request.Name == null)
            return ResponseModel<UpdatePartnerCommandResponse>.Fail("Name can not be null");
        
        var findPartner = await _partnerRepository.GetWhere(x=>x.Id == request.Id)
            .Include(x=>x.Photo)
            .FirstOrDefaultAsync();
        if (findPartner == null)
            return ResponseModel<UpdatePartnerCommandResponse>.Fail("Partner not found");

        if (request.Photo != null)
        {
            if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
                return ResponseModel<UpdatePartnerCommandResponse>.Fail("Photo format is not valid");

            var storedPhoto = await _storageService.UploadAsync("files", request.Photo);
            var partnerPhoto = new PartnerPhoto()
            {
                FileName = storedPhoto.fileName,
                Path = storedPhoto.pathOrContainerName,
                Storage = _storageService.StorageName
            };
            await _partnerPhotoRepository.AddAsync(partnerPhoto);
            findPartner.Photo = partnerPhoto;
        }
        
        if(findPartner.Name != request.Name)
            findPartner.Name = request.Name;

        _partnerRepository.Update(findPartner);
        await _partnerRepository.SaveAsync();
        await _partnerPhotoRepository.SaveAsync();
        return ResponseModel<UpdatePartnerCommandResponse>.Success();

    }
}