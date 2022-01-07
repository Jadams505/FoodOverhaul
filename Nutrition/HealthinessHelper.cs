
namespace FoodOverhaul.Nutrition
{
    public static class HealthinessHelper
    {
        public enum Status
        {
            TOO_HIGH,
            NEEDS_MONITORING,
            HEALTHY,
            GETTING_LOW,
            TOO_LOW
        }
        public const int TARGET_CALORIES = 2000;
        public const int TARGET_FAT = 70;
        public const int TARGET_SODIUM = 2300;
        public const int TARGET_CARBS = 300;
        public const int TARGET_PROTEIN = 50;

        public const float HEATHY_BUFFER = 0.5f; // 50%

        public static Status CalorieStatus(float calories)
        {
            return Range(calories, TARGET_CALORIES * (1 - HEATHY_BUFFER), TARGET_CALORIES * (1 + HEATHY_BUFFER));
        }

        public static Status FatStatus(float fat)
        {
            return Range(fat, TARGET_FAT * (1 - HEATHY_BUFFER), TARGET_FAT * (1 + HEATHY_BUFFER));
        }

        public static Status SodiumStatus(float sodium)
        {
            return Range(sodium, TARGET_SODIUM * (1 - HEATHY_BUFFER), TARGET_SODIUM * (1 + HEATHY_BUFFER));
        }

        public static Status CarbStatus(float carbs)
        {
            return Range(carbs, TARGET_CARBS * (1 - HEATHY_BUFFER), TARGET_CARBS * (1 + HEATHY_BUFFER));
        }

        public static Status ProteinStatus(float protein)
        {
            return Range(protein, TARGET_PROTEIN * (1 - HEATHY_BUFFER), TARGET_PROTEIN * (1 + HEATHY_BUFFER));
        }

        public static bool IsHealthy(PlayerNutritionData data)
        {
            return CalorieStatus(data.Calories) == Status.HEALTHY && FatStatus(data.Fat) == Status.HEALTHY && 
                SodiumStatus(data.Sodium) == Status.HEALTHY && CarbStatus(data.Carbs) == Status.HEALTHY &&
                ProteinStatus(data.Protein) == Status.HEALTHY;
        }

        public static int GetNumberOfHealthyValues(PlayerNutritionData data)
        {
            int count = 0;
            count += CalorieStatus(data.Calories) == Status.HEALTHY ? 1 : 0;
            count += FatStatus(data.Fat) == Status.HEALTHY ? 1 : 0;
            count += SodiumStatus(data.Sodium) == Status.HEALTHY ? 1 : 0;
            count += CarbStatus(data.Carbs) == Status.HEALTHY ? 1 : 0;
            count += ProteinStatus(data.Protein) == Status.HEALTHY ? 1 : 0;
            return count;
        }

        private static Status Range(float val, float min, float max)
        {
            if (val < min)
            {
                return Status.TOO_LOW;
            }
            if (val > max)
            {
                return Status.TOO_HIGH;
            }
            return Status.HEALTHY;
        }

    }
}
