using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Weapons
{
    public class WeaponSettings : MonoBehaviour
    {
        [SerializeField]
        private float shotTimeSpan;
        public float ShotTimeSpan { get { return shotTimeSpan; } }

        [SerializeField]
        private float coolDownTime;
        public float CoolDownTime { get { return coolDownTime; } }

        /// <summary>
        /// Is used for the hit possible check of the wepaon interface
        /// </summary>
        [SerializeField]
        private float bulletRadius;
        public float BulletRadius { get { return bulletRadius; } }

        [SerializeField]
        GameObject bullet;
        public GameObject Bullet { get { return bullet; } }

        [SerializeField]
        Transform muzzle;
        public Transform Muzzle { get { return muzzle; } }
    }
}