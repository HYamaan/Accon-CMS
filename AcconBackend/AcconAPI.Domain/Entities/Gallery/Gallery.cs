using AcconAPI.Domain.Entities.File;
using AcconAPI.Domain.Entities.Page;
using AcconAPI.Domain.Enum;

namespace AcconAPI.Domain.Entities.Gallery;

public class Gallery
{
    public string Title { get; set; }
    public GalleryPhoto GalleryPhoto { get; set; }
    public VisiblePlace IsVisible { get; set; }

    public GalleryPage GalleryPage { get; set; }
}