using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.API.Senses;
using CaptureTheFlagAI.API.Teams;
using CaptureTheFlagAI.API.Weapons;
using CaptureTheFlagAI.Impl.Soldier;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.API.Soldier
{
    /// <summary>
    /// The base class for all soldier bots
    /// </summary>
    public class SoldierAIBase : MonoBehaviour
    {
        private SoldierBase soldier;

        public Moveable Moveable
        {
            get { return soldier.GetMoveable(); }
        }

        public Weapon CurrentWeapon
        {
            get { return soldier.GetWeapon(); }
        }

        public Statistics Statistics
        {
            get { return soldier.GetStatistics(); }
        }

        public Anatomy Anatomy
        {
            get { return soldier.GetAnatomy(); }
        }

        public Team Team
        {
            get { return soldier.GetTeam(); }
        }

        public VisualSense VisualSense
        {
            get { return soldier.GetVisualSense(); }
        }

        public SoldierTypes SoldierType
        {
            get { return soldier.GetSoldierType(); }
        }

        public int TeamMemberIndex
        {
            get { return soldier.TeamMemberIndex; }
        }

        #region MonoBehaviour

        void Awake()
        {
            soldier = GetComponent<SoldierBase>();
            Assert.IsNotNull(soldier, "No SoldierBase component is attached to gameobject " + gameObject.name);
            soldier.Initialize();

            AwakeInternal();
        }

        protected virtual void AwakeInternal() { }

        #endregion
    }
}
