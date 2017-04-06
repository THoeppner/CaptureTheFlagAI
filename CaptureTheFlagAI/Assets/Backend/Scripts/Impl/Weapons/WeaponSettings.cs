using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Weapons
{
    public class WeaponSettings : MonoBehaviour
    {
        [SerializeField]
        private float coolDownTime;
        public float CoolDownTime { get { return coolDownTime; } }

        [SerializeField]
        GameObject bullet;
        public GameObject Bullet { get { return bullet; } }

        [SerializeField]
        Transform muzzle;
        public Transform Muzzle { get { return muzzle; } }
    }
}