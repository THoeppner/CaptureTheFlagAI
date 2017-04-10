
using CaptureTheFlagAI.API.Soldier;
using System.Collections.Generic;

namespace CaptureTheFlagAI.API.Teams
{
    public interface Team
    {
        string Name { get; set; }

        IList<SoldierAIBase> GetTeamMembers();
    }
}