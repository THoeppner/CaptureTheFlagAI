using CaptureTheFlagAI.API.Map;
using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.Impl.Game;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.Samples
{

    public class SniperAISample : SoldierAIBase
    {
        NavAgentSample navAgent;

        ObjectInformation infoBlockingObj;

        protected override void AwakeInternal()
        {
            base.AwakeInternal();

            infoBlockingObj.GameObjectId = -1;

            navAgent = GetComponent<NavAgentSample>();
            Assert.IsNotNull(navAgent, "No NavAgentSample component is attached to " + gameObject.name);
        }

        void Start()
        {
            if (TeamMemberIndex == 1)
                navAgent.GeneratePath(Moveable.GetPosition(), new Vector3(-5, 0, 5));
            else if (TeamMemberIndex == 2)
                navAgent.GeneratePath(Moveable.GetPosition(), new Vector3(-20, 0, 20));
            else
                navAgent.GeneratePath(Moveable.GetPosition(), new Vector3(20, 0, -20));
        }

        void Update()
        {
            List<DetectedSoldier> enemiesInSight = VisualSense.GetDetectedSoldiers().FindAll(s => s.Team != Team.TeamType);
            if (enemiesInSight.Count > 0)
            {
                Moveable.Stop();
                Moveable.IsCrouching = true;
                DetectedSoldier soldier = enemiesInSight[0];
                if (Moveable.LookAt(soldier.Position))
                {
                    if (CurrentWeapon.IsHitPossible(enemiesInSight[0].Id))
                        CurrentWeapon.Shoot();
                    else
                    {
                        if (GameManager.Instance.MapManager.GetObjectInformation(CurrentWeapon.LastHitCheckObjectId, out infoBlockingObj))
                        {


                        }
                    }
                }
            }
            else if (navAgent.pathGenerated.Count > 0)
            {
                Moveable.IsCrouching = false;
                Moveable.LookAt(navAgent.pathGenerated[0]);
                Moveable.MoveTowards(navAgent.pathGenerated[0], 1f);
            }
            else
                Moveable.Stop();
        }

        private void OnDrawGizmos()
        {
            GameManager.Instance.DebugTool.DrawObjectInformation(infoBlockingObj);
        }
    }
}