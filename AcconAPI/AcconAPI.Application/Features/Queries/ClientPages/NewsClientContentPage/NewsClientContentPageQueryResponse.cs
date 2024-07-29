using AcconAPI.Application.Models.DTOs.Response.ClientPage;

namespace AcconAPI.Application.Features.Queries.ClientPages.NewsClientContentPage;

public class NewsClientContentPageQueryResponse
{
    public string Url { get; set; }
    public string Photo { get; set; }
    public string BackGroundPhoto { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string Created { get; set; }
    public string LongDescription { get; set; }

    public List<GetClientNewsPopularResponseDTOs> PopularNews { get; set; }
    public List<GetClientNewsPopularResponseDTOs> LatestNews { get; set; }
}