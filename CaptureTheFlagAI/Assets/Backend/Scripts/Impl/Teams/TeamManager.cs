using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.API.Teams;
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
        public Team TeamA { get { return teamA; } }

        private SoldierAITeam teamB;
        public Team TeamB { get { return teamB; } }

        public void CreateTeams()
        {
            teamASettings.spawnPositions.ForEach(s => {
                SoldierBase soldier = SpawnSoldier(teamASettings, s);
                AddSoldierToTeamA(soldier);
                soldier.SoldierDiedEvent += OnSoldierDied;
            });

            teamBSettings.spawnPositions.ForEach(s => {
                SoldierBase soldier = SpawnSoldier(teamBSettings, s);
                AddSoldierToTeamB(soldier);
                soldier.SoldierDiedEvent += OnSoldierDied;
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
            if (teamSettings == teamASettings)
                TeamMaterialChanger.ChangeMaterialToTeamA(spawnPoint.soldierType, go);
            else
                TeamMaterialChanger.ChangeMaterialToTeamB(spawnPoint.soldierType, go);

            return go.GetComponent<SoldierBase>();
        }


        private void AddSoldierToTeamA(SoldierBase soldier)
        {
            if (!soldier)
                return;

            teamA.AddSoldier(soldier.GetComponent<SoldierAIBase>());
            soldier.TeamMemberIndex = teamA.GetTeamMembers().Count;
            soldier.SetTeam(teamA);
            soldier.gameObject.layer = GameManager.Instance.LayerManager.LayerTeamA;
            GameManager.Instance.UIManager.AddSoldierToTeamA(soldier);
        }

        private void AddSoldierToTeamB(SoldierBase soldier)
        {
            if (!soldier)
                return;

            teamB.AddSoldier(soldier.GetComponent<SoldierAIBase>());
            soldier.TeamMemberIndex = teamB.GetTeamMembers().Count;
            soldier.SetTeam(teamB);
            soldier.gameObject.layer = GameManager.Instance.LayerManager.LayerTeamB;
            GameManager.Instance.UIManager.AddSoldierToTeamB(soldier);
        }

        private void OnSoldierDied(SoldierBase soldier)
        {
            if (soldier.GetTeam().TeamType == TeamTypes.TeamA)
                teamA.RemoveSoldier(soldier.GetComponent<SoldierAIBase>());
            else
                teamB.RemoveSoldier(soldier.GetComponent<SoldierAIBase>());

            Debug.Log("Removed Soldier from team");
        }

        #region MonoBeahviour

        void Awake()
        {
            teamA = new SoldierAITeam(TeamTypes.TeamA, "Team A");
            teamB = new SoldierAITeam(TeamTypes.TeamB, "Team B");
        }

        void OnDrawGizmos()
        {
            Color orgColor = Gizmos.color;

            Gizmos.color = Color.blue;
            teamASettings.spawnPositions.ForEach(s => Gizmos.DrawWireCube(s.position, new Vector3(1, 0.1f, 1)));

            Gizmos.color = Color.yellow;
            teamBSettings.spawnPositions.ForEach(s => Gizmos.DrawWireCube(s.position, new Vector3(1, 0.1f, 1)));

            Gizmos.color = orgColor;
        }

        #endregion
    }
}