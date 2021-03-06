﻿
using UnityEngine;

namespace CaptureTheFlagAI.API.Locomotion
{
    /// <summary>
    /// Gives access to methods for a moveable object
    /// </summary>
    public interface Moveable 
    {
        /// <summary>
        /// Returns the current position of the object
        /// </summary>
        /// <returns></returns>
        Vector3 GetPosition();

        /// <summary>
        /// Returns the forward direction of the object
        /// </summary>
        /// <returns></returns>
        Vector3 GetForwardVector();

        /// <summary>
        /// Returns the current move vector of the object (magnitude is 1 or 0)
        /// </summary>
        /// <returns></returns>
        Vector3 GetMoveVector();

        /// <summary>
        /// Returns the Rotation of the object
        /// </summary>
        /// <returns></returns>
        Quaternion GetRotation();

        /// <summary>
        /// Moves the object towards the destination. 
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="speed">How fast the object shall move. 1 means max speed</param>
        void MoveTowards(Vector3 destination, float speed);

        /// <summary>
        /// Moves the object in given direction
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed">How fast the object shall move. 1 means max speed</param>
        void MoveDirection(Vector3 direction, float speed);

        /// <summary>
        /// Rotates the object toward the given position
        /// </summary>
        /// <param name="position"></param>
        bool LookAt(Vector3 position);

        /// <summary>
        /// Stops the movement
        /// </summary>
        void Stop();

        /// <summary>
        /// Lets the soldier crouch or stand up
        /// </summary>
        bool IsCrouching { get; set; }

        /// <summary>
        /// Disables the moveable for the given time. 
        /// </summary>
        void DisableForTimeSpan(float seconds);

        /// <summary>
        /// Disables the moveable permanently
        /// </summary>
        void DisablePermanently();
    }
}
