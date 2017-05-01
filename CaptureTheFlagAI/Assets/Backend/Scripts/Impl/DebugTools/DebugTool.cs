using CaptureTheFlagAI.API.Map;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.DebugTools
{

    public class DebugTool : MonoBehaviour
    {
        [SerializeField]
        bool outlineObjectInformation;

        public void DrawObjectInformation(ObjectInformation info)
        {
            if (info.GameObjectId == -1)
                return;

            //Debug.Log("Object in LOS: " + infoBlockingObj.Name + "; " + infoBlockingObj.Center);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(info.Center, info.Size);
        }
    }
}