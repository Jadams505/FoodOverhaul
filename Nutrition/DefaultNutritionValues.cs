using Terraria.ID;
using System.Collections.Generic;
using FoodOverhaul.Items.Food;
using Terraria.ModLoader;

namespace FoodOverhaul.Nutrition
{
    public class DefaultNutritionValues
    {
        public static HashSet<ItemNutritionPair> Defaults()
        {
            HashSet<ItemNutritionPair> set = new();

            AddVanillaEntry(set, id: 4291, calories: 60, fat: 0, sodium: 3, carbs: 19, protein: 2);
            AddVanillaEntry(set, id: 4293, calories: 65, fat: 0, sodium: 20, carbs: 15, protein: 1);
            AddVanillaEntry(set, id: 4282, calories: 75, fat: 0, sodium: 2, carbs: 17, protein: 2);
            AddVanillaEntry(set, id: 4009, calories: 100, fat: 0, sodium: 2, carbs: 25, protein: 0);
            AddVanillaEntry(set, id: 4290, calories: 130, fat: 0, sodium: 0, carbs: 33, protein: 3);
            AddVanillaEntry(set, id: 4295, calories: 70, fat: 0, sodium: 0, carbs: 18, protein: 1);
            AddVanillaEntry(set, id: 4286, calories: 50, fat: 0, sodium: 0, carbs: 24, protein: 2);
            AddVanillaEntry(set, id: 4284, calories: 50, fat: 0, sodium: 0, carbs: 13, protein: 0);
            AddVanillaEntry(set, id: 4285, calories: 50, fat: 0, sodium: 0, carbs: 12, protein: 0);
            AddVanillaEntry(set, id: 4294, calories: 80, fat: 0, sodium: 2, carbs: 22, protein: 1);
            AddVanillaEntry(set, id: 4283, calories: 100, fat: 0, sodium: 1, carbs: 29, protein: 2);
            AddVanillaEntry(set, id: 4289, calories: 105, fat: 1, sodium: 9, carbs: 27, protein: 1);
            AddVanillaEntry(set, id: 4296, calories: 120, fat: 0, sodium: 17, carbs: 31, protein: 1);
            AddVanillaEntry(set, id: 4292, calories: 125, fat: 1, sodium: 2, carbs: 31, protein: 2);
            AddVanillaEntry(set, id: 4287, calories: 130, fat: 3, sodium: 5, carbs: 4, protein: 1);
            AddVanillaEntry(set, id: 967, calories: 25, fat: 0, sodium: 6, carbs: 6, protein: 0);
            AddVanillaEntry(set, id: 357, calories: 125, fat: 6, sodium: 300, carbs: 8, protein: 2);
            AddVanillaEntry(set, id: 4014, calories: 200, fat: 11, sodium: 245, carbs: 15, protein: 6);
            AddVanillaEntry(set, id: 4024, calories: 240, fat: 7, sodium: 170, carbs: 0, protein: 7);
            AddVanillaEntry(set, id: 969, calories: 25, fat: 0, sodium: 6, carbs: 6, protein: 0);
            AddVanillaEntry(set, id: 353, calories: 70, fat: 0, sodium: 24, carbs: 17, protein: 0);
            AddVanillaEntry(set, id: 4033, calories: 80, fat: 3, sodium: 3, carbs: 0, protein: 5);
            AddVanillaEntry(set, id: 4031, calories: 180, fat: 8, sodium: 230, carbs: 5, protein: 4);
            AddVanillaEntry(set, id: 4019, calories: 50, fat: 1, sodium: 80, carbs: 1, protein: 4);
            AddVanillaEntry(set, id: 4024, calories: 100, fat: 0, sodium: 130, carbs: 36, protein: 0);
            AddVanillaEntry(set, id: 4614, calories: 100, fat: 0, sodium: 8, carbs: 28, protein: 0);
            AddVanillaEntry(set, id: 4616, calories: 80, fat: 0, sodium: 14, carbs: 21, protein: 0);
            AddVanillaEntry(set, id: 4618, calories: 85, fat: 0, sodium: 23, carbs: 19, protein: 0);
            AddVanillaEntry(set, id: 4617, calories: 150, fat: 0, sodium: 0, carbs: 36, protein: 0);
            AddVanillaEntry(set, id: 5093, calories: 160, fat: 6, sodium: 30, carbs: 0, protein: 9);
            AddVanillaEntry(set, id: 4620, calories: 220, fat: 3, sodium: 50, carbs: 21, protein: 1);
            AddVanillaEntry(set, id: 4622, calories: 180, fat: 3, sodium: 4, carbs: 27, protein: 1);
            AddVanillaEntry(set, id: 4621, calories: 180, fat: 2, sodium: 30, carbs: 24, protein: 2);
            AddVanillaEntry(set, id: 4032, calories: 250, fat: 13, sodium: 205, carbs: 0, protein: 10);
            AddVanillaEntry(set, id: 4619, calories: 230, fat: 5, sodium: 14, carbs: 44, protein: 1);
            AddVanillaEntry(set, id: 4625, calories: 240, fat: 0, sodium: 6, carbs: 30, protein: 1);
            AddVanillaEntry(set, id: 4403, calories: 120, fat: 2, sodium: 230, carbs: 0, protein: 7);
            AddVanillaEntry(set, id: 2426, calories: 100, fat: 2, sodium: 135, carbs: 1, protein: 4);
            AddVanillaEntry(set, id: 2427, calories: 110, fat: 1, sodium: 125, carbs: 4, protein: 5);
            AddVanillaEntry(set, id: 4411, calories: 120, fat: 4, sodium: 210, carbs: 7, protein: 6);
            AddVanillaEntry(set, id: 2425, calories: 150, fat: 4, sodium: 110, carbs: 0, protein: 5);
            AddVanillaEntry(set, id: 4034, calories: 330, fat: 11, sodium: 250, carbs: 6, protein: 10);
            AddVanillaEntry(set, id: 5092, calories: 80, fat: 3, sodium: 300, carbs: 3, protein: 2);
            AddVanillaEntry(set, id: 2266, calories: 140, fat: 0, sodium: 2, carbs: 0, protein: 0);
            AddVanillaEntry(set, id: 2268, calories: 215, fat: 6, sodium: 150, carbs: 25, protein: 3);
            AddVanillaEntry(set, id: 2267, calories: 230, fat: 8, sodium: 100, carbs: 14, protein: 3);
            AddVanillaEntry(set, id: 3195, calories: 150, fat: 5, sodium: 50, carbs: 2, protein: 5);
            AddVanillaEntry(set, id: 5009, calories: 0, fat: 0, sodium: 0, carbs: 0, protein: 0);
            AddVanillaEntry(set, id: 1787, calories: 250, fat: 20, sodium: 130, carbs: 40, protein: 2);
            AddVanillaEntry(set, id: 1919, calories: 190, fat: 9, sodium: 15, carbs: 26, protein: 1);
            AddVanillaEntry(set, id: 1920, calories: 220, fat: 4, sodium: 105, carbs: 43, protein: 1);
            AddVanillaEntry(set, id: 1911, calories: 200, fat: 12, sodium: 130, carbs: 60, protein: 1);
            AddVanillaEntry(set, id: 4020, calories: 90, fat: 7, sodium: 95, carbs: 0, protein: 6);
            AddVanillaEntry(set, id: 5041, calories: 140, fat: 8, sodium: 90, carbs: 11, protein: 4);
            AddVanillaEntry(set, id: 4030, calories: 150, fat: 10, sodium: 200, carbs: 15, protein: 2);
            AddVanillaEntry(set, id: 4021, calories: 220, fat: 11, sodium: 250, carbs: 30, protein: 2);
            AddVanillaEntry(set, id: 4015, calories: 600, fat: 20, sodium: 450, carbs: 20, protein: 10);
            AddVanillaEntry(set, id: 4035, calories: 370, fat: 12, sodium: 400, carbs: 16, protein: 8);
            AddVanillaEntry(set, id: 5042, calories: 80, fat: 1, sodium: 32, carbs: 19, protein: 0);
            AddVanillaEntry(set, id: 4029, calories: 300, fat: 14, sodium: 400, carbs: 29, protein: 5);
            AddVanillaEntry(set, id: 4012, calories: 430, fat: 28, sodium: 250, carbs: 56, protein: 3);
            AddVanillaEntry(set, id: 4018, calories: 180, fat: 0, sodium: 60, carbs: 33, protein: 0);
            AddVanillaEntry(set, id: 4026, calories: 275, fat: 12, sodium: 103, carbs: 22, protein: 2);
            AddVanillaEntry(set, id: 4016, calories: 50, fat: 3, sodium: 90, carbs: 3, protein: 2);
            AddVanillaEntry(set, id: 4025, calories: 255, fat: 16, sodium: 145, carbs: 19, protein: 4);
            AddVanillaEntry(set, id: 4036, calories: 260, fat: 12, sodium: 240, carbs: 41, protein: 9);
            AddVanillaEntry(set, id: 4037, calories: 250, fat: 6, sodium: 118, carbs: 0, protein: 13);
            AddVanillaEntry(set, id: 3532, calories: 125, fat: 30, sodium: 255, carbs: 1, protein: 6);
            AddVanillaEntry(set, id: 4297, calories: 30, fat: 0, sodium: 2, carbs: 7, protein: 1);
            AddVanillaEntry(set, id: 4288, calories: 80, fat: 2, sodium: 0, carbs: 17, protein: 1);
            AddVanillaEntry(set, id: 4623, calories: 180, fat: 0, sodium: 50, carbs: 28, protein: 0);
            AddVanillaEntry(set, id: 4027, calories: 400, fat: 12, sodium: 140, carbs: 30, protein: 0);
            AddVanillaEntry(set, id: 4017, calories: 220, fat: 11, sodium: 140, carbs: 29, protein: 2);
            AddVanillaEntry(set, id: 4023, calories: 100, fat: 0, sodium: 3, carbs: 27, protein: 1);
            AddVanillaEntry(set, id: 4028, calories: 200, fat: 15, sodium: 400, carbs: 30, protein: 6);
            AddVanillaEntry(set, id: 4011, calories: 300, fat: 15, sodium: 200, carbs: 40, protein: 5);
            AddVanillaEntry(set, id: 4615, calories: 200, fat: 0, sodium: 10, carbs: 34, protein: 1);
            AddVanillaEntry(set, id: 4013, calories: 460, fat: 20, sodium: 400, carbs: 40, protein: 10);
            AddVanillaEntry(set, id: 4022, calories: 2000, fat: 70, sodium: 2300, carbs: 300, protein: 50);
            AddModdedEntry(set, mod: "FoodOverhaul", name: "Cheese", calories: 100, fat: 9, sodium: 180, carbs: 2, protein: 7);
            AddModdedEntry(set, mod: "FoodOverhaul", name: "RoastedAcorn", calories: 50, fat: 7, sodium: 60, carbs: 0, protein: 2);
            AddModdedEntry(set, mod: "FoodOverhaul", name: "MushroomStew", calories: 150, fat: 5, sodium: 100, carbs: 30, protein: 3);
            AddModdedEntry(set, mod: "FoodOverhaul", name: "GlowingMushroomStew", calories: 150, fat: 5, sodium: 230, carbs: 3, protein: 3);
            AddModdedEntry(set, mod: "FoodOverhaul", name: "VileMushroomStew", calories: 150, fat: 5, sodium: 100, carbs: 3, protein: 7);
            AddModdedEntry(set, mod: "FoodOverhaul", name: "ViciousMushroomStew", calories: 150, fat: 12, sodium: 100, carbs: 3, protein: 3);

            return set;
        }

        private static void AddVanillaEntry(HashSet<ItemNutritionPair> set, int id, int calories = 0, int fat = 0, int sodium = 0, int carbs = 0, int protein = 0)
        {
            set.Add(new ItemNutritionPair(id, new NutritionData(calories, fat, sodium, carbs, protein)));
        }

        private static void AddModdedEntry(HashSet<ItemNutritionPair> set, string mod, string name, int calories = 0, int fat = 0, int sodium = 0, int carbs = 0, int protein = 0)
        {
            ItemNutritionPair pair = null; 
            if (ModLoader.TryGetMod(mod, out Mod modInstance))
            {
                foreach (ModItem item in modInstance.GetContent<ModItem>())
                {
                    if (item.Name.Equals(name))
                    {
                        pair = new ItemNutritionPair(mod, name, new(calories, fat, sodium, carbs, protein));
                    }
                }
            }
            if (pair != null)
            {
                set.Add(pair);
            }
        }
    }

}

