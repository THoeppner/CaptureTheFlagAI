using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.API.Projectiles;
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

        #region Weapon

        public int LastHitCheckObjectId { get; protected set; }
        
        public bool IsHitPossible(int soldierId)
        {
            // TODO: Define a correct range for the hit test (like level dimension or shot range)
            Vector3 v1 = settings.Muzzle.position;
            Vector3 v2 = settings.Muzzle.position + settings.Muzzle.forward * 200;
            Debug.DrawLine(v1, v2);

            LastHitCheckObjectId = -1;
            RaycastHit hitInfo;
            if (Physics.SphereCast(settings.Muzzle.position, settings.BulletRadius, settings.Muzzle.forward, out hitInfo, 100f, GameManager.Instance.LayerManager.LayerMaskWeaponHitTest))
                LastHitCheckObjectId = hitInfo.transform.gameObject.GetInstanceID();

            return LastHitCheckObjectId == soldierId;
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
            Projectile p = GameManager.Instance.PoolManager.Get(settings.Bullet, settings.Muzzle.position, settings.Muzzle.rotation).GetComponent<Projectile>();
            if (p != null)
                p.SourcePosition = moveable.GetPosition();
        }

        #endregion

        protected bool CanShoot()
        {
            if (isDisabledPermanently || ((lastShootTime + settings.CoolDownTime) > Time.time))
                return false;
            return true;
        }
    }
}
