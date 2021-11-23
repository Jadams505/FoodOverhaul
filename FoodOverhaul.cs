using Terraria.ModLoader;
using Terraria;
using FoodOverhaul.Util;

namespace FoodOverhaul
{
	public class FoodOverhaul : Mod
	{
        public override void Load()
        {
            KeybindManager.AddAllKeybinds(this);
        }
    }
}