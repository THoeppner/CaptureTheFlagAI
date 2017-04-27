using UnityEngine;
using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.Impl.Animation;
using System.Timers;
using System;

namespace CaptureTheFlagAI.Impl.Locomotion
{
    public class MoveableBase : Moveable
    {
        protected float maxMoveSpeed;
        protected float maxRotationalSpeed;
        protected Rigidbody rigidbody;
        protected Transform transform;

        protected Vector3 moveVector;

        protected bool isCrouching;

        protected bool isDisabledLimited;
        protected bool isDisabledPermanently;

        protected AnimatorController animatorController;

        #region Constructor

        public MoveableBase(GameObject gameObject, float maxMoveSpeed, float maxRotationalSpeed)
        {
            this.maxMoveSpeed = maxMoveSpeed;
            this.maxRotationalSpeed = maxRotationalSpeed;

            transform = gameObject.transform;

            rigidbody = gameObject.GetComponent<Rigidbody>();
            UnityEngine.Assertions.Assert.IsNotNull(rigidbody, "No Rigidbody component is attached to gameobject " + gameObject.name);
            animatorController = gameObject.GetComponent<AnimatorController>();
            UnityEngine.Assertions.Assert.IsNotNull(animatorController, "No AnimatorController component is attached to gameobject " + gameObject.name);
        }

        #endregion

        #region Moveable

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public Vector3 GetForwardVector()
        {
            return transform.forward;
        }

        public Vector3 GetMoveVector()
        {
            return moveVector;
        }

        public Quaternion GetRotation()
        {
            return transform.rotation;
        }

        public bool LookAt(Vector3 position)
        {
            position.y = transform.position.y;
            Vector3 toPosition = position - transform.position;

            if (!IsDisabled)
            {
                Quaternion lookRotation = Quaternion.LookRotation(toPosition);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, maxRotationalSpeed * Time.deltaTime);
            }

            return Vector3.Angle(transform.forward, toPosition) < 0.1f;
        }

        public void MoveTowards(Vector3 destination, float speed)
        {
            MoveDirection(destination - transform.position, speed);
        }

        public void MoveDirection(Vector3 direction, float speed)
        {
            if (IsDisabled)
                return;

            speed = Mathf.Clamp01(speed);
            moveVector = Vector3.Normalize(direction) * speed;
            rigidbody.velocity = moveVector * maxMoveSpeed * (IsCrouching ? 0.5f : 1);
        }

        public void Stop()
        {
            MoveDirection(Vector3.forward, 0);
        }

        public void DisablePermanently()
        {
            isDisabledPermanently = true;
        }

        public void DisableForTimeSpan(float seconds)
        {
            if (IsDisabled)
                return;

            Stop();
            isDisabledLimited = true;
            CreateEnableTimer(seconds);
        }

        public bool IsCrouching
        {
            get { return isCrouching; }
            set
            {
                if (isCrouching == value || IsDisabled)
                    return;

                isCrouching = value;

                if (isCrouching)
                    animatorController.Crouch();
                else
                    animatorController.StopCrouch();
            }
        }

        public bool IsDisabled { get { return isDisabledLimited || isDisabledPermanently; } }

        #endregion

        private void CreateEnableTimer(float seconds)
        {
            if (seconds == 0)
                return;

            Timer enableTimer = new Timer(seconds * 1000);
            enableTimer.AutoReset = false;
            enableTimer.Elapsed += OnEnableTimerElapsed;
            enableTimer.Start();
        }

        private void OnEnableTimerElapsed(object sender, ElapsedEventArgs e)
        {
            isDisabledLimited = false;
        }
    }
}