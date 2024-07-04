using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.WhyChooseUs;
using MediatR;

namespace AcconAPI.Application.Features.Commands.WhyChooseUs.DeleteWhyChooseUs;

public class DeleteWhyChooseUsCommandHandler:IRequestHandler<DeleteWhyChooseUsCommandRequest,ResponseModel<DeleteWhyChooseUsCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.WhyChooseUs.WhyChoose> _whyChooseUsRepository;

    public DeleteWhyChooseUsCommandHandler(IGenericRepository<WhyChoose> whyChooseUsRepository)
    {
        _whyChooseUsRepository = whyChooseUsRepository;
    }

    public async Task<ResponseModel<DeleteWhyChooseUsCommandResponse>> Handle(DeleteWhyChooseUsCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if(request.Id == Guid.Empty)
                return ResponseModel<DeleteWhyChooseUsCommandResponse>.Fail("Id is required");

            await _whyChooseUsRepository.BeginTransactionAsync();
            await _whyChooseUsRepository.RemoveAsync(request.Id.ToString());
            await _whyChooseUsRepository.SaveAsync();
            await _whyChooseUsRepository.CommitTransactionAsync();
            return ResponseModel<DeleteWhyChooseUsCommandResponse>.Success(new DeleteWhyChooseUsCommandResponse());
        }
        catch (Exception e)
        {
            await _whyChooseUsRepository.RollbackTransactionAsync();
          return ResponseModel<DeleteWhyChooseUsCommandResponse>.Fail(e.Message);
        }
    }
}