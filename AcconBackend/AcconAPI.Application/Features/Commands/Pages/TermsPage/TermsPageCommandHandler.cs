using AcconAPI.Application.Features.Commands.Pages.TestimonialPage;
using AcconAPI.Application.Models;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Pages.TermsPage;

public class TermsPageCommandHandler : IRequestHandler<TermsPageCommandRequest, ResponseModel<TermsPageCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.TermsPage> _termsRepository;
    private readonly IValidator<PageEntityWithContentMap> _validator;
    private readonly IMapper _mapper;

    public TermsPageCommandHandler(IGenericRepository<Domain.Entities.Page.TermsPage> termsRepository,
        IValidator<PageEntityWithContentMap> validator, IMapper mapper)
    {
        _termsRepository = termsRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<ResponseModel<TermsPageCommandResponse>> Handle(TermsPageCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {

            var pageEntity = _mapper.Map<PageEntityWithContentMap>(request);
            var validationResult = await _validator.ValidateAsync(pageEntity, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<TermsPageCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage)
                    .ToList());
            }

            var getTermsPage = await _termsRepository.GetAll().FirstOrDefaultAsync();

            if (getTermsPage != null)
            {
                getTermsPage.Terms = request.Content;
                getTermsPage.Heading = request.Heading;
                getTermsPage.MetaTitle = request.MetaTitle;
                getTermsPage.MetaDescription = request.MetaDescription;
                getTermsPage.MetaKeywords = request.MetaKeywords;

                _termsRepository.Update(getTermsPage);
            }
            else
            {
                var termsPage = new Domain.Entities.Page.TermsPage()
                {
                    Terms = request.Content,
                    Heading = request.Heading,
                    MetaTitle = request.MetaTitle,
                    MetaDescription = request.MetaDescription,
                    MetaKeywords = request.MetaKeywords
                };

                await _termsRepository.AddAsync(termsPage);
            }


            await _termsRepository.SaveAsync();


            return ResponseModel<TermsPageCommandResponse>.Success("Terms Page Created/Updated Successfully");
        }
        catch (Exception e)
        {
            return ResponseModel<TermsPageCommandResponse>.Fail(e.Message);
        }
    }
}