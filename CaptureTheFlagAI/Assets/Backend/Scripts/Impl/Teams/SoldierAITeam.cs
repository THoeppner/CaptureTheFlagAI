using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.API.Teams;
using System.Collections.Generic;

namespace CaptureTheFlagAI.Impl.Teams
{
    public class SoldierAITeam : Team
    {
        List<SoldierAIBase> soldiers = new List<SoldierAIBase>();

        public void AddSoldier(SoldierAIBase soldier)
        {
            if (!soldier)
                return;

            soldiers.Add(soldier);
        }

        #region Team

        public string Name { get; set; }

        public IList<SoldierAIBase> GetTeamMembers()
        {
            return soldiers.AsReadOnly();
        }

        #endregion
    }
}