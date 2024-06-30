using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Faq.GetFaqEdit;

public class GetFaqEditQueryHandler:IRequestHandler<GetFaqEditQueryRequest,ResponseModel<GetFaqEditQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Faq.Faq> _faqRepository;

    public GetFaqEditQueryHandler(IGenericRepository<Domain.Entities.Faq.Faq> faqRepository)
    {
        _faqRepository = faqRepository;
    }

    public async Task<ResponseModel<GetFaqEditQueryResponse>> Handle(GetFaqEditQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == null)
        {
            return ResponseModel<GetFaqEditQueryResponse>.Fail("Id is required");
        }

        try
        {
            var faq = await _faqRepository.GetByIdAsync(request.Id.ToString());
            if (faq == null)
            {
                return ResponseModel<GetFaqEditQueryResponse>.Fail("Faq not found");
            }

            var response = new GetFaqEditQueryResponse
            {
                Title = faq.Title,
                Content = faq.Content,
                VisiblePage = faq.VisiblePage
            };
            return ResponseModel<GetFaqEditQueryResponse>.Success(response);
        }
        catch (Exception e)
        {
           return ResponseModel<GetFaqEditQueryResponse>.Fail(e.Message);
        }
    }
}