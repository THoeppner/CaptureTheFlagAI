using CaptureTheFlagAI.API.Soldier;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.API.Senses
{
    public interface VisualSense
    {
        List<DetectedSoldier> GetDetectedSoldiers(List<DetectedSoldier> soldiers);
    }
}