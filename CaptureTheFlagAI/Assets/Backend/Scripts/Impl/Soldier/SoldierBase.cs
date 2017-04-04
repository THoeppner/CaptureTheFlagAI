using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.Impl.Locomotion;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.Impl.Soldier
{
    public abstract class SoldierBase : MonoBehaviour
    {
        [SerializeField]
        protected float maxMoveSpeed;

        [SerializeField]
        protected float maxRotationalSpeed;

        protected Moveable moveable;
        public Moveable GetMoveable()
        {
            return moveable;
        }

        void Awake()
        {
            moveable = new MoveableBase(gameObject, maxMoveSpeed, maxRotationalSpeed);

            AwakeInternal();
        }

        protected virtual void AwakeInternal() { }
    }
}