using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FoodOverhaul.Items.Food
{
    public class VileMushroomStew : ModItem
    {
        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item2;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useTurn = true;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.width = 28;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 0, 20);
            Item.useAnimation = 17;
            Item.useTime = 17;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.VileMushroom, 2);
            recipe.AddRecipeGroup("FoodOverhaul:Bowls", 1);
            recipe.Register();
        }

    }
}
