

using UnityEngine;

namespace CaptureTheFlagAI.API.Soldier
{
    /// <summary>
    /// Provides informaton about the soldier
    /// </summary>
    public interface Anatomy
    {
        /// <summary>
        /// Delivers the position of the head
        /// </summary>
        /// <returns></returns>
        Vector3 GetHeadPosition();

        /// <summary>
        /// Delivers the position of the breast
        /// </summary>
        /// <returns></returns>
        Vector3 GetBreastPosition();


    }
}
