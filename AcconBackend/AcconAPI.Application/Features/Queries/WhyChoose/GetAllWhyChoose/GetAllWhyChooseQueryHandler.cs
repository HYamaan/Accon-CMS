using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.WhyChoose.GetAllWhyChoose;

public class GetAllWhyChooseQueryHandler: IRequestHandler<GetAllWhyChooseQueryRequest, ResponseModel<GetAllWhyChooseQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.WhyChooseUs.WhyChoose> _whyChooseRepository;

    public GetAllWhyChooseQueryHandler(IGenericRepository<Domain.Entities.WhyChooseUs.WhyChoose> whyChooseRepository)
    {
        _whyChooseRepository = whyChooseRepository;
    }

    public async Task<ResponseModel<GetAllWhyChooseQueryResponse>> Handle(GetAllWhyChooseQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var getAllWhyChoose = await _whyChooseRepository.GetAll()
                .Include(x => x.IconPhoto)
                .Select(ux=> new GetAllWhyChooseUsResponseDTOs()
                {
                    Id = ux.Id,
                    Title = ux.Title,
                    Content = ux.Content,
                    Photo = ux.IconPhoto.Path
                })
                .ToListAsync(cancellationToken);
            var response = new GetAllWhyChooseQueryResponse()
            {
                WhyChoose = getAllWhyChoose
            };
            return ResponseModel<GetAllWhyChooseQueryResponse>.Success(response);

        }
        catch (Exception e)
        {
            return ResponseModel<GetAllWhyChooseQueryResponse>.Fail(e.Message);
        }
    }
}