using CaptureTheFlagAI.API.Soldier;

namespace CaptureTheFlagAI.Impl.Soldier
{

    public class SoldierInfantry : SoldierBase
    {
        public override void Initialize()
        {
            base.Initialize();
            soldierType = SoldierTypes.Infantry;
        }

    }
}