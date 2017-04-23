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
        protected LayerMask layerMask;

        public SimpleVisualSense(Transform owner, float viewAngle, float viewDistance, LayerMask layerMask)
        {
            this.owner = owner;
            this.viewAngle = viewAngle;
            this.viewDistance = viewDistance;
            this.layerMask = layerMask;
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

            Vector3 v1 = owner.position;
            v1.y = 1;

            RaycastHit hitInfo;
            if (!Physics.Raycast(v1, toSoldier, out hitInfo, viewDistance, layerMask) ||
                (hitInfo.transform.gameObject.GetInstanceID() != s.transform.gameObject.GetInstanceID()))
                return false;

            Vector3 v2 = s.Moveable.GetPosition();
            v2.y = 1;
            Debug.DrawLine(v1, v2);

            return true;
        }
    }
}