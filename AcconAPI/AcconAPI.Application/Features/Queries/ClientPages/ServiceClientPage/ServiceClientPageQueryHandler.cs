using AcconAPI.Application.Models.DTOs.Response.ClientPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.ServicePage;

public class ServiceClientPageQueryHandler:IRequestHandler<ServiceClientPageQueryRequest, ResponseModel<ServiceClientPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.ServicePage> _servicePageRepository;

    public ServiceClientPageQueryHandler(IGenericRepository<Domain.Entities.Page.ServicePage> servicePageRepository)
    {
        _servicePageRepository = servicePageRepository;
    }

    public async Task<ResponseModel<ServiceClientPageQueryResponse>> Handle(ServiceClientPageQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var servicePage = await _servicePageRepository.GetWhere(x=>x.IsPublished)
                .Include(x => x.ServiceSections)
                .ThenInclude(x => x.Photo)
                .Include(x => x.ServiceSections)
                .ThenInclude(x => x.Banner)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var services = servicePage.ServiceSections
                .Where(x => x.IsPublished)
                .Select(x => new GetClientServiceResponseDTOs()
            {
                url = x.Id,
                Title = x.Title,
                Description = x.ShortContent,
                Photo = x.Photo?.Path,
            }).ToList();

            var response = new ServiceClientPageQueryResponse()
            {
                Header = servicePage.Heading,
                MetaTitle = servicePage.MetaTitle,
                MetaDescription = servicePage.MetaDescription,
                MetaKeywords = servicePage.MetaKeywords,
                Services = services
            };

            return ResponseModel<ServiceClientPageQueryResponse>.Success(response);
        }
        catch (Exception e)
        {
            return ResponseModel<ServiceClientPageQueryResponse>.Fail(e.Message);
        }
    }
}