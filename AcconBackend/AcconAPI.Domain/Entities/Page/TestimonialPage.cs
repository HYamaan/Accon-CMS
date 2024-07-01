namespace AcconAPI.Domain.Entities.Page;

public class TestimonialPage:PageEntity
{
   public ICollection<Testimonial.Testimonial> Testimonials { get; set; }
}