﻿using CaptureTheFlagAI.API.Senses;
using CaptureTheFlagAI.API.Soldier;
using System.Collections.Generic;
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

            return soldiers;
        }

        #endregion
    }
}