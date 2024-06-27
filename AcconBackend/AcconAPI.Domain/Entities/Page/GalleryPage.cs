namespace AcconAPI.Domain.Entities.Page;

public class GalleryPage:PageEntity
{
    ICollection<Gallery> Galleries { get; set; }
}