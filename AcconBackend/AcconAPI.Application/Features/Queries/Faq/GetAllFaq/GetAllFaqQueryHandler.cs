using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Faq.GetAllFaq;

public class GetAllFaqQueryHandler:IRequestHandler<GetAllFaqQueryRequest, ResponseModel<GetAllFaqQueryResponse>>
{
    private readonly IGenericRepository<FaqPage> _faqPageRepository;

    public GetAllFaqQueryHandler(IGenericRepository<FaqPage> faqPageRepository)
    {
        _faqPageRepository = faqPageRepository;
    }

    public async Task<ResponseModel<GetAllFaqQueryResponse>> Handle(GetAllFaqQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var faqPage = await _faqPageRepository.GetAll().Select(ux => new GetAllFaqQueryResponse()
                {
                    MetaTitle = ux.MetaTitle,
                    MetaDescription = ux.MetaDescription,
                    MetaKeywords = ux.MetaKeywords,
                    Faqs = ux.Faqs.Select(ux => new GetAllFaqResponseDTOs()
                    {
                        Id = ux.Id,
                        Title = ux.Title,
                        VisiblePage = ux.VisiblePage,
                    }).ToList()
                }
            ).FirstOrDefaultAsync();


            if (faqPage == null)
            {
                return ResponseModel<GetAllFaqQueryResponse>.Fail("Faq page not found");
            }

            return ResponseModel<GetAllFaqQueryResponse>.Success(faqPage);
        }
        catch (Exception e)
        {
           return ResponseModel<GetAllFaqQueryResponse>.Fail(e.Message);
        }
    }
}