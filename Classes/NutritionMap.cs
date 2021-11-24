using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using FoodOverhaul.UI;
namespace FoodOverhaul.Classes
{
    public class NutritionMap
    {
        private static NutritionMap INSTANCE;
        private Dictionary<string, Nutrition> MAP;

        private NutritionMap()
        {
            Init();
        }

        public static NutritionMap Instance()
        {
            if(INSTANCE == null)
            {
                INSTANCE = new NutritionMap();
            }
            return INSTANCE;
        }

        private void Init()
        {
            MAP = new Dictionary<string, Nutrition>();
        }

        public static string ItemToKey(Item item)
        {
            return item.ModItem == null ? ItemID.Search.GetName(item.netID) : item.ModItem.FullName;
        }

        public void Add(Item item, Nutrition val)
        {
            MAP.TryAdd(ItemToKey(item), val);
        }

        public Nutrition Get(Item item)
        {
            MAP.TryGetValue(ItemToKey(item), out Nutrition val);
            return val;
        }

        public List<TooltipLine> GetNutritionTooltip(Mod mod, Item item)
        {
            List<TooltipLine> list = new();
            Nutrition val;
            val = item.ModItem == null ? MAP.GetValueOrDefault(ItemID.Search.GetName(item.netID), new Nutrition()) : MAP.GetValueOrDefault(item.ModItem.FullName, new Nutrition());

            TooltipLine tooltip = new(mod, "Nutrition Facts", "Nutrition Facts:");
            list.Add(tooltip);
            tooltip = new(mod, "Fruit", val.Fruits.Val + " Fruits");
            tooltip.overrideColor = NutritionPanel.FRUIT_COLOR;
            list.Add(tooltip);
            tooltip = new(mod, "Vegatable", val.Vegatables.Val + " Vegatables");
            tooltip.overrideColor = NutritionPanel.VEGETABLES_COLOR;
            list.Add(tooltip);
            tooltip = new(mod, "Protein", val.Protein.Val + " Protein");
            tooltip.overrideColor = NutritionPanel.PROTEIN_COLOR;
            list.Add(tooltip);
            tooltip = new(mod, "Carbs", val.Carbs.Val + " Carbs");
            tooltip.overrideColor = NutritionPanel.CARBS_COLOR;
            list.Add(tooltip);
            tooltip = new(mod, "Dairy", val.Dairy.Val + " Dairy");
            tooltip.overrideColor = NutritionPanel.DAIRY_COLOR;
            list.Add(tooltip);

            return list;
        }
    }
}
