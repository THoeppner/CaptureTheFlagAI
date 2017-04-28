using CaptureTheFlagAI.API.Map;
using CaptureTheFlagAI.Impl.Map;
using CaptureTheFlagAI.Impl.Pool;
using CaptureTheFlagAI.Impl.Teams;
using CaptureTheFlagAI.Impl.UI;
using UnityEngine;
using UnityEngine.Assertions;

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

        [SerializeField]
        SimpleMapManager mapManager;
        public MapManager MapManager { get { return mapManager; } }

        void Awake()
        {
            Instance = this;

            Assert.IsNotNull(poolManager, "The field PoolManager isn't set for GameManager " + gameObject.name);
            Assert.IsNotNull(teamManager, "The field TeamManager isn't set for GameManager " + gameObject.name);
            Assert.IsNotNull(uiManager, "The field UIManager isn't set for GameManager " + gameObject.name);
            Assert.IsNotNull(layerManager, "The field LayerManager isn't set for GameManager " + gameObject.name);
            Assert.IsNotNull(mapManager, "The field SimpleMapManager isn't set for GameManager " + gameObject.name);
        }

        void Start()
        {
            layerManager.Initialize();
            mapManager.Initialize();
            teamManager.CreateTeams();
        }
    }
}