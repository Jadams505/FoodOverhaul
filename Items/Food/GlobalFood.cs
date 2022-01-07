using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using FoodOverhaul.Util;
using FoodOverhaul.UI;
using FoodOverhaul.Nutrition;
using System;
using Terraria.ID;
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
            
        }

        public override void OnConsumeItem(Item item, Player player)
        {
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
            FoodOverhaulPlayer player = FoodOverhaulPlayer.GetModPlayer();
            if (!val.Empty())
            {
                TooltipLine tooltip = GetTooltip(mod, "Calories", val.Calories, player.PlayerNutrition.Calories, HealthinessHelper.TARGET_CALORIES, "");
                tooltip.overrideColor = NutritionData.CALORIES_COLOR;
                list.Add(tooltip);
                tooltip = GetTooltip(mod, "Fat", val.Fat, player.PlayerNutrition.Fat, HealthinessHelper.TARGET_FAT, "g");
                tooltip.overrideColor = NutritionData.FAT_COLOR;
                list.Add(tooltip);
                tooltip = GetTooltip(mod, "Sodium", val.Sodium, player.PlayerNutrition.Sodium, HealthinessHelper.TARGET_SODIUM, "mg");
                tooltip.overrideColor = NutritionData.SODIUM_COLOR;
                list.Add(tooltip);
                tooltip = GetTooltip(mod, "Carbs", val.Carbs, player.PlayerNutrition.Carbs, HealthinessHelper.TARGET_CARBS, "g");
                tooltip.overrideColor = NutritionData.CARBS_COLOR;
                list.Add(tooltip);
                tooltip = GetTooltip(mod, "Protein", val.Protein, player.PlayerNutrition.Protein, HealthinessHelper.TARGET_PROTEIN, "g");
                tooltip.overrideColor = NutritionData.PROTEIN_COLOR;
                list.Add(tooltip);
            }
            return list;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.AddRange(GetNutritionTooltip(Mod, item));
        }

        private static TooltipLine GetTooltip(Mod mod, string label, int value, float playerValue, int max, string unit)
        {
            double percent = Math.Round((float)value / max * 100);
            double playerPercent = Math.Round((float)playerValue / max * 100);
            string toShow = $"[c/FF0000:{percent + playerPercent}%]";
            if (percent + playerPercent <= 100 * (1 + HealthinessHelper.HEATHY_BUFFER) && percent + playerPercent >= 100 * (1 - HealthinessHelper.HEATHY_BUFFER))
            {
                toShow = $"[c/00FF00:{percent + playerPercent}%]";
            }
            return new(mod, label, label + " " + value + unit + " (" + percent + "%) -> " + toShow);
        }

    }
}
