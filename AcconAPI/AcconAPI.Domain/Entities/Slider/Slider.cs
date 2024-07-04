using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;

namespace AcconAPI.Domain.Entities.Slider;

public class Slider:BaseEntity
{
    public SliderPhoto Photo { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Button1Text { get; set; }
    public string Button1Link { get; set; }
    public string Button2Text { get; set; }
    public string Button2Link { get; set; }
}