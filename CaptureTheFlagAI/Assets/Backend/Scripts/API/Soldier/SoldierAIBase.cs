using CaptureTheFlagAI.API.Interaction;
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

            // Register the event handler
            soldier.SoldierDiedEvent += OnSoldierDiedInternal;
            soldier.SoldierHitEvent += OnSoldierHit;

            AwakeInternal();
        }

        protected virtual void AwakeInternal() { }

        #endregion

        #region Events

        /// <summary>
        /// This is an internal wrapper to hide the SoldierBase object
        /// </summary>
        /// <param name="soldier"></param>
        private void OnSoldierDiedInternal(SoldierBase soldier)
        {
            OnSoldierDied();
        }

        /// <summary>
        /// This method is called when the soldier died
        /// </summary>
        protected virtual void OnSoldierDied() { }

        /// <summary>
        /// Is called when the soldier is hit
        /// </summary>
        /// <param name="hitInformation"></param>
        protected virtual void OnSoldierHit(HitInformation hitInformation) { }

        #endregion
    }
}
