using CaptureTheFlagAI.Impl.Pool;
using CaptureTheFlagAI.Impl.Teams;
using CaptureTheFlagAI.Impl.UI;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Game
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField]
        PoolManager poolManager;
        public PoolManager PoolManager { get { return poolManager; } }

        [SerializeField]
        TeamManager teamManager;
        public TeamManager TeamManager { get { return teamManager; } }

        [SerializeField]
        UIManager uiManager;
        public UIManager UIManager { get { return uiManager; } }

        [SerializeField]
        LayerManager layerManager;
        public LayerManager LayerManager { get { return layerManager; } }

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            layerManager.Initialize();
            teamManager.CreateTeams();
        }
    }
}