using Terraria;
using Terraria.ID;
using FoodOverhaul.Util;

namespace FoodOverhaul.Items.Food
{
	public class Cheese : ModFood
	{
		public Cheese()
        {
			nutrition.Calories = 110;
			nutrition.Fat = 9;
			nutrition.Sodium = 180;
			nutrition.Carbs = 2;
			nutrition.Protein = 7;
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