using AcconAPI.Application.Models.DTOs.Response.ClientPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.ServiceClientContentPage;

public class ServiceClientContentPageQueryHandler:IRequestHandler<ServiceClientContentPageQueryRequest, ResponseModel<ServiceClientContentPageQueryResponse>>
{
    private readonly IGenericRepository<ServiceSection> _serviceSectionRepository;

    public ServiceClientContentPageQueryHandler(IGenericRepository<ServiceSection> serviceSectionRepository)
    {
        _serviceSectionRepository = serviceSectionRepository;
    }

    public async Task<ResponseModel<ServiceClientContentPageQueryResponse>> Handle(ServiceClientContentPageQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var serviceSections = await _serviceSectionRepository
                .GetWhere(x => (x.Id == request.Id) && x.IsPublished)
                .Include(x => x.Photo)
                .Include(x => x.Banner)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (serviceSections == null)
                return ResponseModel<ServiceClientContentPageQueryResponse>.Fail("Service not found");

            var topServices = await _serviceSectionRepository.GetWhere(x => x.IsPublished)
                .OrderByDescending(x => x.CreatedDate)
                .Take(5)
                .Select(x => new GetClientLastServicesResponseDTOs()
                {
                    url = x.Id,
                    Title = x.Title,
                })
                .ToListAsync(cancellationToken);

            var response = new ServiceClientContentPageQueryResponse()
            {
                Header = serviceSections.Title,
                MetaTitle = serviceSections.MetaTitle,
                MetaDescription = serviceSections.MetaDescription,
                MetaKeywords = serviceSections.MetaKeywords,
                Photo = serviceSections.Photo?.Path,
                Content = serviceSections.Content,
                LastServices = topServices
            };
            return ResponseModel<ServiceClientContentPageQueryResponse>.Success(response);
        }
        catch (Exception e)
        {
            return ResponseModel<ServiceClientContentPageQueryResponse>.Fail(e.Message);
        }
    }
}