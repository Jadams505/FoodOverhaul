using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using FoodOverhaul.Util;
using FoodOverhaul.UI;
namespace FoodOverhaul.Items.Food
{
    public class GlobalFood : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return true; // fix later
        }

        public override void SetDefaults(Item item)
        {
            base.SetDefaults(item);
        }

        public override void OnConsumeItem(Item item, Player player)
        {
            ChatUtil.Info("I ate Food Today");
            FoodOverhaulPlayer modPlayer;
            try
            {
                modPlayer = player.GetModPlayer<FoodOverhaulPlayer>();
                bool found = NutritionServerConfig.Get().NutritionFacts.TryGetValue(new ItemNutritionPair(item.type, new()), out ItemNutritionPair pair);
                if (found)
                {
                    modPlayer.AddNutrition(pair.Nutrition);
                    NutritionBubblesUI.UpdateNutrition(modPlayer.PlayerNutrition);
                }

            }
            catch (KeyNotFoundException ex)
            {
                Mod.Logger.Error(ex);
            }
        }

        public static List<TooltipLine> GetNutritionTooltip(Mod mod, Item item)
        {
            List<TooltipLine> list = new();
            bool found = NutritionServerConfig.Get().NutritionFacts.TryGetValue(new ItemNutritionPair(item.type, new()), out ItemNutritionPair pair);
            NutritionData val = found ? pair.Nutrition : new();
            if (!val.Empty())
            {
                TooltipLine tooltip = new(mod, "Nutrition Facts", "Nutrition Facts:");
                list.Add(tooltip);
                tooltip = new(mod, "Calories", val.Calories + " Calories");
                tooltip.overrideColor = NutritionData.CALORIES_COLOR;
                list.Add(tooltip);
                tooltip = new(mod, "Fat", val.Fat + " Fat");
                tooltip.overrideColor = NutritionData.FAT_COLOR;
                list.Add(tooltip);
                tooltip = new(mod, "Sodium", val.Sodium + " Sodium");
                tooltip.overrideColor = NutritionData.SODIUM_COLOR;
                list.Add(tooltip);
                tooltip = new(mod, "Carbs", val.Carbs + " Carbs");
                tooltip.overrideColor = NutritionData.CARBS_COLOR;
                list.Add(tooltip);
                tooltip = new(mod, "Protein", val.Protein + " Protein");
                tooltip.overrideColor = NutritionData.PROTEIN_COLOR;
                list.Add(tooltip);
            }
            return list;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.AddRange(GetNutritionTooltip(Mod, item));
        }

    }
}
