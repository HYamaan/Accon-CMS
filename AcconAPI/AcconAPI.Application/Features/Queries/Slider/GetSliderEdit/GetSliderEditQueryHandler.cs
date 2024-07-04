using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Slider.GetSliderEdit;

public class GetSliderEditQueryHandler : IRequestHandler<GetSliderEditQueryRequest, ResponseModel<GetSliderEditQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Slider.Slider> _sliderEntity;

    public GetSliderEditQueryHandler(IGenericRepository<Domain.Entities.Slider.Slider> sliderEntity)
    {
        _sliderEntity = sliderEntity;
    }

    public async Task<ResponseModel<GetSliderEditQueryResponse>> Handle(GetSliderEditQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == null)
        {
            return ResponseModel<GetSliderEditQueryResponse>.Fail("Id cannot be null");
        }

        try
        {
            var slider = await _sliderEntity.GetWhere(edit => edit.Id == Guid.Parse(request.Id))
                .Include(p => p.Photo)
                .Select(slider => new GetSliderEditQueryResponse()
                {
                    Id = slider.Id,
                    Heading = slider.Title,
                    Content = slider.Content,
                    Button1Text = slider.Button1Text,
                    Button1Link = slider.Button1Link,
                    Button2Text = slider.Button2Text,
                    Button2Link = slider.Button2Link,
                    Photo = slider.Photo.Path,
                }).FirstAsync();


            return ResponseModel<GetSliderEditQueryResponse>.Success(slider);
        }
        catch (Exception e)
        {
            return ResponseModel<GetSliderEditQueryResponse>.Fail(e.Message);
        }
    }
}