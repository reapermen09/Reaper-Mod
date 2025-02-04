using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReapersMod.System
{
    public class AllWeaponsToCopperShortsword : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.damage > 0 && item.useStyle == ItemUseStyleID.Swing)
            {
                item.CloneDefaults(ItemID.CopperShortsword);
            }
        }
    }
}
