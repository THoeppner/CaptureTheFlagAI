using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Pool
{

    public class PoolManager : MonoBehaviour
    {
        public GameObject Get(GameObject original, Vector3 position, Quaternion rotation)
        {
            return Instantiate(original, position, rotation);
        }

        public void Put(GameObject gameObject)
        {
            Destroy(gameObject);
        }

        #region MonoBehaviour

        void Awake()
        {
        }

        #endregion
    }
}