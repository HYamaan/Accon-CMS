using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Service.GetAllService;

public class GetAllServiceQueryHandler:IRequestHandler<GetAllServiceQueryRequest, ResponseModel<GetAllServiceQueryResponse>>
{
    private readonly IGenericRepository<ServicePage> _serviceRepository;

    public GetAllServiceQueryHandler(IGenericRepository<ServicePage> serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<ResponseModel<GetAllServiceQueryResponse>> Handle(GetAllServiceQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _serviceRepository.GetAll()
            .Include(x => x.ServiceSections)
            .ThenInclude(x => x.Photo)
            .Include(x => x.ServiceSections)
            .ThenInclude(x => x.Banner)
            .Select(ux => new GetAllServiceQueryResponse()
            {
                MetaTitle = ux.MetaTitle,
                MetaDescription = ux.MetaDescription,
                MetaKeywords = ux.MetaKeywords,
                Services = ux.ServiceSections.Select(x => new ServiceDTOs()
                {
                    Id = x.Id,
                    IsPublished = x.IsPublished,
                    Photo = x.Photo.Path,
                    Banner = x.Banner.Path,
                    Heading = x.Title
                }).ToList()
            })
            .FirstOrDefaultAsync();

        return result != null
            ? ResponseModel<GetAllServiceQueryResponse>.Success(result)
            : ResponseModel<GetAllServiceQueryResponse>.Fail("No services found.");
    }
}