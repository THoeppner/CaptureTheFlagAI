using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.API.Weapons;
using CaptureTheFlagAI.Impl.Animation;
using CaptureTheFlagAI.Impl.Game;
using CaptureTheFlagAI.Impl.Soldier;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.Impl.Weapons
{
    public class RifleBase : Weapon
    {
        private AnimatorController animatorController;

        protected Moveable moveable;

        protected WeaponSettings settings;

        private float lastShootTime;

        private bool isDisabledPermanently;

        public RifleBase(SoldierBase owner, WeaponSettings settings)
        {
            moveable = owner.GetMoveable();
            animatorController = owner.GetComponent<AnimatorController>();
            Assert.IsNotNull(animatorController, "No AnimatorController is attached to game object " + owner.name);

            this.settings = settings;
        }

        public void DisablePermanently()
        {
            isDisabledPermanently = true;
        }

        public void Shoot()
        {
            if (!CanShoot())
                return;

            moveable.DisableForTimeSpan(settings.ShotTimeSpan);
            lastShootTime = Time.time;
            animatorController.Shoot();
            GameManager.Instance.PoolManager.Get(settings.Bullet, settings.Muzzle.position, settings.Muzzle.rotation);
        }

        protected bool CanShoot()
        {
            if (isDisabledPermanently || ((lastShootTime + settings.CoolDownTime) > Time.time))
                return false;
            return true;
        }
    }
}
