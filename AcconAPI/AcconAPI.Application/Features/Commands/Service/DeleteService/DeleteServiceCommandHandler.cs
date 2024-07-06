using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Service.DeleteService;

public class
    DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommandRequest,
        ResponseModel<DeleteServiceCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Service.ServiceSection> _serviceRepository;

    public DeleteServiceCommandHandler(IGenericRepository<Domain.Entities.Service.ServiceSection> serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<ResponseModel<DeleteServiceCommandResponse>> Handle(DeleteServiceCommandRequest request,
        CancellationToken cancellationToken)
    {
        var service = await _serviceRepository.GetByIdAsync(request.Id.ToString());
        if (service == null)
        {
            return ResponseModel<DeleteServiceCommandResponse>.Fail("Service not found");
        }

        await _serviceRepository.RemoveAsync(request.Id.ToString());
        await _serviceRepository.SaveAsync();

        return ResponseModel<DeleteServiceCommandResponse>.Success();
    }
}