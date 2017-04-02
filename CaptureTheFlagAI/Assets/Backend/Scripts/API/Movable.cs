
using UnityEngine;

namespace CaptureTheFlagAI.API
{
    /// <summary>
    /// Gives access to methods for a movable object
    /// </summary>
    public interface Movable 
    {


        /// <summary>
        /// Moves the object to destination with walk speed
        /// </summary>
        /// <param name="destination"></param>
        void WalkTo(Vector3 destination);

        /// <summary>
        /// Moves the object to destination with run speed
        /// </summary>
        /// <param name="destination"></param>
        void RunTo(Vector3 destination);

    }
}