using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.Impl.Soldier;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.API.Soldier
{
    public class SoldierAIBase : MonoBehaviour
    {
        private SoldierBase soldier;

        // Use this for initialization
        void Awake()
        {
            soldier = GetComponent<SoldierBase>();
            Assert.IsNotNull(soldier, "No SoldierBase component is attached to gameobject " + gameObject.name);
        }

        public Moveable Moveable
        {
            get { return soldier.GetMoveable(); }
        }
    }
}
