using CaptureTheFlagAI.API.Soldier;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.Samples
{

    public class SniperAISample : SoldierAIBase
    {
        NavAgentSample navAgent;

        protected override void AwakeInternal()
        {
            base.AwakeInternal();

            navAgent = GetComponent<NavAgentSample>();
            Assert.IsNotNull(navAgent, "No NavAgentSample component is attached to " + gameObject.name);
        }

        void Start()
        {
            if (TeamMemberIndex == 1)
                navAgent.GeneratePath(Moveable.GetPosition(), new Vector3(-20, 0 ,20));
            else if (TeamMemberIndex == 2)
                navAgent.GeneratePath(Moveable.GetPosition(), new Vector3(-5, 0, 5));
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
                    CurrentWeapon.Shoot();
                }
            }
            else if (navAgent.pathGenerated.Count > 0)
            {
                Moveable.IsCrouching = false;
                Moveable.LookAt(navAgent.pathGenerated[0]);
                Moveable.MoveTowards(navAgent.pathGenerated[0], 1);
            }
            else
                Moveable.Stop();
        }
    }
}