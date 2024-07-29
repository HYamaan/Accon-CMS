using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.WhyChooseUs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.WhyChoose.GetWhyChooseMainPhoto;

public class GetWhyChooseMainPhotoQueryHandler:IRequestHandler<GetWhyChooseMainPhotoQueryRequest, ResponseModel<GetWhyChooseMainPhotoQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.WhyChooseUs.ChooseUsMainPhoto> _whyChooseMainPhotoRepository;

    public GetWhyChooseMainPhotoQueryHandler(IGenericRepository<ChooseUsMainPhoto> whyChooseMainPhotoRepository)
    {
        _whyChooseMainPhotoRepository = whyChooseMainPhotoRepository;
    }

    public async Task<ResponseModel<GetWhyChooseMainPhotoQueryResponse>> Handle(GetWhyChooseMainPhotoQueryRequest request, CancellationToken cancellationToken)
    {
        var getWhyChooseMainPhoto = await _whyChooseMainPhotoRepository.GetAll().FirstOrDefaultAsync();

        var response = new GetWhyChooseMainPhotoQueryResponse()
        {
            Photo = getWhyChooseMainPhoto?.Path
        };

     
        return ResponseModel<GetWhyChooseMainPhotoQueryResponse>.Success(response);
    }
}