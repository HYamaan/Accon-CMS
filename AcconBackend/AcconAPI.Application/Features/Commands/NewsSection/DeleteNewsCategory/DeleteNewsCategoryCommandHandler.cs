using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.NewsSection.DeleteNewsCategory;

public class DeleteNewsCategoryCommandHandler:IRequestHandler<DeleteNewsCategoryCommandRequest,ResponseModel<DeleteNewsCategoryCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.News.NewsCategory> _newsCategoryRepository;

    public DeleteNewsCategoryCommandHandler(IGenericRepository<Domain.Entities.News.NewsCategory> newsCategoryRepository)
    {
        _newsCategoryRepository = newsCategoryRepository;
    }

    public async Task<ResponseModel<DeleteNewsCategoryCommandResponse>> Handle(DeleteNewsCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Id == Guid.Empty)
            {
                return ResponseModel<DeleteNewsCategoryCommandResponse>.Fail("Id is required");
            }

            await _newsCategoryRepository.RemoveAsync(request.Id.ToString());
            await _newsCategoryRepository.SaveAsync();
            return ResponseModel<DeleteNewsCategoryCommandResponse>.Success();
        }
        catch (Exception e)
        {
           return ResponseModel<DeleteNewsCategoryCommandResponse>.Fail(e.Message);
        }
    }
}