﻿using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.Impl.Soldier;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Animation
{
    public class AnimatorController : MonoBehaviour
    {
        public readonly int VelocityForwardHash = Animator.StringToHash("VelocityForward");
        public readonly int VelocitySidewardHash = Animator.StringToHash("VelocitySideward");
        public readonly int ShootHash = Animator.StringToHash("Shoot");

        [SerializeField]
        private Animator animator;

        private Moveable moveable;

        public void Shoot()
        {
            animator.SetTrigger(ShootHash);
        }

        #region MonoBehaviour

        void Start()
        {
            UnityEngine.Assertions.Assert.IsNotNull(animator, "The animator field is'n set for AnimatorController of gameobject " + gameObject.name);
            moveable = GetComponent<SoldierBase>().GetMoveable();
        }

        void Update()
        {
            Vector3 velocity = transform.InverseTransformDirection(moveable.GetMoveVector());
            animator.SetFloat(VelocityForwardHash, velocity.z);
            animator.SetFloat(VelocitySidewardHash, velocity.x);
        }

        #endregion

    }
}