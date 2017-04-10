using CaptureTheFlagAI.API.Soldier;
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
        const string TeamBColor = "Yellow";

        public static void ChangeMaterialToTeamA(SoldierTypes type, GameObject baseObject)
        {
            Transform t = baseObject.transform.FindChild(rendererPath);
            if (!t)
                return;

            ChangeMaterial(type, TeamAColor, t);
        }

        public static void ChangeMaterialToTeamB(SoldierTypes type, GameObject baseObject)
        {
            Transform t = baseObject.transform.FindChild(rendererPath);
            if (!t)
                return;

            ChangeMaterial(type, TeamBColor, t);
        }

        private static void ChangeMaterial(SoldierTypes type, string colorName, Transform transform)
        {
            string materialName = materialPath;
            switch (type)
            {
                case SoldierTypes.Gunner: materialName += GunnerMaterialName; break;
                case SoldierTypes.Infantry: materialName += InfantryMaterialName; break;
                case SoldierTypes.Sniper: materialName += SniperMaterialName; break;
                case SoldierTypes.Scout: materialName += ScoutMaterialName; break;
            }

            materialName += colorName;

            transform.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(materialName);
        }
    }
}
