using CaptureTheFlagAI.API.Soldier;

namespace CaptureTheFlagAI.Impl.Soldier
{
    public class SoldierSniper : SoldierBase 
    {
        public override void Initialize()
        {
            base.Initialize();
            soldierType = SoldierTypes.Sniper;
        }
    }
}