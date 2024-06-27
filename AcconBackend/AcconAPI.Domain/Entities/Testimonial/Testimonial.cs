using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.Testimonial;
using AcconAPI.Domain.Entities.Page;

namespace AcconAPI.Domain.Entities.Testimonial;

public class Testimonial:BaseEntity
{
    public string Name { get; set; }
    public string Designation { get; set; }
    public string Company { get; set; }
    public TestimonialPhoto Photo { get; set; }
    public string Comment { get; set; }

    public TestimonialPage TestimonialPage { get; set; }
}