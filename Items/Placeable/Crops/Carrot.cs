using FoodOverhaul.Tiles.Crops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FoodOverhaul.Items.Placeable.Crops
{
    public class Carrot : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 34;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 50000;
            Item.rare = ItemRarityID.Green;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<CarrotTile>();
        }
    }
}
