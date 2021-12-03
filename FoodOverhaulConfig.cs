using System;
using System.Collections.Generic;
using Terraria.ModLoader.Config;
using FoodOverhaul.Classes;
using Terraria.ID;
using System.ComponentModel;
using Terraria.ModLoader;

namespace FoodOverhaul
{
    public class NutritionConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public HashSet<ItemNutritionPair> NutritionFacts = Defaults.Default();

        public static NutritionConfig Get()
        {
            return ModContent.GetInstance<NutritionConfig>();
        }

    }

    public struct Defaults
    {
        public static HashSet<ItemNutritionPair> Default()
        {
            HashSet<ItemNutritionPair> set = new();

            //Vanilla Foods

            set.Add(VanillaEntry(ItemID.CookedMarshmallow, 0, 5, 0, 0, 0));
            set.Add(VanillaEntry(ItemID.AppleJuice, 0, 5, 30, 0, 0));
            set.Add(VanillaEntry(ItemID.BloodyMoscato, 3, 5, 40, 20, 0));

            //Modded Foods

            foreach (ModFood food in ModContent.GetContent<ModFood>())
            {
                set.Add(new ItemNutritionPair(food.Type, food.GetNutrition()));
            }
            return set;
        }

        private static ItemNutritionPair VanillaEntry(int id, int protein, int carbs, int fruit, int vegetables, int dairy)
        {
            return new ItemNutritionPair(id, new NutritionData(protein, carbs, fruit, vegetables, dairy));
        }
    }

    [TypeConverter(typeof(ToFromStringConverter<ItemNutritionPair>))]
    public class ItemNutritionPair
    {
        public ItemDefinition Item { get; set; }
        [SeparatePage]
        public NutritionData Nutrition { get; set; }

        public ItemNutritionPair(string mod, string name, NutritionData data)
        {
            Item = new ItemDefinition(mod, name);
            Nutrition = data;
        }

        public ItemNutritionPair(int id, NutritionData data)
        {
            ModItem modItem = ItemLoader.GetItem(id);
            Item = modItem == null ? new ItemDefinition(id) : new ItemDefinition(modItem.Mod.Name, modItem.Name);
            Nutrition = data;
        }

        public ItemNutritionPair()
        {
            Item = new ItemDefinition();
            Nutrition = new NutritionData();
        }

        public override bool Equals(object obj)
        {
            if (obj is ItemNutritionPair other)
                return Item.Equals(other.Item);
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new { Item }.GetHashCode();
        }
        public override string ToString()
        {
            return $"{Item.mod} {Item.name} {Nutrition.Protein} {Nutrition.Carbs} {Nutrition.Fruits} {Nutrition.Vegetables} {Nutrition.Dairy}";
        }
        public static ItemNutritionPair FromString(string s)
        {
            string[] vars = s.Split(new char[] { ' ' }, 7, StringSplitOptions.RemoveEmptyEntries);
            return new ItemNutritionPair
            {
                Item = new ItemDefinition(vars[0], vars[1]),
                Nutrition = new NutritionData(Convert.ToInt32(vars[2]), Convert.ToInt32(vars[3]), Convert.ToInt32(vars[4]),
                Convert.ToInt32(vars[5]), Convert.ToInt32(vars[6]))
            };
        }
    }

    public class NutritionData
    {
        public const int MAX = 100;

        [Range(0, MAX)]
        [BackgroundColor(210, 160, 255)]
        public int Protein;
        [BackgroundColor(255, 200, 150)]
        public int Carbs;
        [BackgroundColor(255, 150, 150)]
        public int Fruits;
        [BackgroundColor(150, 255, 150)]
        public int Vegetables;
        [BackgroundColor(150, 150, 255)]
        public int Dairy;

        public NutritionData()
        {
            Protein = 0;
            Carbs = 0;
            Fruits = 0;
            Vegetables = 0;
            Dairy = 0;
        }

        public NutritionData(int protein, int carbs, int fruits, int vegetables, int dairy)
        {
            Protein = protein;
            Carbs = carbs;
            Fruits = fruits;
            Vegetables = vegetables;
            Dairy = dairy;
        }

        public override bool Equals(object obj)
        {
            if (obj is NutritionData other)
            {
                return Protein == other.Protein && Carbs == other.Carbs && Fruits == other.Fruits
                    && Vegetables == other.Vegetables && Dairy == other.Dairy;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new { Protein, Carbs, Fruits, Vegetables, Dairy }.GetHashCode();
        }

    }
}
