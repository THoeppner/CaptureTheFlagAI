using CaptureTheFlagAI.API.Soldier;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptureTheFlagAI.Impl.Teams
{


    public static class TeamMaterialChanger 
    {
        const string rendererPath = "Model/MESH_Sniper";
        const string materialPath = "TeamMaterials/";

        const string InfantryMaterialName = "Soldier_Basic_Infantry_";
        const string SniperMaterialName = "Soldier_Basic_Sniper_";
        const string GunnerMaterialName = "Soldier_Basic_Gunner_";
        const string ScoutMaterialName = "Soldier_Basic_Scout_";

        const string TeamAColor = "Blue";
        const string TeamBColor = "Green";

        public static void ChangeMaterial(SoldierTypes type, bool teamA, GameObject baseObject)
        {
            Transform t = baseObject.transform.FindChild(rendererPath);
            if (!t)
                return;

            string materialName = materialPath;
            switch (type)
            {
                case SoldierTypes.Gunner: materialName += GunnerMaterialName; break;
                case SoldierTypes.Infantry: materialName += InfantryMaterialName; break;
                case SoldierTypes.Sniper: materialName += SniperMaterialName; break;
                case SoldierTypes.Scout: materialName += ScoutMaterialName; break;
            }

            if (teamA)
                materialName += TeamAColor;
            else
                materialName += TeamBColor;

            t.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(materialName);
        }
    }
}