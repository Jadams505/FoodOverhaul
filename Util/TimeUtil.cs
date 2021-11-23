namespace FoodOverhaul.Util
{
    public class TimeUtil
    {
        public static int FRAMES = 60;
        public static int Seconds(int seconds)
        {
            return seconds * FRAMES;
        }

        public static int Minutes(int minutes)
        {
            return Seconds(minutes * 60);
        }

        public static int Time(int minutes, int seconds)
        {
            return Seconds(seconds) + Minutes(minutes);
        }
    }
}
