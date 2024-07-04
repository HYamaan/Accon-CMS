using AcconAPI.Application.Features.Commands.PhotoGallery.UpdateGallery;
using FluentValidation;

namespace AcconAPI.Application.Services.FluentValidation;

public interface IUpdatePhotoGalleryValidator : IValidator<UpdateGalleryCommandRequest> { }