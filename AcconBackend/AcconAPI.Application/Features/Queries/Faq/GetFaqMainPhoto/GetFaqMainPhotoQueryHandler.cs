using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Faq.GetFaqMainPhoto;

public class GetFaqMainPhotoQueryHandler:IRequestHandler<GetFaqMainPhotoQueryRequest, ResponseModel<GetFaqMainPhotoQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.FaqMainPhoto> _faqMainPhotoRepository;

    public GetFaqMainPhotoQueryHandler(IGenericRepository<FaqMainPhoto> faqMainPhotoRepository)
    {
        _faqMainPhotoRepository = faqMainPhotoRepository;
    }

    public async Task<ResponseModel<GetFaqMainPhotoQueryResponse>> Handle(GetFaqMainPhotoQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var faqMainPhoto = await _faqMainPhotoRepository.GetAll().FirstOrDefaultAsync();
            if (faqMainPhoto == null)
            {
                return ResponseModel<GetFaqMainPhotoQueryResponse>.Fail("Faq Main Photo not found");
            }

            var result = new GetFaqMainPhotoQueryResponse()
            {
                Photo = faqMainPhoto.Path,
            };
            return ResponseModel<GetFaqMainPhotoQueryResponse>.Success(result);
        }
        catch (Exception e)
        {
            return ResponseModel<GetFaqMainPhotoQueryResponse>.Fail(e.Message);
        }

    }
}