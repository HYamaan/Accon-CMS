using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Partner.GetAllPartner;

public class GetAllPartnerCommandHandler:IRequestHandler<GetAllPartnerCommandRequest, ResponseModel<GetAllPartnerCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Partner.Partner> _partnerRepository;

    public GetAllPartnerCommandHandler(IGenericRepository<Domain.Entities.Partner.Partner> partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }

    public async Task<ResponseModel<GetAllPartnerCommandResponse>> Handle(GetAllPartnerCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var partners = await _partnerRepository.GetAll()
                .Include(x => x.Photo)
                .Select(ux => new GetAllPartnerResponseDTOs()
                {
                    Id = ux.Id,
                    Name = ux.Name,
                    Photo = ux.Photo.Path
                })
                .ToListAsync(cancellationToken);

            var response = new GetAllPartnerCommandResponse()
            {
                Partners = partners
            };
            return ResponseModel<GetAllPartnerCommandResponse>.Success(response);

        }
        catch (Exception e)
        {
           return ResponseModel<GetAllPartnerCommandResponse>.Fail(e.Message);
        }


    }
}