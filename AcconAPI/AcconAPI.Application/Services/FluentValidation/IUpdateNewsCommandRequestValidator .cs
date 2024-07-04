using AcconAPI.Application.Features.Commands.NewsSection.UpdateNews;
using FluentValidation;

namespace AcconAPI.Application.Services.FluentValidation;

public interface IUpdateNewsCommandRequestValidator : IValidator<UpdateNewsCommandRequest> { }