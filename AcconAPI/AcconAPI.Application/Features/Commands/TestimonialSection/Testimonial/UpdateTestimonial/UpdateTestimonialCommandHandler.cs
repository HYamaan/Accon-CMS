using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.FluentValidation;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.Testimonial;
using AcconAPI.Domain.Entities.Page;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.TestimonialSection.Testimonial.UpdateTestimonial;

public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommandRequest, ResponseModel<UpdateTestimonialCommandResponse>>
{
    private readonly IGenericRepository<TestimonialPhoto> _testimonialPhotoRepository;
    private readonly IGenericRepository<Domain.Entities.Testimonial.Testimonial> _testimonialRepository;
    private readonly IGenericRepository<TestimonialPage> _testimonialPageRepository;

    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    private readonly ICreateTestimonialCommandRequestValidator _createtValidator;
    private readonly IUpdateTestimonialCommandRequestValidator _updateValidator;


    public UpdateTestimonialCommandHandler(IGenericRepository<TestimonialPhoto> testimonialPhotoRepository, IGenericRepository<Domain.Entities.Testimonial.Testimonial> testimonialRepository, IStorageService service, IFileCheckHelper fileCheckHelper, IGenericRepository<TestimonialPage> testimonialPageRepository, ICreateTestimonialCommandRequestValidator createtValidator, IUpdateTestimonialCommandRequestValidator updateValidator)
    {
        _testimonialPhotoRepository = testimonialPhotoRepository;
        _testimonialRepository = testimonialRepository;
        _storageService = service;
        _fileCheckHelper = fileCheckHelper;
        _testimonialPageRepository = testimonialPageRepository;
        _createtValidator = createtValidator;
        _updateValidator = updateValidator;
    }

    public async Task<ResponseModel<UpdateTestimonialCommandResponse>> Handle(UpdateTestimonialCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == null)
        {
            return await CreateTestimonial(request, cancellationToken);
        }

        return await UpdateTestimonial(request, cancellationToken);

    }

    private async Task<ResponseModel<UpdateTestimonialCommandResponse>> CreateTestimonial(UpdateTestimonialCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _createtValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ResponseModel<UpdateTestimonialCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }

        if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
        {
            return ResponseModel<UpdateTestimonialCommandResponse>.Fail("Invalid file format");
        }

        try
        {

            var testimonialPage = await _testimonialPageRepository.GetAll().FirstOrDefaultAsync();

            await _testimonialPhotoRepository.BeginTransactionAsync();
            var uploadImage = await _storageService.UploadAsync("files", request.Photo);

            var testimonialPhoto = new TestimonialPhoto
            {
                Path = uploadImage.pathOrContainerName,
                FileName = uploadImage.fileName,
                Storage = _storageService.StorageName
            };

            var testimonial = new Domain.Entities.Testimonial.Testimonial
            {
                Name = request.Name,
                Designation = request.Designation,
                Company = request.Company,
                Comment = request.Comment,
                Photo = testimonialPhoto,
                TestimonialPage = testimonialPage
            };

            await _testimonialRepository.AddAsync(testimonial);
            await _testimonialPhotoRepository.CommitTransactionAsync();
            await _testimonialRepository.SaveAsync();
            await _testimonialPhotoRepository.SaveAsync();
            return ResponseModel<UpdateTestimonialCommandResponse>.Success();
        }
        catch (Exception a)
        {
            await _testimonialPhotoRepository.RollbackTransactionAsync();
            return ResponseModel<UpdateTestimonialCommandResponse>.Fail(a.Message);
        }

    }
    private async Task<ResponseModel<UpdateTestimonialCommandResponse>> UpdateTestimonial(UpdateTestimonialCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ResponseModel<UpdateTestimonialCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }



        var testimonial = await _testimonialRepository.GetWhere(ux => ux.Id == request.Id)
            .Include(x => x.Photo)
            .FirstOrDefaultAsync();
        if (testimonial == null)
        {
            return ResponseModel<UpdateTestimonialCommandResponse>.Fail("Testimonial not found");
        }

        if (testimonial.Name != request.Name)
        {
            testimonial.Name = request.Name;
        }

        if (testimonial.Designation != request.Designation)
        {
            testimonial.Designation = request.Designation;
        }

        if (testimonial.Company != request.Company)
        {
            testimonial.Company = request.Company;
        }

        if (testimonial.Comment != request.Comment)
        {
            testimonial.Comment = request.Comment;
        }

        if (request.Photo != null)
        {
            if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
            {
                return ResponseModel<UpdateTestimonialCommandResponse>.Fail("Invalid file format");
            }

            var testimonialPhotoStorage = await _storageService.UploadAsync("files", request.Photo);

            var testimonialPhoto = new TestimonialPhoto()
            {
                Path = testimonialPhotoStorage.pathOrContainerName,
                FileName = testimonialPhotoStorage.fileName,
                Storage = _storageService.StorageName
            };
            _testimonialPhotoRepository.Update(testimonialPhoto);
            testimonial.Photo = testimonialPhoto;
        }

        _testimonialRepository.Update(testimonial);
        await _testimonialRepository.SaveAsync();
        await _testimonialPhotoRepository.SaveAsync();
        return ResponseModel<UpdateTestimonialCommandResponse>.Success();


    }
}