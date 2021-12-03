using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using FoodOverhaul.Util;
using FoodOverhaul.UI;
namespace FoodOverhaul.Items.Global_Items
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
                bool found = ModContent.GetInstance<NutritionConfig>().NutritionFacts.TryGetValue(new ItemNutritionPair(item.type, new()), out ItemNutritionPair pair);
                if (found)
                {
                    modPlayer.AddNutrition(pair.Nutrition);
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
            bool found = ModContent.GetInstance<NutritionConfig>().NutritionFacts.TryGetValue(new ItemNutritionPair(item.type, new()), out ItemNutritionPair pair);
            NutritionData val = found ? pair.Nutrition : new();
            if (!NutritionHelper.Empty(ref val))
            {
                TooltipLine tooltip = new(mod, "Nutrition Facts", "Nutrition Facts:");
                list.Add(tooltip);
                tooltip = new(mod, "Fruit", val.Fruits + " Fruits");
                tooltip.overrideColor = NutritionPanel.FRUIT_COLOR;
                list.Add(tooltip);
                tooltip = new(mod, "Vegatable", val.Vegetables + " Vegatables");
                tooltip.overrideColor = NutritionPanel.VEGETABLES_COLOR;
                list.Add(tooltip);
                tooltip = new(mod, "Protein", val.Protein + " Protein");
                tooltip.overrideColor = NutritionPanel.PROTEIN_COLOR;
                list.Add(tooltip);
                tooltip = new(mod, "Carbs", val.Carbs + " Carbs");
                tooltip.overrideColor = NutritionPanel.CARBS_COLOR;
                list.Add(tooltip);
                tooltip = new(mod, "Dairy", val.Dairy + " Dairy");
                tooltip.overrideColor = NutritionPanel.DAIRY_COLOR;
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
