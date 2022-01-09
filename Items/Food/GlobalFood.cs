using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using FoodOverhaul.UI;
using FoodOverhaul.Nutrition;
using System;
using Terraria.GameInput;
using Microsoft.Xna.Framework;

namespace FoodOverhaul.Items.Food
{
    public class GlobalFood : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return lateInstantiation && NutritionServerConfig.Get().NutritionFacts.Contains(new ItemNutritionPair(entity.type, new()));
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

        public override bool ConsumeItem(Item item, Player player)
        {
            if (PlayerInput.Triggers.Current.QuickBuff && NutritionServerConfig.Get().NutritionFacts.
                Contains(new ItemNutritionPair(item.type, new())))
            {
                return false;
            }
            return base.ConsumeItem(item, player);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            bool found = NutritionServerConfig.Get().NutritionFacts.TryGetValue(new ItemNutritionPair(item.type, new()), out ItemNutritionPair pair);
            NutritionData val = found ? pair.Nutrition : new();
            FoodOverhaulPlayer player = FoodOverhaulPlayer.GetModPlayer();
            if (!val.Empty())
            {
                RemoveOldTooltips(tooltips);
                AddNutritionTooltips(tooltips, val, player.PlayerNutrition);
            }
        }
        private void AddNutritionTooltips(List<TooltipLine> tooltips, NutritionData val, PlayerNutritionData playerNutrition)
        {
            AddTooltip(tooltips, "Calories", val.Calories, playerNutrition.Calories, HealthinessHelper.TARGET_CALORIES, "", NutritionData.CALORIES_COLOR);
            AddTooltip(tooltips, "Fat", val.Fat, playerNutrition.Fat, HealthinessHelper.TARGET_FAT, "g", NutritionData.FAT_COLOR);
            AddTooltip(tooltips, "Sodium", val.Sodium, playerNutrition.Sodium, HealthinessHelper.TARGET_SODIUM, "mg", NutritionData.SODIUM_COLOR);
            AddTooltip(tooltips, "Carbs", val.Carbs, playerNutrition.Carbs, HealthinessHelper.TARGET_CARBS, "g", NutritionData.CARBS_COLOR);
            AddTooltip(tooltips, "Protein", val.Protein, playerNutrition.Protein, HealthinessHelper.TARGET_PROTEIN, "g", NutritionData.PROTEIN_COLOR);
        }
        private void AddTooltip(List<TooltipLine> tooltips, string label, int value, float playerValue, int max, string unit, Color textColor)
        {
            double percent = Math.Round((float)value / max * 100);
            double playerPercent = Math.Round((float)playerValue / max * 100);
            string toShow = $"[c/FF0000:{percent + playerPercent}%]";
            if (percent + playerPercent <= 100 * (1 + HealthinessHelper.HEATHY_BUFFER) && percent + playerPercent >= 100 * (1 - HealthinessHelper.HEATHY_BUFFER))
            {
                toShow = $"[c/00FF00:{percent + playerPercent}%]";
            }
            tooltips.Add(new(Mod, label, label + " " + value + unit + " (" + percent + "%) -> " + toShow)
            {
                overrideColor = textColor
            });
        }
        private static void RemoveOldTooltips(List<TooltipLine> tooltips)
        {
            tooltips.RemoveAll(old => old.Name.Equals("WellFedExpert") || old.Name.Equals("Tooltip0") || old.Name.Equals("BuffTime"));
        }
    }
}
