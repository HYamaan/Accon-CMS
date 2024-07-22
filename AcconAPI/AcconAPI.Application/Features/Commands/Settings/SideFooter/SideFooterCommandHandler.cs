using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Settings.SideFooter;

public class SideFooterCommandHandler : IRequestHandler<SideFooterCommandRequest, ResponseModel<SideFooterCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Settings.GeneralContent> _generalContentRepository;

    public SideFooterCommandHandler(IGenericRepository<Domain.Entities.Settings.GeneralContent> generalContentRepository)
    {
        _generalContentRepository = generalContentRepository;
    }

    public async Task<ResponseModel<SideFooterCommandResponse>> Handle(SideFooterCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var findGeneralContent = await _generalContentRepository.GetAll().FirstOrDefaultAsync();
            if (findGeneralContent == null)
            {
                var newGeneralContent = new Domain.Entities.Settings.GeneralContent
                {
                    PopularPostCount = request.PopularPostCount,
                    RecentPostCount = request.RecentPostCount
                };
                await _generalContentRepository.AddAsync(newGeneralContent);
            }
            else
            {
                findGeneralContent.PopularPostCount = request.PopularPostCount;
                findGeneralContent.RecentPostCount = request.RecentPostCount;
                _generalContentRepository.Update(findGeneralContent);
            }

            await _generalContentRepository.SaveAsync();
            return ResponseModel<SideFooterCommandResponse>.Success();
        }
        catch (Exception e)
        {
            return ResponseModel<SideFooterCommandResponse>.Fail(e.Message);
        }
    }
}