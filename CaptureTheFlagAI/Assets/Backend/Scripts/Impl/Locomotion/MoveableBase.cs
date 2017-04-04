using UnityEngine;
using CaptureTheFlagAI.API.Locomotion;

namespace CaptureTheFlagAI.Impl.Locomotion
{
    public class MoveableBase : Moveable
    {
        protected float maxMoveSpeed;

        protected float maxRotationalSpeed;

        protected Rigidbody rigidbody;
        protected Transform transform;

        protected Vector3 moveVector;

        #region Moveable

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public Vector3 GetMoveVector()
        {
            return moveVector;
        }
    
        public void MoveTowards(Vector3 destination, float speed)
        {
            MoveDirection(destination - transform.position, speed);
        }

        public void MoveDirection(Vector3 direction, float speed)
        {
            speed = Mathf.Clamp01(speed);
            moveVector = Vector3.Normalize(direction) * speed;
            rigidbody.velocity = moveVector * maxMoveSpeed;
        }

        public void Stop()
        {
            MoveDirection(Vector3.forward, 0);
        }

        #endregion

        #region Constructor

        public MoveableBase(GameObject gameObject, float maxMoveSpeed, float maxRotationalSpeed)
        {
            this.maxMoveSpeed = maxMoveSpeed;
            this.maxRotationalSpeed = maxRotationalSpeed;

            transform = gameObject.transform;

            rigidbody = gameObject.GetComponent<Rigidbody>();
            UnityEngine.Assertions.Assert.IsNotNull(rigidbody, "No Rigidbody component is attached to gameobject " + gameObject.name);
        }

        #endregion
    }
}