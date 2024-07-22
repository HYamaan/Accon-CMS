namespace AcconAPI.Application.Features.Queries.Dashboard;

public class GetDashboardQueryResponse
{
    public int TotalNewsCount { get; set; }
    public int TotalNewsCategoryCount { get; set; }
    public int TotalTeamMemberCount { get; set; }
    public int TotalPortfolioCount { get; set; }
    public int TotalTestimonialCount { get; set; }
    public int TotalSliderCount { get; set; }
}