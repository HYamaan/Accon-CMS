using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.TestimonialSection.TestimonialMainPhoto;

public class TestimonialMainPhotoCommandRequest : IRequest<ResponseModel<TestimonialMainPhotoCommandResponse>>
{
    public IFormFile Photo { get; set; }
}