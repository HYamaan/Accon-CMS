using AcconAPI.Application.Models.DTOs.Request;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.FluentValidation;
using AcconAPI.Domain.Common;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Language
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommandRequest, ResponseModel<UpdateLanguageCommandResponse>>
    {
        private readonly IGenericRepository<Domain.Entities.Language.Language> _languageRepository;
        private readonly IUpdateLanguageCommandRequestValidator _updateValidator;
        private readonly ICreateLanguageCommandRequestValidator _createValidator;

        public UpdateLanguageCommandHandler(
            IGenericRepository<Domain.Entities.Language.Language> languageRepository,
            IUpdateLanguageCommandRequestValidator updateValidator,
            ICreateLanguageCommandRequestValidator createValidator)
        {
            _languageRepository = languageRepository;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }

        public async Task<ResponseModel<UpdateLanguageCommandResponse>> Handle(UpdateLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            foreach (var languageDto in request.languages)
            {
                ValidationResult validationResult;

                if (languageDto.Id.HasValue)
                {
                    validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
                    if (!validationResult.IsValid)
                    {
                        return ResponseModel<UpdateLanguageCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                    }

                    await UpdateLanguageAsync(languageDto);
                }
                else
                {
                    validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
                    if (!validationResult.IsValid)
                    {
                        return  ResponseModel<UpdateLanguageCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

                    }

                    await CreateLanguageAsync(languageDto);
                }
            }

            return  ResponseModel<UpdateLanguageCommandResponse>.Success();
        }

        private async Task UpdateLanguageAsync(UpdateLanguageRequestDTOs languageDto)
        {
            var existingLanguage = await _languageRepository.GetByIdAsync(languageDto.Id.ToString());
            if (existingLanguage != null)
            {
                existingLanguage.Content = languageDto.Content;
                existingLanguage.Title = languageDto.Title;

                _languageRepository.Update(existingLanguage);
                await _languageRepository.SaveAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Language with Id {languageDto.Id.Value} not found.");
            }
        }

        private async Task CreateLanguageAsync(UpdateLanguageRequestDTOs languageDto)
        {
            var newLanguage = new Domain.Entities.Language.Language
            {
                Id = Guid.NewGuid(),
                Title = languageDto.Title.ToUpperInvariant(),
                Content = languageDto.Content
            };

            await _languageRepository.AddAsync(newLanguage);
            await _languageRepository.SaveAsync();
        }
    }
}
