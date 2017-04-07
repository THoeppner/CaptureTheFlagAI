using System;
using CaptureTheFlagAI.API.Soldier;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Soldier
{
    public class SoldierSettings : MonoBehaviour, Statistics
    {
        [SerializeField]
        private int maxHealth;

        private int currentHealth;

        public int Health
        {
            get { return currentHealth; }
            set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        void Awake()
        {
            currentHealth = maxHealth;
        }

    }
}