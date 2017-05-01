using CaptureTheFlagAI.API.Map;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.Impl.Map
{

    public class SimpleMapManager : MonoBehaviour, MapManager
    {
        /// <summary>
        /// The parent node for the level
        /// </summary>
        [SerializeField]
        GameObject level;

        Dictionary<int, GameObject> staticObjects = new Dictionary<int, GameObject>();

        #region MapManager

        public void Initialize()
        {
            staticObjects.Clear();
            PutRecursiveStaticChildsToMap(level.transform);
        }

        public bool GetObjectInformation(int objectId, out ObjectInformation info)
        {
            info = new ObjectInformation() { GameObjectId = -1 };

            GameObject go;
            if (!staticObjects.TryGetValue(objectId, out go))
                return false;

            info.GameObjectId = objectId;
            info.Name = go.name;

            Collider c = go.GetComponent<Collider>();
            CapsuleCollider cc = c as CapsuleCollider;
            if (GetInformationFromCapsuleCollider(c as CapsuleCollider, ref info))
                return true;
            else if (GetInformationFromBoxCollider(c as BoxCollider, ref info))
                return true;

            return false;
        }

        #endregion

        #region MonoBehaviour

        private void Awake()
        {
            Assert.IsNotNull(level, "The level field isn't set for SimpleMapManager " + gameObject.name);
        }

        #endregion

        private void PutRecursiveStaticChildsToMap(Transform t)
        {
            foreach (Transform child in t)
            {
                if (child.gameObject.isStatic)
                    staticObjects.Add(child.gameObject.GetInstanceID(), child.gameObject);
                PutRecursiveStaticChildsToMap(child);
            }
        }

        private bool GetInformationFromCapsuleCollider(CapsuleCollider cc, ref ObjectInformation info)
        {
            if (!cc) return false;

            info.Center = cc.center;

            return true;
        }

        private bool GetInformationFromBoxCollider(BoxCollider bc, ref ObjectInformation info)
        {
            if (!bc) return false;

            Transform t = bc.transform;
            info.Center = t.position + bc.center;
            info.Size = new Vector3(bc.size.x * t.localScale.x, bc.size.y * t.localScale.y, bc.size.z * t.localScale.z);
            info.Rotation = t.rotation;

            return true;
        }
    }
}