using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace ReapersMod.Content.Worldworks
{
    public class WorldPasses : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {

            int lava = tasks.FindIndex(genPass => genPass.Name.Equals("Final Cleanup"));
            if (lava != -1)
                tasks.Insert(lava + 1, new Lava("Lava", 237.4298f));

            int lava2 = tasks.FindIndex(genPass => genPass.Name.Equals("Final Cleanup"));
            if (lava2 != -1)
                tasks.Insert(lava2 + 1, new AnyLiquidToLava("Lava2", 237.4299f));
            int ocean = tasks.FindIndex(genPass => genPass.Name.Equals("Final Cleanup"));
            if (ocean != -1)
                tasks.Insert(ocean + 1, new ReaperonicOcean("Ocean", 237.4300f));
            int safeHouse = tasks.FindIndex(genPass => genPass.Name.Equals("Final Cleanup"));
            if (safeHouse != -1)
                tasks.Insert(safeHouse + 1, new SafeHouse("SafeHouse", 237.4301f));
            int spawnPoint = tasks.FindIndex(genPass => genPass.Name.Equals("Final Cleanup"));
            if (spawnPoint != -1)
                tasks.Insert(spawnPoint + 1, new SetSpawnPoint("SpawnPoint", 237.4302f));
        }
    }
}