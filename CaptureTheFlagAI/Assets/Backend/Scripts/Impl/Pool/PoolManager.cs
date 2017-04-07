using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Pool
{

    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance;


        public GameObject Get(GameObject original, Vector3 position, Quaternion rotation)
        {
            return Instantiate(original, position, rotation);
        }

        public void Put(GameObject gameObject)
        {
            Destroy(gameObject);
        }

        #region MonoBehaviour

        // Use this for initialization
        void Awake()
        {
            Instance = this;
        }

        #endregion
    }
}