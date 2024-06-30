using AcconAPI.Application.Features.Commands.Pages.TestimonialPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Pages.PortfolioPage;

public class PortfolioPageCommandHandler : IRequestHandler<
    PortfolioPageCommandRequest, ResponseModel<PortfolioPageCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.PortfolioPage> _portfolioPageRepository;
    private readonly IValidator<PageEntity> _validator;
    private readonly IMapper _mapper;

    public PortfolioPageCommandHandler(IGenericRepository<Domain.Entities.Page.PortfolioPage> portfolioPageRepository,
        IMapper mapper, IValidator<PageEntity> validator)
    {
        _portfolioPageRepository = portfolioPageRepository;
        _mapper = mapper;
        _validator = validator;
    }


    public async Task<ResponseModel<PortfolioPageCommandResponse>> Handle(PortfolioPageCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {

            var pageEntity = _mapper.Map<PageEntity>(request);
            var validationResult = await _validator.ValidateAsync(pageEntity, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<PortfolioPageCommandResponse>.Fail(validationResult.Errors
                    .Select(e => e.ErrorMessage)
                    .ToList());
            }

            var getPortfolioPage = await _portfolioPageRepository.GetAll().FirstOrDefaultAsync();

            if (getPortfolioPage != null)
            {
                getPortfolioPage.Heading = request.Heading;
                getPortfolioPage.MetaTitle = request.MetaTitle;
                getPortfolioPage.MetaDescription = request.MetaDescription;
                getPortfolioPage.MetaKeywords = request.MetaKeywords;

                _portfolioPageRepository.Update(getPortfolioPage);
            }
            else
            {
                var portfolioPage = new Domain.Entities.Page.PortfolioPage()
                {
                    Heading = request.Heading,
                    MetaTitle = request.MetaTitle,
                    MetaDescription = request.MetaDescription,
                    MetaKeywords = request.MetaKeywords
                };

                await _portfolioPageRepository.AddAsync(portfolioPage);
            }


            await _portfolioPageRepository.SaveAsync();
            return ResponseModel<PortfolioPageCommandResponse>.Success("Portfolio Page Created/Updated Successfully");
        }
        catch (Exception e)
        {
            return ResponseModel<PortfolioPageCommandResponse>.Fail(e.Message);
        }
    }
}