using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Pages.ServicePage;

public class ServicePageQueryHandler:IRequestHandler<ServicePageQueryRequest,ResponseModel<ServicePageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.ServicePage> _servicePageRepository;

    public ServicePageQueryHandler(IGenericRepository<Domain.Entities.Page.ServicePage> servicePageRepository)
    {
        _servicePageRepository = servicePageRepository;
    }

    public async Task<ResponseModel<ServicePageQueryResponse>> Handle(ServicePageQueryRequest request, CancellationToken cancellationToken)
    {
        var servicePage = await _servicePageRepository.GetAll().FirstOrDefaultAsync();

        if (servicePage == null)
        {
            return  ResponseModel<ServicePageQueryResponse>.Fail("Service Page not found");
        }
        var servicePageResponse = new ServicePageQueryResponse
        {
            Title = servicePage.Heading,
           MetaTitle = servicePage.MetaTitle,
           MetaDescription = servicePage.MetaDescription,
           MetaKeywords = servicePage.MetaKeywords,
        };
        return ResponseModel<ServicePageQueryResponse>.Success(servicePageResponse);
    }

}