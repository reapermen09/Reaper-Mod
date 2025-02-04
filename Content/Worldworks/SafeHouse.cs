using Microsoft.CodeAnalysis;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

//IMAGINE STEALING CONTENT FROM YOURSELF
namespace ReapersMod.Content.Worldworks
{
    public class SafeHouse : GenPass
    {
        public SafeHouse(string name, float loadWeight) : base(name, loadWeight) { }
        private int sX = Main.spawnTileX;
        private int sY = Main.spawnTileY;
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating a Reaper Secured House #Trust";
            int x = 0, y = 0;

            for (int X = 0; X < 10; X++)
            {
                x = X * 12;
                    SpawnHouse(sX + x, sY - y);
            }
        }
        private void SpawnHouse(int spawnX, int spawnY)
        {
            // Floor
            for (int i = 0; i < 11; i++)
            {
                WorldGen.PlaceTile(spawnX + i, spawnY, TileID.WoodBlock, forced: true);
            }

            // Roof
            WorldGen.PlaceTile(spawnX + 0, spawnY - 5, TileID.WoodBlock, forced: true);
            WorldGen.PlaceTile(spawnX + 1, spawnY - 5, TileID.WoodBlock, forced: true);
            WorldGen.PlaceTile(spawnX + 9, spawnY - 5, TileID.WoodBlock, forced: true);
            WorldGen.PlaceTile(spawnX + 10, spawnY - 5, TileID.WoodBlock, forced: true);
            for (int i = 0; i < 7; i++)
            {
                WorldGen.PlaceTile(spawnX + i + 2, spawnY - 5, TileID.Platforms, forced: true);
            }

            //left side w/doors
            WorldGen.PlaceTile(spawnX - 1, spawnY, TileID.WoodBlock, forced: true);

            WorldGen.PlaceTile(spawnX - 1, spawnY - 4, TileID.WoodBlock, forced: true);
            WorldGen.PlaceTile(spawnX - 1, spawnY - 5, TileID.WoodBlock, forced: true);
            //calls after the blocks are made because thats just how doors work
            WorldGen.PlaceTile(spawnX - 1, spawnY - 1, TileID.ClosedDoor, forced: true); //takes -31, -32, and -33 away leaving -34 and lesser as the only options

            //right side
            WorldGen.PlaceTile(spawnX + 11, spawnY, TileID.WoodBlock, forced: true);

            WorldGen.PlaceTile(spawnX + 11, spawnY - 4, TileID.WoodBlock, forced: true);
            WorldGen.PlaceTile(spawnX + 11, spawnY - 5, TileID.WoodBlock, forced: true);

            WorldGen.PlaceTile(spawnX + 11, spawnY - 1, TileID.ClosedDoor, forced: true);

            //torch
            WorldGen.PlaceTile(spawnX, spawnY - 4, TileID.Torches, forced: true);

            //walls with a glass window...

            //walls:
            for (int i = 0; i < 11; i++)
            {
                WorldGen.PlaceWall(spawnX + i, spawnY - 1, WallID.Wood);
                WorldGen.PlaceWall(spawnX + i, spawnY - 4, WallID.Wood);
            }
            //glass windows:
            int yloop;
            for (yloop = 0; yloop < 2; yloop++) //repeats up twice
            {
                for (int i = 0; i < 2; i++)
                {
                    WorldGen.PlaceWall(spawnX + i, spawnY - 3 + yloop, WallID.Wood);
                }
                WorldGen.PlaceWall(spawnX + 2, spawnY - 3 + yloop, WallID.Glass);
                WorldGen.PlaceWall(spawnX + 3, spawnY - 3 + yloop, WallID.Glass);
                for (int i = 0; i < 7; i++)
                {
                    WorldGen.PlaceWall(spawnX + 4 + i, spawnY - 3 + yloop, WallID.Wood);
                }
            }

            //platform and chest
            WorldGen.PlaceTile(spawnX + 5, spawnY - 2, TileID.Platforms, forced: true);
            WorldGen.PlaceTile(spawnX + 6, spawnY - 2, TileID.Platforms, forced: true);

            int leftChestIndex = WorldGen.PlaceChest(spawnX + 5, spawnY - 3);
            if (leftChestIndex >= 0 && Main.chest[leftChestIndex] != null)
            {
                Main.chest[leftChestIndex].item[0] = new Item(ItemID.Wood, 20);
                Main.chest[leftChestIndex].item[1] = new Item(ItemID.StoneBlock, 20);
                Main.chest[leftChestIndex].item[2] = new Item(ItemID.Torch, 10);
                Main.chest[leftChestIndex].item[3] = new Item(ItemID.SilverCoin, 50);
                Main.chest[leftChestIndex].item[4] = new Item(ItemID.IronBar, 5);
                Main.chest[leftChestIndex].item[5] = new Item(ItemID.TinBar, 5);
            }

            WorldGen.PlaceTile(spawnX + 8, spawnY - 2, TileID.Platforms, forced: true);
            WorldGen.PlaceTile(spawnX + 9, spawnY - 2, TileID.Platforms, forced: true);
            int rightChestIndex = WorldGen.PlaceChest(spawnX + 8, spawnY - 3);
            if (rightChestIndex >= 0 && Main.chest[rightChestIndex] != null)
            {
                Main.chest[rightChestIndex].item[0] = new Item(ItemID.SuspiciousLookingEye, 1);
                Main.chest[rightChestIndex].item[1] = new Item(ItemID.SlimeCrown, 1);
            }

            //place workbench and chair
            WorldGen.PlaceTile(spawnX + 2, spawnY - 1, TileID.WorkBenches, forced: true);
            WorldGen.PlaceTile(spawnX + 1, spawnY - 1, TileID.Chairs, forced: true);
            Main.tile[spawnX + 1, spawnY - 1].TileFrameX = 18; //face right
            Main.tile[spawnX + 1, spawnY - 2].TileFrameX = 18;

            //if you did this it would automatically face left
            //WorldGen.PlaceTile(spawnX + 4, spawnY - 31, TileID.Chairs, forced: true);
        }
    }
}