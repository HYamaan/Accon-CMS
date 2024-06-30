using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Slider.DeleteSlider;

public class DeleteSliderCommandHandler : IRequestHandler<DeleteSliderCommandRequest, ResponseModel<DeleteSliderCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Slider.Slider> _sliderRepository;

    public DeleteSliderCommandHandler(IGenericRepository<Domain.Entities.Slider.Slider> sliderRepository)
    {
        _sliderRepository = sliderRepository;
    }

    public async Task<ResponseModel<DeleteSliderCommandResponse>> Handle(DeleteSliderCommandRequest request, CancellationToken cancellationToken)
    {
        var slider = await _sliderRepository.GetWhere(p => p.Id == request.Id).FirstOrDefaultAsync();
        if (slider == null)
        {
            return ResponseModel<DeleteSliderCommandResponse>.Fail("Slider not found");
        }

        await _sliderRepository.RemoveAsync(slider.Id.ToString());
        await _sliderRepository.SaveAsync();

        return ResponseModel<DeleteSliderCommandResponse>.Success("Slider Deleted Successfully");
    }
}