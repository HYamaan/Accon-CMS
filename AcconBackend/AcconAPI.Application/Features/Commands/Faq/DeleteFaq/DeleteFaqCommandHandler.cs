using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Faq.DeleteFaq;

public class DeleteFaqCommandHandler : IRequestHandler<DeleteFaqCommandRequest, ResponseModel<DeleteFaqCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Faq.Faq> _faqRepository;

    public DeleteFaqCommandHandler(IGenericRepository<Domain.Entities.Faq.Faq> faqRepository)
    {
        _faqRepository = faqRepository;
    }

    public async Task<ResponseModel<DeleteFaqCommandResponse>> Handle(DeleteFaqCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return ResponseModel<DeleteFaqCommandResponse>.Fail();
        }

        try
        {
            await _faqRepository.BeginTransactionAsync();
            var faq = await _faqRepository.RemoveAsync(request.Id.ToString());
            await _faqRepository.SaveAsync();
            await _faqRepository.CommitTransactionAsync();
            return ResponseModel<DeleteFaqCommandResponse>.Success();
        }
        catch (Exception e)
        {
            await _faqRepository.RollbackTransactionAsync();
            return ResponseModel<DeleteFaqCommandResponse>.Fail(e.Message);
        }
    }
}