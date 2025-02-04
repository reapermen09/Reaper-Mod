using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ReapersMod.System
{
    public class ReapersBrain : ModSystem
    {
        private int SpawnX = Main.spawnTileX;
        private int SpawnY = Main.spawnTileY;
        private int MeteorHit;
        private int currentSeedX;
        private int currentSeedY;

        public override void PostUpdateTime()
        {
            MeteorHit = Main.rand.Next(1001);
            if (MeteorHit == 0)
            {
                WorldGen.meteor(SeedX(), SeedY(), true);
            }
        }

        private int SeedX()
        {
            currentSeedX = WorldGen.genRand.Next(SpawnX - 2000, SpawnX + 2001);
            return currentSeedX;
        }

        private int SeedY()
        {
            currentSeedY = WorldGen.genRand.Next(SpawnY - 200, SpawnY + 1001);
            return currentSeedY;
        }

        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
        {
            tileColor = Color.Red;
            backgroundColor = Color.Red;
        }
    }
}
