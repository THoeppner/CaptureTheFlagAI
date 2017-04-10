﻿using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.Impl.Game;
using CaptureTheFlagAI.Impl.Soldier;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Teams
{

    public class TeamManager : MonoBehaviour
    {
        [SerializeField]
        private TeamSettings teamASettings;

        [SerializeField]
        private TeamSettings teamBSettings;

        private SoldierAITeam teamA;
        private SoldierAITeam teamB;

        public void CreateTeams()
        {
            teamASettings.spawnPositions.ForEach(s => {
                SoldierBase soldier = SpawnSoldier(teamASettings, s);
                AddSoldierToTeamA(soldier);
            });

            teamBSettings.spawnPositions.ForEach(s => {
                SoldierBase soldier = SpawnSoldier(teamBSettings, s);
                AddSoldierToTeamB(soldier);
            });
        }

        private SoldierBase SpawnSoldier(TeamSettings teamSettings, SpawnPoint spawnPoint)
        {
            GameObject prefab = null;

            switch (spawnPoint.soldierType)
            {
                case SoldierTypes.Sniper: prefab = teamSettings.sniperPrefab; break;
                case SoldierTypes.Infantry: prefab = teamSettings.infantryPrefab; break;
                case SoldierTypes.Scout: prefab = teamSettings.scoutPrefab; break;
                case SoldierTypes.Gunner: prefab = teamSettings.gunnerPrefab; break;
            }

            if (!prefab)
                return null;

            GameObject go = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            // TODO: teamA or teamB
            TeamMaterialChanger.ChangeMaterial(spawnPoint.soldierType, false, go);
            return go.GetComponent<SoldierBase>();
        }


        private void AddSoldierToTeamA(SoldierBase soldier)
        {
            if (!soldier)
                return;

            teamA.AddSoldier(soldier.GetComponent<SoldierAIBase>());
            soldier.SetTeam(teamA);
            GameManager.Instance.UIManager.AddSoldierToTeamA(soldier);
        }

        private void AddSoldierToTeamB(SoldierBase soldier)
        {
            if (!soldier)
                return;

            teamB.AddSoldier(soldier.GetComponent<SoldierAIBase>());
            soldier.SetTeam(teamB);
            GameManager.Instance.UIManager.AddSoldierToTeamB(soldier);
        }

        #region MonoBeahviour

        void Awake()
        {
            teamA = new SoldierAITeam();
            teamA.Name = "Team A";
            teamB = new SoldierAITeam();
            teamB.Name = "Team B";
        }

        void OnDrawGizmos()
        {
            Color orgColor = Gizmos.color;

            Gizmos.color = Color.red;
            teamASettings.spawnPositions.ForEach(s => Gizmos.DrawWireCube(s.position, new Vector3(1, 0.1f, 1)));

            Gizmos.color = Color.blue;
            teamBSettings.spawnPositions.ForEach(s => Gizmos.DrawWireCube(s.position, new Vector3(1, 0.1f, 1)));

            Gizmos.color = orgColor;
        }

        #endregion
    }
}