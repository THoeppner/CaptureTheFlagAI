using CaptureTheFlagAI.API.Soldier;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaptureTheFlagAI.API.Interaction;

namespace CaptureTheFlagAI.Samples
{
    public class InfantryAISample : SoldierAIBase
    {
        bool hit;
        Vector3 hitPosition;

        protected override void OnSoldierDied()
        {
            Debug.Log("I'm dying");
        }

        protected override void OnSoldierHit(HitInformation hitInformation)
        {
            hitPosition = hitInformation.PositionSource;
            hit = true;
        }

        private void Update()
        {
            if (hit)
                Moveable.LookAt(hitPosition);
        }
    }
}