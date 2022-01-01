using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;

namespace FoodOverhaul.Util
{
    public class KeybindManager
    {

        public static ModKeybind debug;
        public static ModKeybind toggleNutrition;
        public static ModKeybind toggleStats;
        public static void AddAllKeybinds(Mod mod)
        {
            debug = KeybindLoader.RegisterKeybind(mod, "DEBUG", Keys.L);
            toggleNutrition = KeybindLoader.RegisterKeybind(mod, "Nutrition UI", Keys.N);
            toggleStats = KeybindLoader.RegisterKeybind(mod, "Nutrition Stats", Keys.P);
        }

    }
}
