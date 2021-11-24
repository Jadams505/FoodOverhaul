using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FoodOverhaul.Classes
{
    public abstract class ModFood : ModItem
    {

        protected Nutrition nutrition;

        public ModFood()
        {
            nutrition = new();
        }

        public Nutrition GetNutrition()
        {
            return nutrition;
        }


    }
}
