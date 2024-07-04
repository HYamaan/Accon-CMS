using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Slider.GetAllSlider;

public class GetSliderQueryHandler : IRequestHandler<GetSliderQueryRequest, ResponseModel<GetSliderQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Slider.Slider> _sliderEntity;

    public GetSliderQueryHandler(IGenericRepository<Domain.Entities.Slider.Slider> sliderEntity)
    {
        _sliderEntity = sliderEntity;
    }

    public async Task<ResponseModel<GetSliderQueryResponse>> Handle(GetSliderQueryRequest request, CancellationToken cancellationToken)
    {
        var sliders = await _sliderEntity.GetAll()
            .Include(s => s.Photo)
            .Select(slider => new SliderDTOs()
            {
                Id = slider.Id,
                Heading = slider.Title,
                Content = slider.Content,
                Button1Text = slider.Button1Text,
                Button1Link = slider.Button1Link,
                Button2Text = slider.Button2Text,
                Button2Link = slider.Button2Link,
                Path = slider.Photo.Path,

            })
            .ToListAsync(cancellationToken);

        return ResponseModel<GetSliderQueryResponse>.Success(new GetSliderQueryResponse
        {
            Sliders = sliders
        });
    }
}