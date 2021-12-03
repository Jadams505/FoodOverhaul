using Terraria;
using Terraria.ID;
using FoodOverhaul.Util;

namespace FoodOverhaul.Items.Food
{
	public class Cheese : ModFood
	{
		public Cheese()
        {
			nutrition.Fruits = 0;
			nutrition.Dairy = 40;
			nutrition.Carbs = 10;
			nutrition.Protein = 20;
			nutrition.Vegetables = 0;
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