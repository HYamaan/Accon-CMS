using AcconAPI.Application.Models.DTOs.Request;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.FluentValidation;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Menu;

public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommandRequest, ResponseModel<UpdateMenuCommandResponse>>
{
    private readonly IGenericRepository<PageEntity> _pageRepository;
    private readonly IUpdateMenuCommandRequestValidator _updateValidator;

    public UpdateMenuCommandHandler(IGenericRepository<PageEntity> pageRepository, IUpdateMenuCommandRequestValidator updateValidator)
    {
        _pageRepository = pageRepository;
        _updateValidator = updateValidator;
    }

    public async Task<ResponseModel<UpdateMenuCommandResponse>> Handle(UpdateMenuCommandRequest request, CancellationToken cancellationToken)
    {
        foreach (var pageDto in request.pages)
        {
            var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return ResponseModel<UpdateMenuCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            await UpdatePageAsync(pageDto);
        }

        return ResponseModel<UpdateMenuCommandResponse>.Success("Success");
    }

    private async Task UpdatePageAsync(UpdateCommandRequestDTOs pageDto)
    {
        var existingPage = await _pageRepository.GetByIdAsync(pageDto.Id);
        if (existingPage != null)
        {
            existingPage.IsPublished = pageDto.IsPublished;

            _pageRepository.Update(existingPage);
            await _pageRepository.SaveAsync();
        }
        else
        {
            throw new KeyNotFoundException($"Page with Id {pageDto.Id} not found.");
        }
    }
}