using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace ReapersMod.Content.Worldworks
{
    public class ReaperonicOcean : GenPass
    {
        public ReaperonicOcean(string name, float loadWeight) : base(name, loadWeight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating Reaperonic Ocean...";
            for (int i = 0; i < 10; i++)
            {
                for (int x = 0; x < Main.maxTilesX; x++)
                {
                    WorldGen.PlaceLiquid(x, Main.spawnTileY - i, (byte)LiquidID.Lava, 255);
                }
            }
        }
    }
}
