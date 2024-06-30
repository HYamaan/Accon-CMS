using AcconAPI.Application.Features.Commands.Pages.TestimonialPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Pages.NewsPage;

public class NewsPageCommandHandler : IRequestHandler<NewsPageCommandRequest, ResponseModel<NewsPageCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.NewsPage> _newsRepository;
    private readonly IValidator<PageEntity> _validator;
    private readonly IMapper _mapper;

    public NewsPageCommandHandler(IGenericRepository<Domain.Entities.Page.NewsPage> newsRepository,
        IValidator<PageEntity> validator, IMapper mapper)
    {
        _newsRepository = newsRepository;
        _validator = validator;
        _mapper = mapper;
    }


    public async Task<ResponseModel<NewsPageCommandResponse>> Handle(NewsPageCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {

            var pageEntity = _mapper.Map<PageEntity>(request);
            var validationResult = await _validator.ValidateAsync(pageEntity, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<NewsPageCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage)
                    .ToList());
            }

            var getNewsPage = await _newsRepository.GetAll().FirstOrDefaultAsync();

            if (getNewsPage != null)
            {
                getNewsPage.Heading = request.Heading;
                getNewsPage.MetaTitle = request.MetaTitle;
                getNewsPage.MetaDescription = request.MetaDescription;
                getNewsPage.MetaKeywords = request.MetaKeywords;

                _newsRepository.Update(getNewsPage);
            }
            else
            {
                var newsPage = new Domain.Entities.Page.NewsPage()
                {
                    Heading = request.Heading,
                    MetaTitle = request.MetaTitle,
                    MetaDescription = request.MetaDescription,
                    MetaKeywords = request.MetaKeywords
                };

                await _newsRepository.AddAsync(newsPage);
                await _newsRepository.SaveAsync();
            }

            return ResponseModel<NewsPageCommandResponse>.Success("News Page Created/Updated Successfully");
        }
        catch(Exception e)
        {
            return ResponseModel<NewsPageCommandResponse>.Fail(e.Message);
        }

    }
}