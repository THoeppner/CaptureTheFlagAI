using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.Impl
{

    public class AnimatorController : MonoBehaviour
    {
        public readonly int VelocityForwardHash = Animator.StringToHash("VelocityForward");
        public readonly int VelocitySidewardHash = Animator.StringToHash("VelocitySideward");

        [SerializeField]
        private Animator animator;

        private new Rigidbody rigidbody;

        // Use this for initialization
        void Start()
        {
            UnityEngine.Assertions.Assert.IsNotNull(animator, "The animator field is'n set for AnimatorController of gameobject " + gameObject.name);

            rigidbody = GetComponent<Rigidbody>();
            UnityEngine.Assertions.Assert.IsNotNull(rigidbody, "No Rigidbody component is attached to gameobject " + gameObject.name);
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 velocity = transform.InverseTransformDirection(rigidbody.velocity);
            animator.SetFloat(VelocityForwardHash, velocity.z);
            animator.SetFloat(VelocitySidewardHash, velocity.x);
        }
    }
}