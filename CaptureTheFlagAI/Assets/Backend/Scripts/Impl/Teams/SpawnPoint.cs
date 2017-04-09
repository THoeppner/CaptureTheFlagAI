using CaptureTheFlagAI.API.Soldier;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Teams
{
    [Serializable]
    public class SpawnPoint 
    {
        public Vector3 position;
        public SoldierTypes soldierType;
    }
}