using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using FoodOverhaul.WorldGen.Trees;

namespace FoodOverhaul.Tiles
{
    public class AppleGrass : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            ItemDrop = ModContent.ItemType<Items.Placeable.AppleGrass>();
            SetModTree(new AppleTree());
        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<TestTile>();
        }
    }
}
