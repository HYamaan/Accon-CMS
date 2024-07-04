using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Pages.ServicePage;

public class ServicePageCommandHandler:IRequestHandler<ServicePageCommandRequest, ResponseModel<ServicePageCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.ServicePage> _servicePageRepository;
    private readonly IValidator<PageEntity> _validator;
    private readonly IMapper _mapper;

    public ServicePageCommandHandler(IMapper mapper, IValidator<PageEntity> validator, IGenericRepository<Domain.Entities.Page.ServicePage> servicePageRepository)
    {
        _mapper = mapper;
        _validator = validator;
        _servicePageRepository = servicePageRepository;
    }

    public async Task<ResponseModel<ServicePageCommandResponse>> Handle(ServicePageCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {

            var pageEntity = _mapper.Map<PageEntity>(request);
            var validationResult = await _validator.ValidateAsync(pageEntity, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<ServicePageCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage)
                    .ToList());
            }

            var getServicePage = await _servicePageRepository.GetAll().FirstOrDefaultAsync();

            if (getServicePage != null)
            {
                getServicePage.Heading = request.Heading;
                getServicePage.MetaTitle = request.MetaTitle;
                getServicePage.MetaDescription = request.MetaDescription;
                getServicePage.MetaKeywords = request.MetaKeywords;

                _servicePageRepository.Update(getServicePage);
            }
            else
            {
                var servicePage = new Domain.Entities.Page.ServicePage()
                {
                    Heading = request.Heading,
                    MetaTitle = request.MetaTitle,
                    MetaDescription = request.MetaDescription,
                    MetaKeywords = request.MetaKeywords
                };

                await _servicePageRepository.AddAsync(servicePage);
            }


            await _servicePageRepository.SaveAsync();


            return ResponseModel<ServicePageCommandResponse>.Success("Service Page Created/Updated Successfully");
        }
        catch (Exception e)
        {
            return ResponseModel<ServicePageCommandResponse>.Fail(e.Message);
        }
    }
}