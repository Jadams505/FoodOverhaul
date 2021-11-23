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
            nutrition = new Nutrition();
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("Protein " + GetNutrition().protein);
        }

        public Nutrition GetNutrition()
        {
            return nutrition;
        }


    }
}
