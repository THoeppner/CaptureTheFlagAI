using System;
using CaptureTheFlagAI.API.Soldier;
using UnityEngine;
using UnityEngine.Assertions;
using CaptureTheFlagAI.API.Locomotion;

namespace CaptureTheFlagAI.Impl.Soldier
{
    public class SoldierAnatomy : MonoBehaviour, Anatomy
    {
        /// <summary>
        /// Is used for the visual sense
        /// </summary>
        [SerializeField]
        private Transform head;

        [SerializeField]
        private Transform headCrouching;

        public Moveable Moveable { get; set; }

        #region Anatomy

        public Vector3 GetHeadPosition()
        {
            if (Moveable.IsCrouching)
                return headCrouching.position;
            else
                return head.position;
        }

        #endregion

        #region MonoBehaviour

        void Awake()
        {
            Assert.IsNotNull(head, "The head field isn't set for SoldierAnatomy " + gameObject.name);
            Assert.IsNotNull(headCrouching, "The headCrouching field isn't set for SoldierAnatomy " + gameObject.name);
        }

        #endregion
    }
}