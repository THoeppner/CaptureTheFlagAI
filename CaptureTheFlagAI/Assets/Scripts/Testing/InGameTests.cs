﻿using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class InGameTests : MonoBehaviour
{
    public float speed = 1;
    public float targetReachedDistance = 0.1f;
    public Transform target;
    public SoldierAIBase sniper;
    public SoldierAIBase infantry;

    List<DetectedSoldier> detectedSoldiers = new List<DetectedSoldier>();

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

        if ((sniperTarget - sniper.Moveable.GetPosition()).magnitude > targetReachedDistance)
            sniper.Moveable.MoveTowards(sniperTarget, speed);
        else
            sniper.Moveable.Stop();

        if ((infantryTarget - infantry.Moveable.GetPosition()).magnitude > targetReachedDistance)
            infantry.Moveable.MoveTowards(infantryTarget, speed);
        else
            infantry.Moveable.Stop();

        //sniper.Moveable.LookAt(target.position);
        //infantry.Moveable.LookAt(target.position);

        if (Input.GetKeyDown(KeyCode.A))
        {
            sniper.CurrentWeapon.Shoot();
            infantry.CurrentWeapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            sniper.Moveable.IsCrouching = !sniper.Moveable.IsCrouching;
            infantry.Moveable.IsCrouching = !infantry.Moveable.IsCrouching;
        }

        detectedSoldiers.Clear();
        if (sniper.VisualSense.GetDetectedSoldiers(detectedSoldiers).Count > 0)
        {
            Debug.Log("Sniper: I can see you: " + detectedSoldiers[0].SoldierType +  " of: " + detectedSoldiers[0].Team);
        }
        detectedSoldiers.Clear();
        if (infantry.VisualSense.GetDetectedSoldiers(detectedSoldiers).Count > 0)
        {
            Debug.Log("Infantry: I can see you: " + detectedSoldiers[0].SoldierType + " of: " + detectedSoldiers[0].Team);
        }
    }
}
