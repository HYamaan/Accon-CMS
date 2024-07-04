using AcconAPI.Application.Features.Commands.Pages.TermsPage;
using AcconAPI.Application.Models;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Pages.PrivacyPage;

public class PrivacyPageCommandHandler:IRequestHandler<PrivacyPageCommandRequest, ResponseModel<PrivacyPageCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.PrivacyPage> _privacyRepository;
    private readonly IValidator<PageEntityWithContentMap> _validator;
    private readonly IMapper _mapper;

    public PrivacyPageCommandHandler(IGenericRepository<Domain.Entities.Page.PrivacyPage> privacyRepository, IValidator<PageEntityWithContentMap> validator, IMapper mapper)
    {
        _privacyRepository = privacyRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<ResponseModel<PrivacyPageCommandResponse>> Handle(PrivacyPageCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {

            var pageEntity = _mapper.Map<PageEntityWithContentMap>(request);
            var validationResult = await _validator.ValidateAsync(pageEntity, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<PrivacyPageCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage)
                    .ToList());
            }

            var getTermsPage = await _privacyRepository.GetAll().FirstOrDefaultAsync();

            if (getTermsPage != null)
            {
                getTermsPage.Content = request.Content;
                getTermsPage.Heading = request.Heading;
                getTermsPage.MetaTitle = request.MetaTitle;
                getTermsPage.MetaDescription = request.MetaDescription;
                getTermsPage.MetaKeywords = request.MetaKeywords;

                _privacyRepository.Update(getTermsPage);
            }
            else
            {
                var privacyPage = new Domain.Entities.Page.PrivacyPage()
                {
                    Content = request.Content,
                    Heading = request.Heading,
                    MetaTitle = request.MetaTitle,
                    MetaDescription = request.MetaDescription,
                    MetaKeywords = request.MetaKeywords
                };

                await _privacyRepository.AddAsync(privacyPage);
            }


            await _privacyRepository.SaveAsync();


            return ResponseModel<PrivacyPageCommandResponse>.Success("Privacy Page Created/Updated Successfully");
        }
        catch (Exception e)
        {
            return ResponseModel<PrivacyPageCommandResponse>.Fail(e.Message);
        }
    }
}