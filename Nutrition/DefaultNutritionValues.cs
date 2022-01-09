using Terraria.ID;
using System.Collections.Generic;
using FoodOverhaul.Items.Food;
using Terraria.ModLoader;

namespace FoodOverhaul.Nutrition
{
    public class DefaultNutritionValues
    {
        public static HashSet<ItemNutritionPair> RealisticDefault()
        {
            HashSet<ItemNutritionPair> set = new();

            //Vanilla Foods

            set.Add(VanillaEntry(id: 4009, calories: 100, fat: 0, sodium: 2, carbs: 25, protein: 0));
            set.Add(VanillaEntry(id: 4282, calories: 75, fat: 1, sodium: 2, carbs: 17, protein: 2));
            set.Add(VanillaEntry(id: 4290, calories: 130, fat: 1, sodium: 0, carbs: 33, protein: 3));
            set.Add(VanillaEntry(id: 4291, calories: 60, fat: 1, sodium: 3, carbs: 19, protein: 2));
            set.Add(VanillaEntry(id: 4293, calories: 65, fat: 0, sodium: 20, carbs: 15, protein: 1));
            set.Add(VanillaEntry(id: 4286, calories: 100, fat: 0, sodium: 0, carbs: 24, protein: 2));
            set.Add(VanillaEntry(id: 4295, calories: 70, fat: 0, sodium: 0, carbs: 18, protein: 1));
            set.Add(VanillaEntry(id: 4283, calories: 100, fat: 0, sodium: 1, carbs: 29, protein: 2));
            set.Add(VanillaEntry(id: 4284, calories: 50, fat: 0, sodium: 0, carbs: 13, protein: 0));
            set.Add(VanillaEntry(id: 4285, calories: 50, fat: 0, sodium: 0, carbs: 12, protein: 0));
            set.Add(VanillaEntry(id: 4287, calories: 230, fat: 10, sodium: 5, carbs: 4, protein: 1));
            set.Add(VanillaEntry(id: 4289, calories: 105, fat: 1, sodium: 9, carbs: 27, protein: 1));
            set.Add(VanillaEntry(id: 4292, calories: 125, fat: 1, sodium: 2, carbs: 31, protein: 2));
            set.Add(VanillaEntry(id: 4294, calories: 80, fat: 0, sodium: 2, carbs: 22, protein: 1));
            set.Add(VanillaEntry(id: 4296, calories: 120, fat: 0, sodium: 17, carbs: 31, protein: 1));
            set.Add(VanillaEntry(id: 357, calories: 95, fat: 6, sodium: 830, carbs: 8, protein: 2));
            set.Add(VanillaEntry(id: 967, calories: 25, fat: 0, sodium: 6, carbs: 6, protein: 0));
            set.Add(VanillaEntry(id: 4014, calories: 200, fat: 11, sodium: 760, carbs: 15, protein: 9));
            set.Add(VanillaEntry(id: 4024, calories: 240, fat: 7, sodium: 170, carbs: 0, protein: 43));
            set.Add(VanillaEntry(id: 969, calories: 25, fat: 0, sodium: 6, carbs: 6, protein: 0));
            set.Add(VanillaEntry(id: 353, calories: 70, fat: 0, sodium: 24, carbs: 17, protein: 0));
            set.Add(VanillaEntry(id: 4031, calories: 200, fat: 12, sodium: 500, carbs: 5, protein: 18));
            set.Add(VanillaEntry(id: 4033, calories: 80, fat: 0, sodium: 3, carbs: 0, protein: 18));
            set.Add(VanillaEntry(id: 4019, calories: 50, fat: 1, sodium: 150, carbs: 1, protein: 10));
            set.Add(VanillaEntry(id: 4024, calories: 100, fat: 0, sodium: 130, carbs: 26, protein: 0));
            set.Add(VanillaEntry(id: 4614, calories: 100, fat: 0, sodium: 8, carbs: 24, protein: 0));
            set.Add(VanillaEntry(id: 4616, calories: 120, fat: 0, sodium: 14, carbs: 30, protein: 0));
            set.Add(VanillaEntry(id: 4618, calories: 200, fat: 0, sodium: 23, carbs: 19, protein: 0));
            set.Add(VanillaEntry(id: 4617, calories: 150, fat: 0, sodium: 0, carbs: 39, protein: 0));
            set.Add(VanillaEntry(id: 5093, calories: 200, fat: 12, sodium: 360, carbs: 30, protein: 22));
            set.Add(VanillaEntry(id: 4032, calories: 250, fat: 21, sodium: 700, carbs: 2, protein: 14));
            set.Add(VanillaEntry(id: 4619, calories: 340, fat: 5, sodium: 14, carbs: 44, protein: 1));
            set.Add(VanillaEntry(id: 4620, calories: 100, fat: 0, sodium: 50, carbs: 21, protein: 3));
            set.Add(VanillaEntry(id: 4621, calories: 155, fat: 1, sodium: 470, carbs: 3, protein: 2));
            set.Add(VanillaEntry(id: 4622, calories: 110, fat: 0, sodium: 4, carbs: 27, protein: 1));
            set.Add(VanillaEntry(id: 4625, calories: 80, fat: 0, sodium: 6, carbs: 20, protein: 1));
            set.Add(VanillaEntry(id: 2425, calories: 150, fat: 4, sodium: 110, carbs: 0, protein: 28));
            set.Add(VanillaEntry(id: 2426, calories: 100, fat: 2, sodium: 800, carbs: 1, protein: 19));
            set.Add(VanillaEntry(id: 2427, calories: 110, fat: 1, sodium: 125, carbs: 4, protein: 21));
            set.Add(VanillaEntry(id: 4403, calories: 80, fat: 0, sodium: 400, carbs: 0, protein: 16));
            set.Add(VanillaEntry(id: 4411, calories: 120, fat: 4, sodium: 211, carbs: 7, protein: 14));
            set.Add(VanillaEntry(id: 4034, calories: 330, fat: 11, sodium: 600, carbs: 47, protein: 10));
            set.Add(VanillaEntry(id: 5092, calories: 350, fat: 12, sodium: 1000, carbs: 40, protein: 19));
            set.Add(VanillaEntry(id: 2266, calories: 140, fat: 0, sodium: 2, carbs: 0, protein: 0));
            set.Add(VanillaEntry(id: 2267, calories: 300, fat: 15, sodium: 770, carbs: 29, protein: 16));
            set.Add(VanillaEntry(id: 2268, calories: 215, fat: 6, sodium: 980, carbs: 25, protein: 15));
            set.Add(VanillaEntry(id: 3195, calories: 150, fat: 5, sodium: 200, carbs: 10, protein: 11));
            set.Add(VanillaEntry(id: 1787, calories: 2000, fat: 75, sodium: 1000, carbs: 300, protein: 20));
            set.Add(VanillaEntry(id: 5009, calories: 0, fat: 0, sodium: 0, carbs: 0, protein: 0));
            set.Add(VanillaEntry(id: 1911, calories: 360, fat: 12, sodium: 350, carbs: 60, protein: 5));
            set.Add(VanillaEntry(id: 1919, calories: 190, fat: 9, sodium: 15, carbs: 26, protein: 1));
            set.Add(VanillaEntry(id: 1920, calories: 220, fat: 4, sodium: 245, carbs: 43, protein: 4));
            set.Add(VanillaEntry(id: 4020, calories: 90, fat: 7, sodium: 95, carbs: 0, protein: 6));
            set.Add(VanillaEntry(id: 5041, calories: 140, fat: 8, sodium: 90, carbs: 11, protein: 8));
            set.Add(VanillaEntry(id: 4015, calories: 600, fat: 33, sodium: 900, carbs: 47, protein: 31));
            set.Add(VanillaEntry(id: 4021, calories: 220, fat: 11, sodium: 134, carbs: 30, protein: 3));
            set.Add(VanillaEntry(id: 4030, calories: 150, fat: 10, sodium: 150, carbs: 15, protein: 2));
            set.Add(VanillaEntry(id: 4035, calories: 370, fat: 12, sodium: 1800, carbs: 41, protein: 23));
            set.Add(VanillaEntry(id: 4012, calories: 965, fat: 34, sodium: 400, carbs: 150, protein: 12));
            set.Add(VanillaEntry(id: 5042, calories: 80, fat: 1, sodium: 32, carbs: 19, protein: 0));
            set.Add(VanillaEntry(id: 4029, calories: 300, fat: 14, sodium: 600, carbs: 29, protein: 11));
            set.Add(VanillaEntry(id: 4018, calories: 180, fat: 0, sodium: 60, carbs: 47, protein: 0));
            set.Add(VanillaEntry(id: 4026, calories: 300, fat: 15, sodium: 103, carbs: 38, protein: 5));
            set.Add(VanillaEntry(id: 4016, calories: 50, fat: 3, sodium: 90, carbs: 3, protein: 2));
            set.Add(VanillaEntry(id: 4025, calories: 350, fat: 16, sodium: 630, carbs: 34, protein: 16));
            set.Add(VanillaEntry(id: 4036, calories: 400, fat: 12, sodium: 1000, carbs: 41, protein: 14));
            set.Add(VanillaEntry(id: 4037, calories: 250, fat: 6, sodium: 118, carbs: 0, protein: 49));
            set.Add(VanillaEntry(id: 3532, calories: 370, fat: 30, sodium: 1200, carbs: 1, protein: 26));
            set.Add(VanillaEntry(id: 4288, calories: 80, fat: 2, sodium: 0, carbs: 17, protein: 1));
            set.Add(VanillaEntry(id: 4297, calories: 30, fat: 0, sodium: 2, carbs: 7, protein: 1));
            set.Add(VanillaEntry(id: 4623, calories: 180, fat: 0, sodium: 50, carbs: 46, protein: 0));
            set.Add(VanillaEntry(id: 4027, calories: 400, fat: 12, sodium: 140, carbs: 74, protein: 7));
            set.Add(VanillaEntry(id: 4017, calories: 220, fat: 11, sodium: 140, carbs: 29, protein: 2));
            set.Add(VanillaEntry(id: 4011, calories: 1880, fat: 60, sodium: 1200, carbs: 250, protein: 14));
            set.Add(VanillaEntry(id: 4028, calories: 450, fat: 28, sodium: 413, carbs: 46, protein: 6));
            set.Add(VanillaEntry(id: 4023, calories: 100, fat: 9, sodium: 3, carbs: 27, protein: 1));
            set.Add(VanillaEntry(id: 4615, calories: 125, fat: 0, sodium: 10, carbs: 31, protein: 1));
            set.Add(VanillaEntry(id: 4013, calories: 460, fat: 20, sodium: 1100, carbs: 40, protein: 21));
            set.Add(VanillaEntry(id: 4022, calories: 2000, fat: 60, sodium: 500, carbs: 50, protein: 40));


            //Modded Foods

            foreach (ModFood food in ModContent.GetContent<ModFood>())
            {
                set.Add(new ItemNutritionPair(food.Type, food.GetNutrition()));
            }
            return set;
        }

        private static ItemNutritionPair VanillaEntry(int id, int calories = 0, int fat = 0, int sodium = 0, int carbs = 0, int protein = 0)
        {
            return new ItemNutritionPair(id, new NutritionData(calories, fat, sodium, carbs, protein));
        }
    }

}

