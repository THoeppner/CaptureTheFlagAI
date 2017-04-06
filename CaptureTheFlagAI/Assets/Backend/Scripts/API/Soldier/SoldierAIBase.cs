using CaptureTheFlagAI.API.Locomotion;
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
