using CaptureTheFlagAI.API.Interaction;
using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.Impl.Soldier;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Animation
{
    public class AnimatorController : MonoBehaviour
    {
        public readonly int VelocityForwardHash = Animator.StringToHash("VelocityForward");
        public readonly int VelocitySidewardHash = Animator.StringToHash("VelocitySideward");
        public readonly int ShootHash = Animator.StringToHash("Shoot");
        public readonly int HitHash = Animator.StringToHash("Hit");
        public readonly int HealthHash = Animator.StringToHash("Health");
        public readonly string CrouchingLayerName = "Crouching";

        [SerializeField]
        private Animator animator;

        private Moveable moveable;
        private Statistics statistics;

        private int crouchingLayerIdx;

        public void Shoot()
        {
            animator.SetTrigger(ShootHash);
        }

        public void Crouch()
        {
            animator.SetLayerWeight(crouchingLayerIdx, 1);
        }

        public void StopCrouch()
        {
            animator.SetLayerWeight(crouchingLayerIdx, 0);
        }

        #region Events

        private void OnSoldierHit(HitInformation hitInformation)
        {
            animator.SetTrigger(HitHash);
        }

        #endregion

        #region MonoBehaviour

        void Start()
        {
            UnityEngine.Assertions.Assert.IsNotNull(animator, "The animator field is'n set for AnimatorController of gameobject " + gameObject.name);

            SoldierBase soldier = GetComponent<SoldierBase>();
            moveable = soldier.GetMoveable();
            statistics = soldier.GetStatistics();
            soldier.SoldierHitEvent += OnSoldierHit;

            crouchingLayerIdx = animator.GetLayerIndex(CrouchingLayerName);
        }

        void Update()
        {
            Vector3 velocity = transform.InverseTransformDirection(moveable.GetMoveVector());
            animator.SetFloat(VelocityForwardHash, velocity.z);
            animator.SetFloat(VelocitySidewardHash, velocity.x);

            animator.SetInteger(HealthHash, statistics.Health);
        }

        #endregion
    }
}