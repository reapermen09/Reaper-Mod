using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace ReapersMod.Content.Worldworks
{
    public class AnyLiquidToLava : GenPass
    {
        public AnyLiquidToLava(string name, float loadWeight) : base(name, loadWeight) { }
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Removing Terraria's unnecessary liquids and turning them into lava";

            for (int x = 0; x < Main.maxTilesX; x++)
            {
                for (int y = 0; y < Main.maxTilesY; y++)
                {
                    if (Main.tile[x, y].LiquidAmount > 0 && Main.tile[x, y].LiquidType != LiquidID.Lava)
                    {
                        byte getLiquidAmount = Main.tile[x, y].LiquidAmount;
                        Main.tile[x, y].LiquidAmount = 0;
                        WorldGen.PlaceLiquid(x, y, (byte)LiquidID.Lava, getLiquidAmount);
                    }
                }
            }
        }
    }
}