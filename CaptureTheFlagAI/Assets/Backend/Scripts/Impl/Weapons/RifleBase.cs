using CaptureTheFlagAI.API.Weapons;
using CaptureTheFlagAI.Impl.Animation;
using CaptureTheFlagAI.Impl.Pool;
using CaptureTheFlagAI.Impl.Soldier;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.Impl.Weapons
{
    public class RifleBase : Weapon
    {
        private AnimatorController animatorController;

        protected WeaponSettings settings;

        private float lastShootTime;

        public RifleBase(SoldierBase owner, WeaponSettings settings)
        {
            animatorController = owner.GetComponent<AnimatorController>();
            Assert.IsNotNull(animatorController, "No AnimatorController is attached to game object " + owner.name);

            this.settings = settings;
        }

        public void Shoot()
        {
            if (!CanShoot())
                return;

            lastShootTime = Time.time;
            animatorController.Shoot();
            PoolManager.Instance.Get(settings.Bullet, settings.Muzzle.position, settings.Muzzle.rotation);
        }

        protected bool CanShoot()
        {
            if ((lastShootTime + settings.CoolDownTime) < Time.time)
                return true;

            return false;
        }
    }
}
