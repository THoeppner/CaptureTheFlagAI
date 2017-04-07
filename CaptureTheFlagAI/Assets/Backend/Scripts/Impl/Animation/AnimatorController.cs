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

        [SerializeField]
        private Animator animator;

        private Moveable moveable;
        private Statistics statistics;

        public void Shoot()
        {
            animator.SetTrigger(ShootHash);
        }

        public void Hit()
        {
            animator.SetTrigger(HitHash);
        }

        #region MonoBehaviour

        void Start()
        {
            UnityEngine.Assertions.Assert.IsNotNull(animator, "The animator field is'n set for AnimatorController of gameobject " + gameObject.name);

            SoldierBase soldier = GetComponent<SoldierBase>();
            moveable = soldier.GetMoveable();
            statistics = soldier.GetStatistics();
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