using CaptureTheFlagAI.API.Soldier;
using UnityEngine;

namespace CaptureTheFlagAI.Impl
{

    public class AnimatorController : MonoBehaviour
    {
        public readonly int VelocityForwardHash = Animator.StringToHash("VelocityForward");
        public readonly int VelocitySidewardHash = Animator.StringToHash("VelocitySideward");

        [SerializeField]
        private Animator animator;

        private SoldierWrapper soldier;

        // Use this for initialization
        void Start()
        {
            UnityEngine.Assertions.Assert.IsNotNull(animator, "The animator field is'n set for AnimatorController of gameobject " + gameObject.name);

            soldier = GetComponent<SoldierWrapper>();
            UnityEngine.Assertions.Assert.IsNotNull(soldier, "No SoldierWrapper component is attached to gameobject " + gameObject.name);
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 velocity = transform.InverseTransformDirection(soldier.GetMoveable().GetMoveVector());
            animator.SetFloat(VelocityForwardHash, velocity.z);
            animator.SetFloat(VelocitySidewardHash, velocity.x);
        }
    }
}