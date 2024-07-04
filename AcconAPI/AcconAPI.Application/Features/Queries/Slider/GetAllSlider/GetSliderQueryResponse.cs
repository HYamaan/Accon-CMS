using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.Slider.GetAllSlider;

public class GetSliderQueryResponse
{
    public List<SliderDTOs> Sliders { get; set; }
}