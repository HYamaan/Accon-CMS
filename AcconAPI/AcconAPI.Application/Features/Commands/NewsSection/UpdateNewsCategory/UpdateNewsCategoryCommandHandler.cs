using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.NewsSection.NewsCategory;

public class UpdateNewsCategoryCommandHandler : IRequestHandler<UpdateNewsCategoryCommandRequest, ResponseModel<UpdateNewsCategoryCommandResponse
    >>
{
    private readonly IGenericRepository<Domain.Entities.News.NewsCategory> _newsCategoryRepository;

    public UpdateNewsCategoryCommandHandler(IGenericRepository<Domain.Entities.News.NewsCategory> newsCategoryRepository)
    {
        _newsCategoryRepository = newsCategoryRepository;
    }

    public async Task<ResponseModel<UpdateNewsCategoryCommandResponse>> Handle(UpdateNewsCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            var response = new Domain.Entities.News.NewsCategory()
            {
                Title = request.Title,
            };
            await _newsCategoryRepository.AddAsync(response);

            await _newsCategoryRepository.SaveAsync();
            return ResponseModel<UpdateNewsCategoryCommandResponse>.Success();
        }
        else
        {
            var response = await _newsCategoryRepository.GetByIdAsync(request.Id.ToString());
            if (response == null)
            {
                return ResponseModel<UpdateNewsCategoryCommandResponse>.Fail();
            }
            response.Title = request.Title;
            _newsCategoryRepository.Update(response);
            await _newsCategoryRepository.SaveAsync();
            return ResponseModel<UpdateNewsCategoryCommandResponse>.Success();
        }
    }

}