namespace AcconAPI.Domain.Entities.Page;

public class TestimonialPage:PageEntity
{
    ICollection<Testimonial.Testimonial> Testimonials { get; set; }
}