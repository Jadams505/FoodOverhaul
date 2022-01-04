using Terraria.UI;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace FoodOverhaul.UI
{
    public class ModInterface : ModSystem
    {
        private static GameTime _lastUpdate;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                NutritionBubblesUI.Load();
            }
        }

        public override void Unload()
        {
            NutritionBubblesUI.Unload();
        }

        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdate = gameTime;
            NutritionBubblesUI.Update(gameTime);
        }

        private static bool DrawGUI()
        {
            NutritionBubblesUI.DrawGUI(_lastUpdate);
            return true;
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int InventoryLayer = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (InventoryLayer != -1)
            {
                layers.Insert(InventoryLayer, new LegacyGameInterfaceLayer(
                    "FoodOverhaul: Nutrition Layer", DrawGUI, InterfaceScaleType.UI));
            }
        }

    }
}
