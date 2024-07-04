using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Partner.DeletePartner;

public class DeletePartnerCommandHandler: IRequestHandler<DeletePartnerCommandRequest, ResponseModel<DeletePartnerCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Partner.Partner> _partnerRepository;

    public DeletePartnerCommandHandler(IGenericRepository<Domain.Entities.Partner.Partner> partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }

    public async Task<ResponseModel<DeletePartnerCommandResponse>> Handle(DeletePartnerCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if(request.Id == null)
                return ResponseModel<DeletePartnerCommandResponse>.Fail("Id is required");

            await _partnerRepository.RemoveAsync(request.Id.ToString());
            return ResponseModel<DeletePartnerCommandResponse>.Success();
        }
        catch (Exception e)
        {
            return ResponseModel<DeletePartnerCommandResponse>.Fail(e.Message);
        }
    }
}