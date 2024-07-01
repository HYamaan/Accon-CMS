using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Partner.GetEditPartner;

public class GetEditPartnerCommandHandler:IRequestHandler<GetEditPartnerCommandRequest,ResponseModel<GetEditPartnerCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Partner.Partner> _partnerRepository;

    public GetEditPartnerCommandHandler(IGenericRepository<Domain.Entities.Partner.Partner> partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }

    public async Task<ResponseModel<GetEditPartnerCommandResponse>> Handle(GetEditPartnerCommandRequest request, CancellationToken cancellationToken)
    {
        if(request.Id == null)
            return ResponseModel<GetEditPartnerCommandResponse>.Fail("Id is Required");

        var partner = await _partnerRepository.GetWhere(ux=>ux.Id == request.Id)
            .Include(x => x.Photo)
            .Select(ux => new GetEditPartnerCommandResponse()
            {
                Id = ux.Id,
                Name = ux.Name,
                Path = ux.Photo.Path,
            }).FirstOrDefaultAsync(cancellationToken);

        return ResponseModel<GetEditPartnerCommandResponse>.Success(partner);
    }
}