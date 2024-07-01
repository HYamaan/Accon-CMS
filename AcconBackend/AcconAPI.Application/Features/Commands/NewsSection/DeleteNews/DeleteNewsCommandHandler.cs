using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.News;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.NewsSection.DeleteNews;

public class DeleteNewsCommandHandler:IRequestHandler<DeleteNewsCommandRequest, ResponseModel<DeleteNewsCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.News.News> _newsRepository;

    public DeleteNewsCommandHandler(IGenericRepository<News> newsRepository)
    {
        _newsRepository = newsRepository;
    }

    public async Task<ResponseModel<DeleteNewsCommandResponse>> Handle(DeleteNewsCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Id == Guid.Empty)
                return ResponseModel<DeleteNewsCommandResponse>.Fail("Id is not valid");

            await _newsRepository.BeginTransactionAsync();
            await _newsRepository.RemoveAsync(request.Id.ToString());
            await _newsRepository.CommitTransactionAsync();
            await _newsRepository.SaveAsync();
            return ResponseModel<DeleteNewsCommandResponse>.Success();
        }
        catch (Exception e)
        {
            await _newsRepository.RollbackTransactionAsync();
            return ResponseModel<DeleteNewsCommandResponse>.Fail(e.Message);
        }

    }
}