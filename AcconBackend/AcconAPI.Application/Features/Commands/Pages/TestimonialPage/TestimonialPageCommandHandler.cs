using AcconAPI.Application.Features.Commands.Pages.ServicePage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Pages.TestimonialPage;

public class TestimonialPageCommandHandler:IRequestHandler<TestimonialPageCommandRequest,ResponseModel<TestimonialPageCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.TestimonialPage> _testimonialRepository;
    private readonly IValidator<PageEntity> _validator;
    private readonly IMapper _mapper;

    public TestimonialPageCommandHandler(IGenericRepository<Domain.Entities.Page.TestimonialPage> testimonialRepository, IValidator<PageEntity> validator, IMapper mapper)
    {
        _testimonialRepository = testimonialRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<ResponseModel<TestimonialPageCommandResponse>> Handle(TestimonialPageCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {

            var pageEntity = _mapper.Map<PageEntity>(request);
            var validationResult = await _validator.ValidateAsync(pageEntity, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<TestimonialPageCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage)
                    .ToList());
            }

            var getTestimonialPage = await _testimonialRepository.GetAll().FirstOrDefaultAsync();

            if (getTestimonialPage != null)
            {
                getTestimonialPage.Heading = request.Heading;
                getTestimonialPage.MetaTitle = request.MetaTitle;
                getTestimonialPage.MetaDescription = request.MetaDescription;
                getTestimonialPage.MetaKeywords = request.MetaKeywords;

                _testimonialRepository.Update(getTestimonialPage);
            }
            else
            {
                var testimonialPage = new Domain.Entities.Page.TestimonialPage()
                {
                    Heading = request.Heading,
                    MetaTitle = request.MetaTitle,
                    MetaDescription = request.MetaDescription,
                    MetaKeywords = request.MetaKeywords
                };

                await _testimonialRepository.AddAsync(testimonialPage);
            }


            await _testimonialRepository.SaveAsync();


            return ResponseModel<TestimonialPageCommandResponse>.Success("Testimonial Page Created/Updated Successfully");
        }
        catch (Exception e)
        {
            return ResponseModel<TestimonialPageCommandResponse>.Fail(e.Message);
        }
    }
}