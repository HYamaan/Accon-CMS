using AcconAPI.Application.Features.Commands.Pages.GalleryPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Pages.FaqPage;

public class FaqPageCommandHandler:IRequestHandler<FaqPageCommandRequest, ResponseModel<FaqPageCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.FaqPage> _faqPageRepository;
    private readonly IValidator<PageEntity> _validator;
    private readonly IMapper _mapper;

    public FaqPageCommandHandler(IGenericRepository<Domain.Entities.Page.FaqPage> faqPageRepository, IMapper mapper, IValidator<PageEntity> validator)
    {
        _faqPageRepository = faqPageRepository;
        _mapper = mapper;
        _validator = validator;
    }

 
    public async Task<ResponseModel<FaqPageCommandResponse>> Handle(FaqPageCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {

            var pageEntity = _mapper.Map<PageEntity>(request);
            var validationResult = await _validator.ValidateAsync(pageEntity, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<FaqPageCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage)
                    .ToList());
            }

            var getFaqPage = await _faqPageRepository.GetAll().FirstOrDefaultAsync();

            if (getFaqPage != null)
            {
                getFaqPage.Heading = request.Heading;
                getFaqPage.MetaTitle = request.MetaTitle;
                getFaqPage.MetaDescription = request.MetaDescription;
                getFaqPage.MetaKeywords = request.MetaKeywords;

                _faqPageRepository.Update(getFaqPage);
            }
            else
            {
                var faqPage = new Domain.Entities.Page.FaqPage()
                {
                    Heading = request.Heading,
                    MetaTitle = request.MetaTitle,
                    MetaDescription = request.MetaDescription,
                    MetaKeywords = request.MetaKeywords
                };

                await _faqPageRepository.AddAsync(faqPage);
            }


            await _faqPageRepository.SaveAsync();


            return ResponseModel<FaqPageCommandResponse>.Success("Faq Page Created/Updated Successfully");
        }
        catch (Exception e)
        {
            return ResponseModel<FaqPageCommandResponse>.Fail(e.Message);
        }
    }
}