using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Settings.GeneralContent.GeneralInformation;

public class GeneralContentCommandHandler : IRequestHandler<GeneralContentCommandRequest, ResponseModel<GeneralContentCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Settings.GeneralContent> _generalContentRepository;

    public GeneralContentCommandHandler(IGenericRepository<Domain.Entities.Settings.GeneralContent> generalContentRepository)
    {
        _generalContentRepository = generalContentRepository;
    }

    public async Task<ResponseModel<GeneralContentCommandResponse>> Handle(GeneralContentCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var findGeneralContent = await _generalContentRepository.GetAll().FirstOrDefaultAsync();
            if (findGeneralContent == null)
            {

                var newGeneralContent = new Domain.Entities.Settings.GeneralContent
                {
                    FooterCopyRight = request.FooterCopyRight,
                    FooterAdress = request.FooterAdress,
                    FooterPhone = request.FooterPhone,
                    FooterWorkingHours = request.FooterWorkingHours,
                    FooterAboutUs = request.FooterAboutUs,
                    TopBarEmail = request.TopBarEmail,
                    TopBarPhone = request.TopBarPhone,
                    ContactMap = request.ContactMap,
                    RecentPostCount = 0,
                    PopularPostCount = 0

                };
                await _generalContentRepository.AddAsync(newGeneralContent);
            }
            else
            {
                findGeneralContent.FooterCopyRight = request.FooterCopyRight;
                findGeneralContent.FooterAdress = request.FooterAdress;
                findGeneralContent.FooterPhone = request.FooterPhone;
                findGeneralContent.FooterWorkingHours = request.FooterWorkingHours;
                findGeneralContent.FooterAboutUs = request.FooterAboutUs;
                findGeneralContent.TopBarEmail = request.TopBarEmail;
                findGeneralContent.TopBarPhone = request.TopBarPhone;
                findGeneralContent.ContactMap = request.ContactMap;
                _generalContentRepository.Update(findGeneralContent);
            }
            await _generalContentRepository.SaveAsync();

            return ResponseModel<GeneralContentCommandResponse>.Success();

        }
        catch (Exception e)
        {
           return ResponseModel<GeneralContentCommandResponse>.Fail(e.Message);
        }
    }
}