using System;
namespace FoodOverhaul.Util
{
    public class NutritionHelper
    {
        private static int ToBounds(int num)
        {
            return Math.Clamp(num, 0, NutritionData.MAX);
        }
        public static void Decrement(ref NutritionData data)
        {
            data.Protein = ToBounds(data.Protein - 1);
            data.Fruits = ToBounds(data.Fruits - 1);
            data.Carbs = ToBounds(data.Carbs - 1);
            data.Dairy = ToBounds(data.Dairy - 1);
            data.Vegetables = ToBounds(data.Vegetables - 1);
        }

        public static void Add(ref NutritionData first, ref NutritionData second)
        {
            first.Protein = ToBounds(first.Protein + second.Protein);
            first.Fruits = ToBounds(first.Fruits + second.Fruits);
            first.Carbs = ToBounds(first.Carbs + second.Carbs);
            first.Dairy = ToBounds(first.Dairy + second.Dairy);
            first.Vegetables = ToBounds(first.Vegetables + second.Vegetables);
        }

        public static bool Empty(ref NutritionData data)
        {
            return data.Fruits == 0 && data.Carbs == 0 && data.Dairy == 0 && data.Vegetables == 0 && data.Protein == 0;
        }

        public static NutritionData Full()
        {
            return new NutritionData(NutritionData.MAX, NutritionData.MAX, NutritionData.MAX, NutritionData.MAX, NutritionData.MAX);
        }
    }
}
