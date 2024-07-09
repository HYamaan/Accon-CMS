using AcconAPI.Application.Features.Commands.Pages.PortfolioPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Pages.HomePage;

public class PortfolioPageCommandHandler : IRequestHandler<HomePageCommandRequest, ResponseModel<HomePageCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.HomePage> _homePageRepository;

    private readonly IValidator<PageEntity> _validator;
    private readonly IMapper _mapper;

    public PortfolioPageCommandHandler(IGenericRepository<Domain.Entities.Page.HomePage> homePageRepository, IValidator<PageEntity> validator, IMapper mapper)
    {
        _homePageRepository = homePageRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<ResponseModel<HomePageCommandResponse>> Handle(HomePageCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {

            var pageEntity = _mapper.Map<PageEntity>(request);
            var validationResult = await _validator.ValidateAsync(pageEntity, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<HomePageCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage)
                    .ToList());
            }

            var getHomePage = await _homePageRepository.GetAll().FirstOrDefaultAsync();

            if (getHomePage != null)
            {
                getHomePage.MetaTitle = request.MetaTitle;
                getHomePage.MetaDescription = request.MetaDescription;
                getHomePage.MetaKeywords = request.MetaKeywords;

                _homePageRepository.Update(getHomePage);
            }
            else
            {
                var homePage = new Domain.Entities.Page.HomePage
                {
                    Heading = "HomePage",
                    MetaTitle = request.MetaTitle,
                    MetaDescription = request.MetaDescription,
                    MetaKeywords = request.MetaKeywords
                };

                await _homePageRepository.AddAsync(homePage);
            }


            await _homePageRepository.SaveAsync();


            return ResponseModel<HomePageCommandResponse>.Success("Home Page Created/Updated Successfully");
        }
        catch (Exception e)
        {
            return ResponseModel<HomePageCommandResponse>.Fail(e.Message);
        }
    }
}