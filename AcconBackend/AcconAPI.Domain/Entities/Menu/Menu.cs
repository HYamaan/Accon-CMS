using AcconAPI.Domain.Common;

namespace AcconAPI.Domain.Entities.Menu;

public class Menu:BaseEntity
{
    public bool HomePageVisible { get; set; }
    public bool AboutPageVisible { get; set; }
    public bool GalleryPageVisible { get; set; }
    public bool FaqPageVisible { get; set; }
    public bool ServicePageVisible { get; set; }
    public bool PortfolioPageVisible { get; set; }
    public bool TestimonialPageVisible { get; set; }
    public bool NewsPageVisible { get; set; }
    public bool ContactPageVisible { get; set; }



    
}