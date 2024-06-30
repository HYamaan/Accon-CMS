using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Models.DTOs.Request;

public class UpdateSliderRequestDTOs
{
    public Guid Id { get; set; }
    public string Photo { get; set; }
    public string Heading { get; set; }
    public string Content { get; set; }
    public string Button1Text { get; set; }
    public string Button1Link { get; set; }
    public string Button2Text { get; set; }
    public string Button2Link { get; set; }
}