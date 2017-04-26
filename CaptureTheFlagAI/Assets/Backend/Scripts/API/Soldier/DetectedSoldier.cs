using CaptureTheFlagAI.API.Teams;
using UnityEngine;

namespace CaptureTheFlagAI.API.Soldier
{
    public struct DetectedSoldier
    {
        /// <summary>
        /// The Id of the gameobject of the soldier
        /// </summary>         
        public int Id;

        /// <summary>
        /// The position of the detected sodier
        /// </summary>
        public Vector3 Position;

        /// <summary>
        /// The rotation of the detected soldier
        /// </summary>
        public Quaternion Rotation;

        /// <summary>
        /// Type of the soldier
        /// </summary>
        public SoldierTypes SoldierType;

        /// <summary>
        /// The team the soldier belongs to
        /// </summary>
        public TeamTypes Team;
    }
}
