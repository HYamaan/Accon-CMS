using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Service.GetEditService;

public class GetEditServiceQueryHandler:IRequestHandler<GetEditServiceQueryRequest,ResponseModel<GetEditServiceQueryResponse>>
{
    private readonly IGenericRepository<ServiceSection> _serviceRepository;

    public GetEditServiceQueryHandler(IGenericRepository<ServiceSection> serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<ResponseModel<GetEditServiceQueryResponse>> Handle(GetEditServiceQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return ResponseModel<GetEditServiceQueryResponse>.Fail("Id cannot be empty.");
        }
        try
        {
            var result = await _serviceRepository.GetWhere(ux => ux.Id == request.Id)
                .Include(x => x.Photo)
                .Include(x => x.Banner)
                .FirstOrDefaultAsync();
            if (result == null)
            {
                return ResponseModel<GetEditServiceQueryResponse>.Fail("Service not found.");
            }

            var response = new GetEditServiceQueryResponse()
            {
                Id = result.Id,
                isPublished = result.IsPublished,
                Heading = result.Title,
                ShortContent = result.ShortContent,
                Content = result.Content,
                Photo = result.Photo.Path,
                Banner = result.Banner.Path,
                MetaTitle = result.MetaTitle,
                MetaDescription = result.MetaDescription,
                MetaKeywords = result.MetaKeywords
            };
            return ResponseModel<GetEditServiceQueryResponse>.Success(response);
        }
        catch (Exception e)
        {
            return ResponseModel<GetEditServiceQueryResponse>.Fail(e.Message);
        }
    }
}