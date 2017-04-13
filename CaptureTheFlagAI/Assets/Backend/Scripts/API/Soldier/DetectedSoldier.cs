using CaptureTheFlagAI.API.Teams;
using UnityEngine;

namespace CaptureTheFlagAI.API.Soldier
{
    public struct DetectedSoldier
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public SoldierTypes SoldierType;
        public TeamTypes Team;
    }
}
