using CaptureTheFlagAI.API.Locomotion;
using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.Impl.Soldier;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CaptureTheFlagAI.Impl.UI
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField]
        private Image healthIndicator;

        [SerializeField]
        private float yOffset = 2;

        public Statistics Statistics { get; set; }

        public Moveable Moveable { get; set; }

        void Update()
        {
            if (Statistics.IsDead)
                Destroy(gameObject);

            healthIndicator.fillAmount = (float)Statistics.Health / (float)Statistics.MaxHealth;
            transform.position = Camera.main.WorldToScreenPoint(Moveable.GetPosition() + (Vector3.up * yOffset));
        }
    }
}