using UnityEngine;

namespace CaptureTheFlagAI.Impl.Game
{

    public class LayerManager : MonoBehaviour
    {
        [SerializeField]
        string layerNameTeamA;

        [SerializeField]
        string layerNameTeamB;

        [SerializeField]
        string layerNameObstacles;

        public int LayerTeamA { get; private set; }
        public int LayerTeamB { get; private set; }
        public int LayerObstacles { get; private set; }

        public LayerMask LayerMaskWeaponHitTest { get; private set; }

        public void Initialize()
        {
            LayerTeamA = LayerMask.NameToLayer(layerNameTeamA);
            LayerTeamB = LayerMask.NameToLayer(layerNameTeamB);
            LayerObstacles = LayerMask.NameToLayer(layerNameObstacles);

            LayerMaskWeaponHitTest = LayerMask.GetMask(layerNameTeamA, layerNameTeamB, layerNameObstacles);
        }
    }
}