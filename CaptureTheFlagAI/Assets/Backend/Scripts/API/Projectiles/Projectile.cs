

using UnityEngine;

namespace CaptureTheFlagAI.API.Projectiles
{
    public interface Projectile 
    {
        /// <summary>
        /// Position, where the projetile was fired
        /// </summary>
        Vector3 SourcePosition { get; set; }
    }
}