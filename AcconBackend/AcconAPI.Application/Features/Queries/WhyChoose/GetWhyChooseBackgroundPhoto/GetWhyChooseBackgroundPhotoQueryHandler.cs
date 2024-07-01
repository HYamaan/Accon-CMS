using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.WhyChooseUs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.WhyChoose.GetWhyChooseBackgroundPhoto;

public class GetWhyChooseBackgroundPhotoQueryHandler:IRequestHandler<GetWhyChooseBackgroundPhotoQueryRequest, ResponseModel<GetWhyChooseBackgroundPhotoQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.WhyChooseUs.ChooseUseBackgroundPhoto> _whyChooseBackgroundPhotoRepository;

    public GetWhyChooseBackgroundPhotoQueryHandler(IGenericRepository<ChooseUseBackgroundPhoto> whyChooseBackgroundPhotoRepository)
    {
        _whyChooseBackgroundPhotoRepository = whyChooseBackgroundPhotoRepository;
    }

    public async Task<ResponseModel<GetWhyChooseBackgroundPhotoQueryResponse>> Handle(GetWhyChooseBackgroundPhotoQueryRequest request, CancellationToken cancellationToken)
    {
        var getWhyChooseBackgroundPhoto = await _whyChooseBackgroundPhotoRepository.GetAll().FirstOrDefaultAsync();
        if (getWhyChooseBackgroundPhoto == null)
        {
            return ResponseModel<GetWhyChooseBackgroundPhotoQueryResponse>.Fail("Background photo not found");
        }

        var response = new GetWhyChooseBackgroundPhotoQueryResponse()
        {
            Photo = getWhyChooseBackgroundPhoto.Path,
        };
        return ResponseModel<GetWhyChooseBackgroundPhotoQueryResponse>.Success(response);
    }
}