using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace CaptureTheFlagAI.Samples
{
    public class NavAgentSample : MonoBehaviour
    {
        [SerializeField]
        float distanceNeeded = 0.1f;

        public List<Vector3> pathGenerated = new List<Vector3>();

        public void GeneratePath(Vector3 from, Vector3 to)
        {
            NavMeshPath path = new NavMeshPath();
            NavMesh.CalculatePath(from, to, NavMesh.AllAreas, path);
            pathGenerated = path.corners.ToList();
            if (pathGenerated.Count > 0)
                pathGenerated.RemoveAt(0);
        }

        void Update()
        {
            CheckTarget();
        }

        void CheckTarget()
        {
            if (pathGenerated.Count == 0)
                return;

            if ((transform.position - pathGenerated[0]).magnitude <= distanceNeeded)
            {
                pathGenerated.RemoveAt(0);
                return;
            }
        }

        void OnDrawGizmosSelected()
        {
            Color oldColor = Gizmos.color;
            for (int i = 0; i < pathGenerated.Count; i++)
            {
                if (i == 0)
                    Gizmos.color = Color.blue;
                else
                    Gizmos.color = Color.red;

                Gizmos.DrawWireCube(new Vector3(pathGenerated[i].x, 2, pathGenerated[i].z), Vector3.one);
            }

            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position + Vector3.up * 2, Vector3.one);

            Gizmos.color = oldColor;
        }
    }
}