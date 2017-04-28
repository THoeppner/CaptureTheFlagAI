using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.API.Teams;
using System.Collections.Generic;

namespace CaptureTheFlagAI.Impl.Teams
{
    public class SoldierAITeam : Team
    {
        private TeamTypes teamType;

        private List<SoldierAIBase> soldiers = new List<SoldierAIBase>();

        public SoldierAITeam(TeamTypes teamType, string name)
        {
            this.teamType = teamType;
            this.Name = name;
        }

        public void AddSoldier(SoldierAIBase soldier)
        {
            if (!soldier) return;

            soldiers.Add(soldier);
        }

        public void RemoveSoldier(SoldierAIBase soldier)
        {
            if (!soldier) return;

            soldiers.Remove(soldier);
        }

        #region Team

        public string Name { get; set; }

        public TeamTypes TeamType { get { return teamType; } }

        public IList<SoldierAIBase> GetTeamMembers()
        {
            return soldiers.AsReadOnly();
        }

        #endregion
    }
}