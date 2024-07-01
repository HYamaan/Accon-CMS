namespace AcconAPI.Domain.Entities.Page;

public class GalleryPage:PageEntity
{
   public ICollection<Gallery> Galleries { get; set; }
}