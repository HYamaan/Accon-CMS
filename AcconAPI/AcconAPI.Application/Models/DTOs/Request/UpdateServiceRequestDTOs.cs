using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Models.DTOs.Request;

public class UpdateServiceRequestDTOs
{
    public Guid Id { get; set; }

    public string Heading { get; set; }
    public string ShortContent { get; set; }
    public string Content { get; set; }
    public IFormFile Photo { get; set; }
    public IFormFile Banner { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }


}