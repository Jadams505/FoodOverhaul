using Terraria.ModLoader;

namespace FoodOverhaul.Items.Food
{
    public abstract class ModFood : ModItem
    {

        protected NutritionData nutrition;

        public ModFood()
        {
            nutrition = new();
        }

        public NutritionData GetNutrition()
        {
            return nutrition;
        }


    }
}
