using Terraria;
using Terraria.ID;
using FoodOverhaul.Util;
using FoodOverhaul.Classes;
using Terraria.ModLoader;

namespace FoodOverhaul.Items.Food
{
	public class Cheese : ModFood
	{

		public Cheese()
        {
			nutrition.fruit = 0;
			nutrition.dairy = 40;
			nutrition.carbs = 10;
			nutrition.protein = 20;
			nutrition.vegatable = 0;
        }

		public override void SetDefaults()
		{
			Item.DefaultToFood(22, 22, BuffID.WellFed, TimeUtil.Minutes(10));
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.Register();
		}

    }
}