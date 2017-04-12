using CaptureTheFlagAI.API.Interaction;
using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.API.Weapons;
using CaptureTheFlagAI.Impl.Locomotion;
using CaptureTheFlagAI.Impl.Weapons;
using UnityEngine;
using UnityEngine.Assertions;
using CaptureTheFlagAI.Impl.Animation;
using CaptureTheFlagAI.API.Teams;

namespace CaptureTheFlagAI.Impl.Soldier
{
    public abstract class SoldierBase : MonoBehaviour, Hitable
    {
        [SerializeField]
        protected WeaponSettings weaponSettings;

        [SerializeField]
        protected SoldierSettings soldierSettings;

        protected Moveable moveable;
        public Moveable GetMoveable() { return moveable; }

        protected Weapon weapon;
        public Weapon GetWeapon() { return weapon; }

        protected Team team;
        public Team GetTeam() { return team; }
        public void SetTeam(Team team) { this.team = team; }

        public Statistics GetStatistics() { return soldierSettings; }

        protected SoldierTypes soldierType;
        public SoldierTypes GetSoldierType() { return soldierType; }

        private AnimatorController animatorController;

        public void Initialize()
        {
            Assert.IsNotNull(weaponSettings, "The WeaponSettings field isn't set for soldier " + gameObject.name);
            Assert.IsNotNull(soldierSettings, "The SoldierSettings field isn't set for soldier " + gameObject.name);

            animatorController = GetComponent<AnimatorController>();
            Assert.IsNotNull(animatorController, "No AnimatorController is attached to game object " + gameObject.name);

            InitializeInternal();

            CreateMoveable();
            CreateWeapon();
        }

        protected abstract void InitializeInternal();

        protected virtual void CreateMoveable()
        {
            moveable = new MoveableBase(gameObject, soldierSettings.MaxMoveSpeed, soldierSettings.MaxRotationalSpeed);
        }

        protected virtual void CreateWeapon()
        {
            weapon = new AssaultRifle(this, weaponSettings);
        }

        protected void Die()
        {
            moveable.DisablePermanently();
            weapon.DisablePermanently();
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }

        #region Hitable

        public void Hit(int damage)
        {
            animatorController.Hit();
            soldierSettings.Health -= damage;

            if (soldierSettings.IsDead)
                Die();
        }

        #endregion
    }
}