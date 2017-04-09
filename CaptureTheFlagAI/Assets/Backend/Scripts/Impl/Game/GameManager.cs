using CaptureTheFlagAI.Impl.Pool;
using CaptureTheFlagAI.Impl.Teams;
using CaptureTheFlagAI.Impl.UI;
using System.Collections;
using System.Collections.Generic;
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
        TeamManagerImpl teamManager;
        public TeamManagerImpl TeamManager { get { return teamManager; } }

        [SerializeField]
        UIManager uiManager;
        public UIManager UIManager { get { return uiManager; } }

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            teamManager.CreateTeams();
        }
    }
}