using Terraria;
using Terraria.ID;
using FoodOverhaul.Util;
using Terraria.ModLoader;
using FoodOverhaul.Nutrition;

namespace FoodOverhaul.Items.Food
{
	public class Cheese : ModItem
	{
		public override void SetDefaults()
		{
			Item.consumable = true;
			Item.UseSound = SoundID.Item2;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.useTurn = true;
			Item.maxStack = 30;
			Item.width = 22;
			Item.height = 22;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 0, 20);
			Item.useAnimation = 17;
			Item.useTime = 17;
		}

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MilkCarton, 10);
			recipe.Register();
		}
    }
}