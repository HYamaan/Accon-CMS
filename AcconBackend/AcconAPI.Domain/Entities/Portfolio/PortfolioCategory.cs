using AcconAPI.Domain.Common;

namespace AcconAPI.Domain.Entities.Portfolio;

public class PortfolioCategory:BaseEntity
{
    public string Title { get; set; }
    public bool IsActive { get; set; }

}