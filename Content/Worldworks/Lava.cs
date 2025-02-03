using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace ReaperMod.Content.Worldworks
{
    public class Lava : GenPass
    {
        public Lava(string name, float loadWeight) : base(name, loadWeight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "[c/ff0000:Generating some reaper into this world...]";

            int spawnX = Main.spawnTileX;
            int spawnY = Main.spawnTileY;

            int pears = 120;
            int[] offsets = new int[pears];

            for (int j = 0; j < pears; j++)
            {
                offsets[j] = WorldGen.genRand.Next(j * 4, j  * 8); 
            }
                for (int i = 0; i < SeedReset(); i++)
                {
                    for (int j = 0; j < pears; j++)
                    {
                        WorldGen.PlaceLiquid(spawnX + offsets[j] + i, spawnY - 100, (byte)LiquidID.Lava, 10);
                        WorldGen.PlaceLiquid(spawnX - offsets[j] + i, spawnY - 100, (byte)LiquidID.Lava, 10);
                    }
                }
            }

        private int SeedReset()
        {
            return Main.rand.Next(30, 41);
        }
    }
}