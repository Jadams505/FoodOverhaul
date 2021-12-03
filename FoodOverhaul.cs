using Terraria.ModLoader;
using FoodOverhaul.Util;

namespace FoodOverhaul
{
	public class FoodOverhaul : Mod
	{
        public override void Load()
        {
            KeybindManager.AddAllKeybinds(this);
        }

        public override void Unload()
        {
        }
    }
}