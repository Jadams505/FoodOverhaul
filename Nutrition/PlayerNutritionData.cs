using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOverhaul;

namespace FoodOverhaul.Nutrition
{
    public class PlayerNutritionData
    {
        public float Calories;
        public float Fat;
        public float Sodium;
        public float Carbs;
        public float Protein;

        public PlayerNutritionData(NutritionData data)
        {
            Calories = data.Calories;
            Fat = data.Fat;
            Sodium = data.Sodium;
            Carbs = data.Carbs;
            Protein = data.Protein;
        }

        public PlayerNutritionData(float calories, float fat, float sodium, float carbs, float protein)
        {
            Calories = calories;
            Fat = fat;
            Sodium = sodium;
            Carbs = carbs;
            Protein = protein;
        }

        private static float ToBounds(float num)
        {
            return Math.Clamp(num, 0, NutritionData.MAX);
        }
        public void Decrement()
        {
            Protein = ToBounds(Protein - HealthinessHelper.TARGET_PROTEIN / 100f);
            Calories = ToBounds(Calories - HealthinessHelper.TARGET_CALORIES / 100f);
            Carbs = ToBounds(Carbs - HealthinessHelper.TARGET_CARBS / 100f);
            Sodium = ToBounds(Sodium - HealthinessHelper.TARGET_SODIUM / 100f);
            Fat = ToBounds(Fat - HealthinessHelper.TARGET_FAT / 100f);
        }

        public void Add(ref NutritionData data)
        {
            Protein = ToBounds(Protein + data.Protein);
            Fat = ToBounds(Fat + data.Fat);
            Carbs = ToBounds(Carbs + data.Carbs);
            Calories = ToBounds(Calories + data.Calories);
            Sodium = ToBounds(Sodium + data.Sodium);
        }

        public bool Empty()
        {
            return Calories == 0 && Carbs == 0 && Fat == 0 && Sodium == 0 && Protein == 0;
        }
    }
}
