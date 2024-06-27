using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;

namespace AcconAPI.Domain.Entities.TeamMember;

public class TeamMember:BaseEntity
{
    public string Name { get; set; }

    public Designation Designation { get; set; }
    public TeamMemberPhoto Photo { get; set; }

    public string Facebook { get; set; }
    public string Twitter { get; set; }
    public string LinkedIn { get; set; }
    public string Youtube { get; set; }

}