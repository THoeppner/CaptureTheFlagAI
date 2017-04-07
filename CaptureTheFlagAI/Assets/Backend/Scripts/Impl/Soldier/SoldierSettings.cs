using System;
using CaptureTheFlagAI.API.Soldier;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Soldier
{
    public class SoldierSettings : MonoBehaviour, Statistics
    {
        [SerializeField]
        protected int health;

        public int Health { get { return health; } }

    }
}