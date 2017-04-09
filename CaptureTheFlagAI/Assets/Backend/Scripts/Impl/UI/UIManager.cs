using CaptureTheFlagAI.Impl.Soldier;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        Transform healthbarAnchor;

        [SerializeField]
        GameObject healthbarPrefab;

        public void AddSoldierToTeamA(SoldierBase soldier)
        {
            Healthbar healthbar = GameObject.Instantiate(healthbarPrefab).GetComponent<Healthbar>();
            healthbar.transform.SetParent(healthbarAnchor);
            healthbar.Moveable = soldier.GetMoveable();
            healthbar.Statistics = soldier.GetStatistics();
        }

        public void AddSoldierToTeamB(SoldierBase soldier)
        {
            Healthbar healthbar = GameObject.Instantiate(healthbarPrefab).GetComponent<Healthbar>();
            healthbar.transform.SetParent(healthbarAnchor);
            healthbar.Moveable = soldier.GetMoveable();
            healthbar.Statistics = soldier.GetStatistics();
        }

        #region MonoBehaviour

        void Awake()
        {
        }

        #endregion
    }
}