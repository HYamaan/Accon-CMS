namespace AcconAPI.Domain.Entities.Page;

public class GalleryPage:PageEntity
{
   public ICollection<Domain.Entities.Gallery.Gallery> Galleries { get; set; }
}