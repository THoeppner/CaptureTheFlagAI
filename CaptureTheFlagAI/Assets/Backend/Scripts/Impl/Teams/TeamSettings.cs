using CaptureTheFlagAI.Impl.Soldier;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Teams
{
    [Serializable]
    public class TeamSettings 
    {
        public GameObject sniperPrefab;
        public GameObject infantryPrefab;
        public GameObject gunnerPrefab;
        public GameObject scoutPrefab;

        public List<SpawnPoint> spawnPositions;
    }
}