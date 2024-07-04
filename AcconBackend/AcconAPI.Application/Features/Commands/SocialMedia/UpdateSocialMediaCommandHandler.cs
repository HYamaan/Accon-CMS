using AcconAPI.Application.Models.DTOs.Request;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.FluentValidation;
using AcconAPI.Domain.Common;
using MediatR;
using static AcconAPI.Application.FluentValidation.SocialMediaCommandRequestValidator;

namespace AcconAPI.Application.Features.Commands.SocialMedia
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommandRequest,
        ResponseModel<UpdateSocialMediaCommandResponse>>
    {
        private readonly IGenericRepository<Domain.Entities.SocialMedia.SocialMedia> _socialMediaRepository;
        private readonly IUpdateSocialMediaCommandRequestValidator _updateValidator;
        private readonly ICreateSocialMediaCommandRequestValidator _createValidator;

        public UpdateSocialMediaCommandHandler(
            IGenericRepository<Domain.Entities.SocialMedia.SocialMedia> socialMediaRepository,
            IUpdateSocialMediaCommandRequestValidator updateValidator,
            ICreateSocialMediaCommandRequestValidator createValidator)
        {
            _socialMediaRepository = socialMediaRepository;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }

        public async Task<ResponseModel<UpdateSocialMediaCommandResponse>> Handle(
            UpdateSocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            foreach (var socialDto in request.Socials)
            {
                var validationResult = socialDto.Id.HasValue
                    ? await _updateValidator.ValidateAsync(request, cancellationToken)
                    : await _createValidator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return ResponseModel<UpdateSocialMediaCommandResponse>.Fail(validationResult.Errors
                        .Select(e => e.ErrorMessage).ToList());
                }

                if (socialDto.Id.HasValue)
                {
                    await UpdateSocialMediaAsync(socialDto);
                }
                else
                {
                    await CreateSocialMediaAsync(socialDto);
                }
            }

            return ResponseModel<UpdateSocialMediaCommandResponse>.Success();
        }

        private async Task UpdateSocialMediaAsync(UpdateSocialMediaRequestDTOs socialDto)
        {
            var existingSocialMedia = await _socialMediaRepository.GetByIdAsync(socialDto.Id.ToString());
            if (existingSocialMedia != null)
            {
                existingSocialMedia.Content = socialDto.Content;
                existingSocialMedia.Title = socialDto.Title;

                _socialMediaRepository.Update(existingSocialMedia);
                await _socialMediaRepository.SaveAsync();
            }
            else
            {
                throw new KeyNotFoundException($"SocialMedia with Id {socialDto.Id.Value} not found.");
            }
        }

        private async Task CreateSocialMediaAsync(UpdateSocialMediaRequestDTOs socialDto)
        {
            var newSocialMedia = new Domain.Entities.SocialMedia.SocialMedia
            {
                Id = Guid.NewGuid(),
                Title = socialDto.Title,
                Content = socialDto.Content
            };

            await _socialMediaRepository.AddAsync(newSocialMedia);
            await _socialMediaRepository.SaveAsync();
        }
    }
}