using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FoodOverhaul.Classes
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
