using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Pages.ContactPage;

public class ContactPageCommandHandler: IRequestHandler<ContactPageCommandRequest, ResponseModel<ContactPageCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.ContactPage> _contactRepository;
    private readonly IValidator<PageEntity> _validator;
    private readonly IMapper _mapper;

    public ContactPageCommandHandler(IGenericRepository<Domain.Entities.Page.ContactPage> contactRepository, IValidator<PageEntity> validator, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<ResponseModel<ContactPageCommandResponse>> Handle(ContactPageCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {

            var pageEntity = _mapper.Map<PageEntity>(request);
            var validationResult = await _validator.ValidateAsync(pageEntity, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<ContactPageCommandResponse>.Fail(validationResult.Errors
                    .Select(e => e.ErrorMessage)
                    .ToList());
            }

            var getContactPage = await _contactRepository.GetAll().FirstOrDefaultAsync();

            if (getContactPage != null)
            {
                getContactPage.Heading = request.Heading;
                getContactPage.MetaTitle = request.MetaTitle;
                getContactPage.MetaDescription = request.MetaDescription;
                getContactPage.MetaKeywords = request.MetaKeywords;

                _contactRepository.Update(getContactPage);
            }
            else
            {
                var contactPage = new Domain.Entities.Page.ContactPage()
                {
                    Heading = request.Heading,
                    MetaTitle = request.MetaTitle,
                    MetaDescription = request.MetaDescription,
                    MetaKeywords = request.MetaKeywords
                };

                await _contactRepository.AddAsync(contactPage);
            }


            await _contactRepository.SaveAsync();
            return ResponseModel<ContactPageCommandResponse>.Success("Contact Page Created/Updated Successfully");
        }
        catch (Exception e)
        {
            return ResponseModel<ContactPageCommandResponse>.Fail(e.Message);
        }
    }
}