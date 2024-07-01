using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.WhyChoose.GetEditWhyChoose;

public class GetEditWhyChooseQueryHandler:IRequestHandler<GetEditWhyChooseQueryRequest,ResponseModel<GetEditWhyChooseQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.WhyChooseUs.WhyChoose> _whyChooseRepository;

    public GetEditWhyChooseQueryHandler(IGenericRepository<Domain.Entities.WhyChooseUs.WhyChoose> whyChooseRepository)
    {
        _whyChooseRepository = whyChooseRepository;
    }

    public async Task<ResponseModel<GetEditWhyChooseQueryResponse>> Handle(GetEditWhyChooseQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Id == Guid.Empty)
            {
                return ResponseModel<GetEditWhyChooseQueryResponse>.Fail("Id is required");
            }

            var whyChoose = await _whyChooseRepository.GetWhere(x => x.Id == request.Id)
                .Include(x => x.IconPhoto)
                .FirstOrDefaultAsync(cancellationToken);

            if (whyChoose == null)
            {
                return ResponseModel<GetEditWhyChooseQueryResponse>.Fail("Why Choose is not found");
            }

            var response = new GetEditWhyChooseQueryResponse
            {
                Id = whyChoose.Id,
                Title = whyChoose.Title,
                Content = whyChoose.Content,
                Image = whyChoose.IconPhoto.Path
            };
            return ResponseModel<GetEditWhyChooseQueryResponse>.Success(response);
        }
        catch (Exception e)
        {
            return ResponseModel<GetEditWhyChooseQueryResponse>.Fail(e.Message);
        }
    }
}