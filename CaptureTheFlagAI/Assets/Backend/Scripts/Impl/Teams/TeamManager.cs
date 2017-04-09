using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.API.Teams;
using CaptureTheFlagAI.Impl.Game;
using CaptureTheFlagAI.Impl.Soldier;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Teams
{

    public class TeamManager : MonoBehaviour
    {
        [SerializeField]
        TeamSettings teamASettings;

        [SerializeField]
        TeamSettings teamBSettings;

        List<SoldierBase> teamA = new List<SoldierBase>();
        List<SoldierBase> teamB = new List<SoldierBase>();

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

            return Instantiate(prefab, spawnPoint.position, Quaternion.identity).GetComponent<SoldierBase>();
        }


        private void AddSoldierToTeamA(SoldierBase soldier)
        {
            if (!soldier)
                return;

            teamA.Add(soldier);
            GameManager.Instance.UIManager.AddSoldierToTeamA(soldier);
        }

        private void AddSoldierToTeamB(SoldierBase soldier)
        {
            if (!soldier)
                return;

            teamB.Add(soldier);
            GameManager.Instance.UIManager.AddSoldierToTeamB(soldier);
        }

        #region MonoBeahviour

        void Awake()
        {
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