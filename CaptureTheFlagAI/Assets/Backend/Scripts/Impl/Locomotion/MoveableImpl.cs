using UnityEngine;
using CaptureTheFlagAI.API.Locomotion;

namespace CaptureTheFlagAI.Impl.Locomotion
{
    public class MoveableImpl : MonoBehaviour, Moveable
    {
        #region Moveable

        public void MoveTo(Vector3 destination, float speed)
        {
            Debug.Log("MoveTo: " + destination);
        }

        #endregion


        void Awake()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}