using CaptureTheFlagAI.API.Soldier;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class InGameTests : MonoBehaviour
{
    public float speed = 1;
    public Transform target;
    public SoldierWrapper sniper;
    public SoldierWrapper infantry;

    Vector3 sniperTarget;
    Vector3 infantryTarget;

    // Use this for initialization
    void Start () {
        Assert.IsNotNull(target, "Field target is not set for gameobject " + gameObject.name);
        Assert.IsNotNull(sniper, "Field sniper is not set for gameobject " + gameObject.name);
        Assert.IsNotNull(infantry, "Field infantry is not set for gameobject " + gameObject.name);

        sniperTarget = sniper.transform.position;
        infantryTarget = infantry.transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            sniperTarget = target.position;
            sniperTarget.y = 0;
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            infantryTarget = target.position;
            infantryTarget.y = 0;
        }

        sniper.GetMoveable().MoveTo(sniperTarget, speed);
        infantry.GetMoveable().MoveTo(infantryTarget, speed);

    }
}
