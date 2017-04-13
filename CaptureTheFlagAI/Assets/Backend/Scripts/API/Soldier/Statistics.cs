

namespace CaptureTheFlagAI.API.Soldier
{
    /// <summary>
    /// Provides informaton about the soldier
    /// </summary>
    public interface Statistics 
    {
        /// <summary>
        /// Max movement speed 
        /// </summary>
        float MaxMoveSpeed { get; }

        /// <summary>
        /// Max rotational speed 
        /// </summary>
        float MaxRotationalSpeed { get; }

        /// <summary>
        /// The max health
        /// </summary>
        int MaxHealth { get; }

        /// <summary>
        /// The current health
        /// </summary>
        int Health { get; }

        /// <summary>
        /// Returns true if the soldier is dead
        /// </summary>
        bool IsDead { get; }

        /// <summary>
        /// Angle of the view
        /// </summary>
        float ViewAngle { get; }

        /// <summary>
        /// How far the soldier can see
        /// </summary>
        float ViewDistance { get; }
    }
}
