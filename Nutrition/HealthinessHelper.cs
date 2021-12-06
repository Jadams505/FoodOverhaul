
namespace FoodOverhaul.Nutrition
{
    public class HealthinessHelper
    {
        public enum Status
        {
            TOO_HIGH,
            NEEDS_MONITORING,
            HEALTHY,
            GETTING_LOW,
            TOO_LOW
        } 

        public static Status CalorieStatus(int calories)
        {
            return Range(calories, 1500, 3000);
        }

        public static Status FatStatus(int fat)
        {
            return Range(fat, 40, 90);
        }

        public static Status SodiumStatus(int sodium)
        {
            return Range(sodium, 1000, 3000);
        }

        public static Status CarbStatus(int carbs)
        {
            return Range(carbs, 175, 400);
        }

        public static Status ProteinStatus(int protein)
        {
            return Range(protein, 25, 75);
        }

        public static bool IsHealthy(NutritionData data)
        {
            return CalorieStatus(data.Calories) == Status.HEALTHY && FatStatus(data.Fat) == Status.HEALTHY && 
                SodiumStatus(data.Sodium) == Status.HEALTHY && CarbStatus(data.Carbs) == Status.HEALTHY &&
                ProteinStatus(data.Protein) == Status.HEALTHY;
        }


        private static Status Range(int val, int min, int max)
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
