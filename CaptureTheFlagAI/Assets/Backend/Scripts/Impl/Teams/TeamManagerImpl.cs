using CaptureTheFlagAI.API.Teams;
using CaptureTheFlagAI.Impl.Game;
using CaptureTheFlagAI.Impl.Soldier;
using CaptureTheFlagAI.Impl.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Teams
{

    public class TeamManagerImpl : MonoBehaviour, TeamManager
    {
        List<SoldierBase> teamA = new List<SoldierBase>();
        List<SoldierBase> teamB = new List<SoldierBase>();

        public int AddSoldierToTeamA(SoldierBase soldier)
        {
            teamA.Add(soldier);

            GameManager.Instance.UIManager.AddSoldierToTeamA(soldier);

            return teamA.Count;
        }

        public int AddSoldierToTeamB(SoldierBase soldier)
        {
            teamB.Add(soldier);

            GameManager.Instance.UIManager.AddSoldierToTeamB(soldier);

            return teamB.Count;
        }

        #region MonoBeahviour

        void Awake()
        {
        }

        #endregion
    }
}