using Terraria;
using Microsoft.Xna.Framework;

namespace FoodOverhaul.Util
{
    public class ChatUtil
    {

        public static void Info(object message)
        {
            Main.NewText(message);
        }

        public static void Debug(object message)
        {
            Main.NewText(message, Color.Red);
        }

        public static void Message(string message, Color color)
        {
            Main.NewText(message, color);
        }

    }
}
