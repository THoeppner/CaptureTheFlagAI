
using UnityEngine;

namespace CaptureTheFlagAI.API.Weapons
{
    /// <summary>
    /// Gives access to the weapon of the soldier
    /// </summary>
    public interface Weapon
    {
        /// <summary>
        /// Shoots the weapon
        /// </summary>
        void Shoot();

        /// <summary>
        /// Disables the weapon permanently
        /// </summary>
        void DisablePermanently();
    }
}
