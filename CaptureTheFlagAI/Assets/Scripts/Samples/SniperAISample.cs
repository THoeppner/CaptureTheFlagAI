using CaptureTheFlagAI.API.Soldier;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CaptureTheFlagAI.Samples
{

    public class SniperAISample : SoldierAIBase
    {
        public bool patrol;
        NavAgentSample navAgent;

        protected override void AwakeInternal()
        {
            base.AwakeInternal();

            navAgent = GetComponent<NavAgentSample>();
            Assert.IsNotNull(navAgent, "No NavAgentSample component is attached to " + gameObject.name);
        }

        // Use this for initialization
        void Start()
        {
            if (patrol)
                navAgent.GeneratePath(Moveable.GetPosition(), new Vector3(11, 0 ,7));
        }

        int counter = 0;

        // Update is called once per frame
        void Update()
        {
            if (navAgent.pathGenerated.Count > 0)
            {
                Moveable.LookAt(navAgent.pathGenerated[0]);
                Moveable.MoveTowards(navAgent.pathGenerated[0], 1);
            }
            else if (patrol)
            {
                if (counter == 0)
                    navAgent.GeneratePath(Moveable.GetPosition(), new Vector3(-11, 0, 7));
                else if (counter == 1)
                    navAgent.GeneratePath(Moveable.GetPosition(), new Vector3(0, 0, -15));
                else if (counter == 2)
                    navAgent.GeneratePath(Moveable.GetPosition(), new Vector3(11, 0, 7));
                else
                    counter = -1;

                counter++;
            }
        }
    }
}