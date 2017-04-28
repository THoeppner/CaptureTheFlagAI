using System;
using CaptureTheFlagAI.API.Interaction;
using CaptureTheFlagAI.API.Projectiles;
using CaptureTheFlagAI.Impl.Game;
using CaptureTheFlagAI.Impl.Pool;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.Impl.Projectiles
{

    public class Bullet : MonoBehaviour, Projectile
    {
        [SerializeField]
        private float speed;

        [SerializeField]
        private int damage;

        private new Rigidbody rigidbody;

        #region Projectile

        public Vector3 SourcePosition { get; set; }

        #endregion

        #region MonoBehaviour

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            Assert.IsNotNull(rigidbody, "No rigidbody component is attached to bullet " + gameObject.name);
        }

        void OnEnable()
        {
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.velocity = Vector3.zero;
        }

        void Update()
        {
            rigidbody.velocity = transform.forward * speed;
        }

        void OnCollisionEnter(Collision collision)
        {
            Hitable hitable = collision.gameObject.GetComponent<Hitable>();
            if (hitable != null)
                hitable.Hit(new HitInformation() { Damage = damage, PositionSource = SourcePosition } );

            GameManager.Instance.PoolManager.Put(gameObject);
        }

        #endregion
    }
}