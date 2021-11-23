using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
namespace FoodOverhaul.Classes
{
    public class NutritionMap
    {
        private static NutritionMap INSTANCE;
        private Dictionary<string, Nutrition> MAP;

        private NutritionMap()
        {
            init();
        }

        public static NutritionMap Instance()
        {
            if(INSTANCE == null)
            {
                INSTANCE = new NutritionMap();
            }
            return INSTANCE;
        }

        private void init()
        {
            MAP = new Dictionary<string, Nutrition>();
        }

        public string ItemToKey(Item item)
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

            TooltipLine tooltip = new TooltipLine(mod, "Nutrition Facts", "Nutrition Facts:");
            list.Add(tooltip);
            tooltip = new(mod, "Fruit", val.fruit + " Fruits");
            tooltip.overrideColor = Colors.RarityRed;
            list.Add(tooltip);
            tooltip = new(mod, "Vegatable", val.vegatable + " Vegatables");
            tooltip.overrideColor = Colors.RarityGreen;
            list.Add(tooltip);
            tooltip = new(mod, "Protein", val.protein + " Protein");
            tooltip.overrideColor = Colors.RarityPurple;
            list.Add(tooltip);
            tooltip = new(mod, "Carbs", val.carbs + " Carbs");
            tooltip.overrideColor = Colors.RarityOrange;
            list.Add(tooltip);
            tooltip = new(mod, "Dairy", val.dairy + " Dairy");
            tooltip.overrideColor = Colors.RarityBlue;
            list.Add(tooltip);

            return list;
        }
    }
}
