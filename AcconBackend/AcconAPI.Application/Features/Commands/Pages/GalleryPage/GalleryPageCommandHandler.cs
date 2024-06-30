using AcconAPI.Application.Features.Commands.Pages.HomePage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Pages.GalleryPage;

public class GalleryPageCommandHandler:IRequestHandler<GalleryPageCommandRequest, ResponseModel<GalleryPageCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.GalleryPage> _galleryPageRepository;
    private readonly IValidator<PageEntity> _validator;
    private readonly IMapper _mapper;

    public GalleryPageCommandHandler(IGenericRepository<Domain.Entities.Page.GalleryPage> galleryPageRepository, IValidator<PageEntity> validator, IMapper mapper)
    {
        _galleryPageRepository = galleryPageRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<ResponseModel<GalleryPageCommandResponse>> Handle(GalleryPageCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {

            var pageEntity = _mapper.Map<PageEntity>(request);
            var validationResult = await _validator.ValidateAsync(pageEntity, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<GalleryPageCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage)
                    .ToList());
            }

            var getGalleryPage = await _galleryPageRepository.GetAll().FirstOrDefaultAsync();

            if (getGalleryPage != null)
            {
                getGalleryPage.Heading = request.Heading;
                getGalleryPage.MetaTitle = request.MetaTitle;
                getGalleryPage.MetaDescription = request.MetaDescription;
                getGalleryPage.MetaKeywords = request.MetaKeywords;

                _galleryPageRepository.Update(getGalleryPage);
            }
            else
            {
                var galleryPage = new Domain.Entities.Page.GalleryPage
                {
                    Heading = request.Heading,
                    MetaTitle = request.MetaTitle,
                    MetaDescription = request.MetaDescription,
                    MetaKeywords = request.MetaKeywords
                };

                await _galleryPageRepository.AddAsync(galleryPage);
            }


            await _galleryPageRepository.SaveAsync();


            return ResponseModel<GalleryPageCommandResponse>.Success("Gallery Page Created/Updated Successfully");
        }
        catch (Exception e)
        {
            return ResponseModel<GalleryPageCommandResponse>.Fail(e.Message);
        }
    }
}