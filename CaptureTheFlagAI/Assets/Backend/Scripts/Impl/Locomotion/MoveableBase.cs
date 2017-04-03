using UnityEngine;
using CaptureTheFlagAI.API.Locomotion;

namespace CaptureTheFlagAI.Impl.Locomotion
{
    public class MoveableBase : MonoBehaviour, Moveable
    {
        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private float rotationalSpeed;

        protected new Rigidbody rigidbody;
        protected new Transform transform;

        #region Moveable

        public void MoveTo(Vector3 destination, float speed)
        {
            MoveDirection(destination - transform.position, speed);
        }

        public void MoveDirection(Vector3 direction, float speed)
        {
            direction = Vector3.Normalize(direction);
            direction *= moveSpeed * speed;

//            Debug.Log("MoveDirection: " + direction);

//            rigidbody.velocity = new Vector3(Mathf.Clamp(rigidbody.velocity.x, -speed, speed), rigidbody.velocity.y, Mathf.Clamp(rigidbody.velocity.z, -speed, speed));
            rigidbody.velocity = Vector3.ClampMagnitude(direction, moveSpeed);
        }

        #endregion

        #region MonoBehaviour

        void Awake()
        {
            transform = GetComponent<Transform>();

            rigidbody = GetComponent<Rigidbody>();
            UnityEngine.Assertions.Assert.IsNotNull(rigidbody, "No Rigidbody component is attached to gameobject " + gameObject.name);
        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion
    }
}