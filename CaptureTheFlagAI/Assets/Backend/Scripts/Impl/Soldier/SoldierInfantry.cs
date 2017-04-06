using CaptureTheFlagAI.API.Soldier;

namespace CaptureTheFlagAI.Impl.Soldier
{

    public class SoldierInfantry : SoldierBase
    {
        protected override void InitializeInternal()
        {
            soldierType = SoldierTypes.Infantry;
        }

    }
}