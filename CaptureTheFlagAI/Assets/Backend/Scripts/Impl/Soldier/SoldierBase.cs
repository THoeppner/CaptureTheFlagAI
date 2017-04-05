using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.Impl.Locomotion;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.Impl.Soldier
{
    public abstract class SoldierBase : MonoBehaviour
    {
        /// <summary>
        /// Max move speed of the soldier
        /// </summary>
        [SerializeField]
        protected float maxMoveSpeed;

        [SerializeField]
        protected float maxRotationalSpeed;

        protected Moveable moveable;
        public Moveable GetMoveable() { return moveable; }

        protected SoldierTypes soldierType;

        public virtual void Initialize()
        {
            moveable = new MoveableBase(gameObject, maxMoveSpeed, maxRotationalSpeed);
        }

    }
}