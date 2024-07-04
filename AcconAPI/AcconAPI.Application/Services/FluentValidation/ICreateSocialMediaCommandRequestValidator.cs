using AcconAPI.Application.Features.Commands.SocialMedia;
using AcconAPI.Application.Models.DTOs.Request;
using FluentValidation;

namespace AcconAPI.Application.Services.FluentValidation;

public interface ICreateSocialMediaCommandRequestValidator : IValidator<UpdateSocialMediaCommandRequest> { }