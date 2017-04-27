using CaptureTheFlagAI.API.Senses;
using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.Impl.Game;
using CaptureTheFlagAI.Impl.Soldier;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Senses
{

    public class SimpleVisualSense : VisualSense
    {
        protected SoldierBase owner;
        protected float viewAngle;
        protected float viewDistance;
        protected LayerMask layerMask;

        public SimpleVisualSense(SoldierBase owner, LayerMask layerMask)
        {
            this.owner = owner;
            this.viewAngle = owner.GetStatistics().ViewAngle;
            this.viewDistance = owner.GetStatistics().ViewDistance;
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
                DetectedSoldier d = new DetectedSoldier() { Position = s.Moveable.GetPosition(), Rotation = s.Moveable.GetRotation(), Team = s.Team.TeamType,
                    SoldierType = s.SoldierType, Id = s.gameObject.GetInstanceID() };
                soldiers.Add(d);
            }

            foreach (SoldierAIBase s in GameManager.Instance.TeamManager.TeamB.GetTeamMembers())
            {
                if (!IsSoldierVisible(s))
                    continue;
                DetectedSoldier d = new DetectedSoldier() { Position = s.Moveable.GetPosition(), Rotation = s.Moveable.GetRotation(), Team = s.Team.TeamType,
                    SoldierType = s.SoldierType, Id = s.gameObject.GetInstanceID() };
                soldiers.Add(d);
            }

            return soldiers;
        }

        #endregion

        bool IsSoldierVisible(SoldierAIBase soldier)
        {
            Vector3 v1 = owner.GetAnatomy().GetHeadPosition();
            Vector3 v2 = soldier.Anatomy.GetHeadPosition();
            Vector3 toSoldier = v2 - v1;
            float viewAngleHalf = viewAngle / 2;
            float viewDistanceSqr = viewDistance * viewDistance;

            if ((Vector3.Angle(owner.GetMoveable().GetForwardVector(), toSoldier) > viewAngleHalf) || (toSoldier.sqrMagnitude > viewDistanceSqr))
                return false;

            RaycastHit hitInfo;
            if (!Physics.SphereCast(v1, 0.2f, toSoldier, out hitInfo, viewDistance, layerMask) || (hitInfo.transform.GetInstanceID() != soldier.transform.GetInstanceID()))
                return false;

            //if (!Physics.Raycast(v1, toSoldier, out hitInfo, viewDistance, layerMask) || (hitInfo.transform.GetInstanceID() != soldier.transform.GetInstanceID()))
            //    return false;

            Debug.DrawLine(v1, v2);

            return true;
        }
    }
}