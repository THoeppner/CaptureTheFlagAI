using UnityEngine;

namespace CaptureTheFlagAI.API.Map
{

    public struct ObjectInformation
    {
        public int GameObjectId;
        public string Name;

        public Vector3 Center;

        public Quaternion Rotation;

        // For CapsuleColliders

        // For Box colliders
        public Vector3 Size;
    }
}
