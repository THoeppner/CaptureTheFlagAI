using UnityEngine;

namespace CaptureTheFlagAI.API.Map
{
    public interface MapManager
    {
        /// <summary>
        /// Initializes the MapManager
        /// </summary>
        void Initialize();

        /// <summary>
        /// Retrieves information about the object with the given id
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        bool GetObjectInformation(int objectId, out ObjectInformation info);
    }
}
