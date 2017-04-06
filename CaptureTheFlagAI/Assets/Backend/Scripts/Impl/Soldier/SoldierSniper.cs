using CaptureTheFlagAI.API.Soldier;
using CaptureTheFlagAI.Impl.Weapons;

namespace CaptureTheFlagAI.Impl.Soldier
{
    public class SoldierSniper : SoldierBase 
    {
        protected override void InitializeInternal()
        {
            soldierType = SoldierTypes.Sniper;
        }

        protected override void CreateWeapon()
        {
            weapon = new SniperRifle(this, weaponSettings);
        }

    }
}