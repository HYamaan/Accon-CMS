using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Settings.GeneralContent;

public class GeneralContentQueryHandler:IRequestHandler<GeneralContentQueryRequest,ResponseModel<GeneralContentQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Settings.GeneralContent> _generalContentRepository;
    private readonly IGenericRepository<Domain.Entities.File.Settings.FooterAdressIcon> _footerAdressIconRepository;
    private readonly IGenericRepository<Domain.Entities.File.Settings.FooterPhoneIcon> _footerPhoneIconRepository;
    private readonly IGenericRepository<Domain.Entities.File.Settings.FooterWorkingIcon> _footerWorkingHourIconRepository;

    public GeneralContentQueryHandler(IGenericRepository<Domain.Entities.Settings.GeneralContent> generalContentRepository, IGenericRepository<FooterAdressIcon> footerAdressIconRepository, IGenericRepository<FooterPhoneIcon> footerPhoneIconRepository, IGenericRepository<FooterWorkingIcon> footerMailIconRepository)
    {
        _generalContentRepository = generalContentRepository;
        _footerAdressIconRepository = footerAdressIconRepository;
        _footerPhoneIconRepository = footerPhoneIconRepository;
        _footerWorkingHourIconRepository = footerMailIconRepository;
    }

    public async Task<ResponseModel<GeneralContentQueryResponse>> Handle(GeneralContentQueryRequest request, CancellationToken cancellationToken)
    {
       var generalContent = await _generalContentRepository.GetAll().FirstOrDefaultAsync();
       var footerAdressIcon = await _footerAdressIconRepository.GetAll().FirstOrDefaultAsync();
       var footerPhoneIcon = await _footerPhoneIconRepository.GetAll().FirstOrDefaultAsync();
       var footerMailIcon = await _footerWorkingHourIconRepository.GetAll().FirstOrDefaultAsync();

       var response = new GeneralContentQueryResponse()
       {
           AboutUs = generalContent?.FooterAboutUs,
           Address = generalContent?.FooterAdress,
           ContactMap = generalContent?.ContactMap,
           CopyRight = generalContent?.FooterCopyRight,
           WorkingHour = generalContent?.FooterWorkingHours,
           TopBarEmail = generalContent?.TopBarEmail,
           TopBarPhone = generalContent?.TopBarPhone,
           Phone = generalContent?.FooterPhone,
           FooterAdressIcon = footerAdressIcon?.Path,
           FooterWorkingHoutIcon = footerMailIcon?.Path,
           FooterPhoneIcon = footerPhoneIcon?.Path,
       };

       return ResponseModel<GeneralContentQueryResponse>.Success(response);

    }
}