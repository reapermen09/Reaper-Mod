using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace ReapersMod.Content.Worldworks
{
    public class SetSpawnPoint : GenPass
    {
        public SetSpawnPoint(string name, float loadWeight) : base(name, loadWeight) { }
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Setting a new spawn point...";
            Main.spawnTileX = Main.maxTilesX / 2;
            Main.spawnTileY = (int)(Main.maxTilesY / 4.8) - 80;
        }
    }
}
