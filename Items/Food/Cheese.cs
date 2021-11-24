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
			nutrition.Fruits.Val = 0;
			nutrition.Dairy.Val = 40;
			nutrition.Carbs.Val = 10;
			nutrition.Protein.Val = 20;
			nutrition.Vegatables.Val = 0;
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