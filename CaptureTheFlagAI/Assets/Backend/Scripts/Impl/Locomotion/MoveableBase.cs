using UnityEngine;
using CaptureTheFlagAI.API.Locomotion;

namespace CaptureTheFlagAI.Impl.Locomotion
{
    public class MoveableBase : MonoBehaviour, Moveable
    {
        [SerializeField]
        protected float maxMoveSpeed;

        [SerializeField]
        protected float maxRotationalSpeed;

        protected new Rigidbody rigidbody;
        protected new Transform transform;

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

        #region MonoBehaviour

        void Awake()
        {
            transform = GetComponent<Transform>();

            rigidbody = GetComponent<Rigidbody>();
            UnityEngine.Assertions.Assert.IsNotNull(rigidbody, "No Rigidbody component is attached to gameobject " + gameObject.name);
        }

        #endregion
    }
}