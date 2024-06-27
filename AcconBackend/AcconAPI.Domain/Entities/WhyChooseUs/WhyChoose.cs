using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.WhyChooseUs;

namespace AcconAPI.Domain.Entities.WhyChooseUs;

public class WhyChoose:BaseEntity
{
    public ChooseUsIconPhoto IconPhoto { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

}