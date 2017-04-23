using CaptureTheFlagAI.API.Senses;
using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.Impl.Game;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Senses
{

    public class SimpleVisualSense : VisualSense
    {
        protected Transform owner;
        protected float viewAngle;
        protected float viewDistance;

        public SimpleVisualSense(Transform owner, float viewAngle, float viewDistance)
        {
            this.owner = owner;
            this.viewAngle = viewAngle;
            this.viewDistance = viewDistance;
        }

        
        #region VisualSense

        public List<DetectedSoldier> GetDetectedSoldiers(List<DetectedSoldier> soldiers = null)
        {
            if (soldiers == null)
                soldiers = new List<DetectedSoldier>();

            foreach (SoldierAIBase s in GameManager.Instance.TeamManager.TeamA.GetTeamMembers())
            {
                if (!IsSoldierVisible(s))
                    continue;
                DetectedSoldier d = new DetectedSoldier() { Position = s.Moveable.GetPosition(), Rotation = s.Moveable.GetRotation(), Team = s.Team.TeamType, SoldierType = s.SoldierType };
                soldiers.Add(d);
            }

            foreach (SoldierAIBase s in GameManager.Instance.TeamManager.TeamB.GetTeamMembers())
            {
                if (!IsSoldierVisible(s))
                    continue;
                DetectedSoldier d = new DetectedSoldier() { Position = s.Moveable.GetPosition(), Rotation = s.Moveable.GetRotation(), Team = s.Team.TeamType, SoldierType = s.SoldierType };
                soldiers.Add(d);
            }

            return soldiers;
        }

        #endregion

        bool IsSoldierVisible(SoldierAIBase s)
        {
            Vector3 toSoldier = s.Moveable.GetPosition() - owner.position;
            float viewAngleHalf = viewAngle / 2;
            float viewDistanceSqr = viewDistance * viewDistance;

            if ((Vector3.Angle(this.owner.forward, toSoldier) > viewAngleHalf) || (toSoldier.sqrMagnitude > viewDistanceSqr))
                return false;

            return true;
        }
    }
}