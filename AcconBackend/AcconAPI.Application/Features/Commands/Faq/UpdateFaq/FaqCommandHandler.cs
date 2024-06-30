using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AcconAPI.Application.Features.Commands.Faq.UpdateFaq
{
    public class FaqCommandHandler : IRequestHandler<FaqCommandRequest, ResponseModel<FaqCommandResponse>>
    {
        private readonly IGenericRepository<Domain.Entities.Faq.Faq> _faqRepository;
        private readonly IGenericRepository<FaqPage> _faqPageRepository;

        public FaqCommandHandler(IGenericRepository<Domain.Entities.Faq.Faq> faqRepository, IGenericRepository<FaqPage> faqPageRepository)
        {
            _faqRepository = faqRepository;
            _faqPageRepository = faqPageRepository;
        }

        public async Task<ResponseModel<FaqCommandResponse>> Handle(FaqCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                return await CreateFaq(request);
            }
            else
            {
                return await UpdateFaq(request);
            }
        }

        private async Task<ResponseModel<FaqCommandResponse>> CreateFaq(FaqCommandRequest request)
        {
            var faqPage = await _faqPageRepository.GetAll().FirstOrDefaultAsync();
            if (faqPage == null)
            {
                return ResponseModel<FaqCommandResponse>.Fail("Faq page not found");
            }

            var faq = new Domain.Entities.Faq.Faq
            {
                Title = request.Title,
                Content = request.Content,
                VisiblePage = request.VisiblePlace,
                FaqPage = faqPage
            };

            await _faqRepository.AddAsync(faq);
            await _faqRepository.SaveAsync();

            return ResponseModel<FaqCommandResponse>.Success();
        }

        private async Task<ResponseModel<FaqCommandResponse>> UpdateFaq(FaqCommandRequest request)
        {
            var faq = await _faqRepository.GetByIdAsync(request.Id.ToString());

            if (faq == null)
            {
                return await CreateFaq(request);
            }

            if (faq.VisiblePage != request.VisiblePlace)
            {
                faq.VisiblePage = request.VisiblePlace;
            }

            if (faq.Title != request.Title)
            {
                faq.Title = request.Title;
            }

            if (faq.Content != request.Content)
            {
                faq.Content = request.Content;
            }

            _faqRepository.Update(faq);
            await _faqRepository.SaveAsync();
            return ResponseModel<FaqCommandResponse>.Success();
        }
    }
}
