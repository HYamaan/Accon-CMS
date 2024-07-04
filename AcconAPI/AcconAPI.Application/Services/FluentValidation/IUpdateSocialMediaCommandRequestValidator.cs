using AcconAPI.Application.Features.Commands.SocialMedia;
using FluentValidation;

namespace AcconAPI.Application.Services.FluentValidation;

public interface IUpdateSocialMediaCommandRequestValidator:IValidator<UpdateSocialMediaCommandRequest> { }