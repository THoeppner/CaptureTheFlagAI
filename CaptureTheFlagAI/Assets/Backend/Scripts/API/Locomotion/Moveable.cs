
using UnityEngine;

namespace CaptureTheFlagAI.API.Locomotion
{
    /// <summary>
    /// Gives access to methods for a movable object
    /// </summary>
    public interface Moveable 
    {
        /// <summary>
        /// Moves the object to destination. 
        /// </summary>
        /// <param name="destination"></param>
        void MoveTo(Vector3 destination, float speed);

        void MoveDirection(Vector3 direction, float speed);
    }
}