using AcconAPI.Domain.Common;

namespace AcconAPI.Domain.Entities.File;

public class File:BaseEntity
{
    public string FileName { get; set; }
    public string Path { get; set; }
    public string Storage { get; set; }
    public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
}