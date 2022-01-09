using System;
using System.Collections.Generic;
using Terraria.ModLoader.Config;
using FoodOverhaul.Nutrition;
using Terraria.ID;
using System.ComponentModel;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FoodOverhaul.Util;
using FoodOverhaul.UI;
using System.IO;
using Newtonsoft.Json;

namespace FoodOverhaul
{
    public class NutritionClientConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(1000)]
        [Range(0, 2000)]
        public int UIPosX;
        [DefaultValue(80)]
        [Range(0, 2000)]
        public int UIPosY;
        [DefaultValue(true)]
        public bool UIVisible;
        [DefaultValue(true)]
        public bool UIPositionLocked;
        [DefaultValue(true)]
        public bool DisplayUIHorizontally;
        [DefaultValue(true)]
        public bool DisplayPercents;
        [DefaultValue(NutritionBubble.Direction.BOTTOM)]
        [DrawTicks]
        public NutritionBubble.Direction LabelTextPosition;
        

        public override void OnChanged()
        {
            NutritionBubblesUI.UpdatePanel(UIPosX, UIPosY);
            NutritionBubblesUI.LockPosition(UIPositionLocked);
            NutritionBubblesUI.SwitchOrientation(DisplayUIHorizontally);
            NutritionBubblesUI.AlignBubbles();
            NutritionBubblesUI.ShowPercent(DisplayPercents);
            NutritionBubblesUI.ToggleVisibility(UIVisible);
        }

        public void Save()
        {
            Directory.CreateDirectory(ConfigManager.ModConfigPath);
            string filename = Mod.Name + "_" + Name + ".json";
            string path = Path.Combine(ConfigManager.ModConfigPath, filename);
            string json = JsonConvert.SerializeObject((object)this, ConfigManager.serializerSettings);
            File.WriteAllText(path, json);
        }
        public static NutritionClientConfig Get()
        {
            return ModContent.GetInstance<NutritionClientConfig>();
        }
    }
    public class NutritionServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        
        public HashSet<ItemNutritionPair> NutritionFacts = DefaultNutritionValues.RealisticDefault();

        [DefaultValue(8 * 60)] // 8 seconds give or take
        [Range(1, 216000)]
        public int TickRate;

        public static NutritionServerConfig Get()
        {
            return ModContent.GetInstance<NutritionServerConfig>();
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
            return $"{Item.mod} {Item.name} {Nutrition.Calories} {Nutrition.Fat} {Nutrition.Sodium} {Nutrition.Carbs} {Nutrition.Protein}";
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
        public const int MAX = 9999;

        public static readonly Color CALORIES_COLOR = Colors.RarityYellow;
        public static readonly Color FAT_COLOR = Colors.RarityRed;
        public static readonly Color SODIUM_COLOR = Colors.RarityBlue;
        public static readonly Color CARBS_COLOR = Colors.RarityOrange;
        public static readonly Color PROTEIN_COLOR = Colors.RarityPurple;
        
        [Range(0,MAX)]
        [BackgroundColor(255, 255, 10)]
        public int Calories;
        [Label("Fat (g)")]
        [Range(0, MAX)]
        [BackgroundColor(255, 150, 150)]
        public int Fat;
        [Label("Sodium (mg)")]
        [Range(0, MAX)]
        [BackgroundColor(150, 150, 255)]
        public int Sodium;
        [Label("Carbohydrates (g)")]
        [Range(0, MAX)]
        [BackgroundColor(255, 200, 150)]
        public int Carbs;
        [Label("Protein (g)")]
        [Range(0, MAX)]
        [BackgroundColor(210, 160, 255)]
        public int Protein;
        
        public NutritionData()
        {
            Calories = 0;
            Fat = 0;
            Sodium = 0;
            Carbs = 0;
            Protein = 0;
        }

        public NutritionData(int calories, int fat, int sodium, int carbs, int protein)
        {
            Calories = calories;
            Fat = fat;
            Sodium = sodium;
            Carbs = carbs;
            Protein = protein;
        }

        public override bool Equals(object obj)
        {
            if (obj is NutritionData other)
            {
                return Protein == other.Protein && Carbs == other.Carbs && Fat == other.Fat
                    && Sodium == other.Sodium && Calories == other.Calories;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new { Protein, Carbs, Fat, Sodium, Calories }.GetHashCode();
        }

        public bool Empty()
        {
            return Calories == 0 && Carbs == 0 && Fat == 0 && Sodium == 0 && Protein == 0;
        }

        public string Format()
        {
            return Calories + " Calories\n" + Fat + " Fat\n" + Sodium + " Sodium\n" + Carbs + " Carbs\n" + Protein + " Protein";
        }
    }
}
