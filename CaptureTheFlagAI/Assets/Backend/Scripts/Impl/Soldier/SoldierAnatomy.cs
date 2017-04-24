using System;
using CaptureTheFlagAI.API.Soldier;
using UnityEngine;
using UnityEngine.Assertions;

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
        private Transform breast;

        #region Anatomy

        public Vector3 GetHeadPosition()
        {
            return head.position;
        }

        public Vector3 GetBreastPosition()
        {
            return breast.position;
        }

        #endregion

        #region MonoBehaviour

        void Awake()
        {
            Assert.IsNotNull(head, "The head field isn't set for SoldierAnatomy " + gameObject.name);
            Assert.IsNotNull(breast, "The breast field isn't set for SoldierAnatomy " + gameObject.name);
        }

        #endregion
    }
}