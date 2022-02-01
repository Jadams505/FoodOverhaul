using Terraria.ModLoader;
using FoodOverhaul.Util;
using Terraria;
using Terraria.Localization;
using Terraria.ID;
using FoodOverhaul.Tiles;
using FoodOverhaul.WorldGen.Trees;

namespace FoodOverhaul
{
	public class FoodOverhaul : Mod
	{

        public override void AddRecipeGroups()
        {
            RecipeGroup bowls = new(() => Language.GetTextValue("LegacyMisc.37") + " Bowl", new int[]
            {
                ItemID.Bowl,
                ItemID.DynastyBowl,
                ItemID.GlassBowl
            });
            RecipeGroup.RegisterGroup("FoodOverhaul:Bowls", bowls);
        }
        public override void Load()
        {
            KeybindManager.AddAllKeybinds(this);
        }

        public override void Unload()
        {
        }
    }
}