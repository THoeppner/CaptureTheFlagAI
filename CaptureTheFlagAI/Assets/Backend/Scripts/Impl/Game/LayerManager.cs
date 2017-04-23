using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Game
{

    public class LayerManager : MonoBehaviour
    {
        [SerializeField]
        string layerNameTeamA;

        [SerializeField]
        string layerNameTeamB;

        private int layerTeamA;
        public int LayerTeamA { get { return layerTeamA; } }

        private int layerTeamB;
        public int LayerTeamB { get { return layerTeamB; } }

        public void Initialize()
        {
            layerTeamA = LayerMask.NameToLayer(layerNameTeamA);
            layerTeamB = LayerMask.NameToLayer(layerNameTeamB);
        }
    }
}