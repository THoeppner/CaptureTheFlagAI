
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

        /// <summary>
        /// Checks, if a hit is possible
        /// </summary>
        /// <param name="soldierId"></param>
        /// <returns></returns>
        bool IsHitPossible(int soldierId);
    }
}
