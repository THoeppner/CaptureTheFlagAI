using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.Impl.Locomotion;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.Impl.Soldier
{

    public abstract class SoldierBase : MonoBehaviour
    {
        protected Moveable moveable;
        public Moveable GetMoveable()
        {
            return moveable;
        }

        void Awake()
        {
            moveable = GetComponent<MoveableBase>() as Moveable;
            Assert.IsNotNull(moveable, "No Moveable component is attached to gameobject " + gameObject.name);

            AwakeInternal();
        }

        protected virtual void AwakeInternal() { }
    }
}