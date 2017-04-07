using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.API.Weapons;
using CaptureTheFlagAI.Impl.Locomotion;
using CaptureTheFlagAI.Impl.Weapons;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.Impl.Soldier
{
    public abstract class SoldierBase : MonoBehaviour
    {
        /// <summary>
        /// Max move speed of the soldier
        /// </summary>
        [SerializeField]
        protected float maxMoveSpeed;

        [SerializeField]
        protected float maxRotationalSpeed;

        [SerializeField]
        protected WeaponSettings weaponSettings;

        [SerializeField]
        protected SoldierSettings soldierSettings;

        protected Moveable moveable;
        public Moveable GetMoveable() { return moveable; }

        protected Weapon weapon;
        public Weapon GetWeapon() { return weapon; }

        protected Statistics statistics;
        public Statistics GetStatistics() { return soldierSettings; }

        protected SoldierTypes soldierType;

        public void Initialize()
        {
            Assert.IsNotNull(weaponSettings, "The WeaponSettings field isn't set for soldier " + gameObject.name);
            Assert.IsNotNull(soldierSettings, "The SoldierSettings field isn't set for soldier " + gameObject.name);

            InitializeInternal();
            CreateMoveable();
            CreateWeapon();
        }

        protected abstract void InitializeInternal();

        protected virtual void CreateMoveable()
        {
            moveable = new MoveableBase(gameObject, maxMoveSpeed, maxRotationalSpeed);
        }

        protected virtual void CreateWeapon()
        {
            weapon = new AssaultRifle(this, weaponSettings);
        }
    }
}