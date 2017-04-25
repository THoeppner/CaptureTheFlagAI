using System;
using CaptureTheFlagAI.API.Soldier;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Soldier
{
    public class SoldierSettings : MonoBehaviour, Statistics
    {
        [SerializeField]
        private float maxMoveSpeed;

        [SerializeField]
        private float maxRotationalSpeed;

        [SerializeField]
        private int maxHealth;

        [SerializeField]
        private float viewAngle;

        [SerializeField]
        private float viewDistance;

        private int health;

        #region Statistics

        public float MaxMoveSpeed { get { return maxMoveSpeed; } }

        public float MaxRotationalSpeed { get { return maxRotationalSpeed; } }

        public int MaxHealth { get { return maxHealth; } }

        public int Health
        {
            get { return health; }
            set { health = Mathf.Clamp(value, 0, maxHealth); }
        }

        public bool IsDead { get { return Health <= 0; } }

        public float ViewAngle { get { return viewAngle; } }

        public float ViewDistance { get { return viewDistance; } }

        #endregion

        #region MonoBehaviour

        void Awake()
        {
            health = maxHealth;
        }

        #endregion
    }
}