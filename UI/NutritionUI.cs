using Microsoft.Xna.Framework;
using Terraria.UI;
using Terraria;
using Terraria.ModLoader;
using FoodOverhaul.Classes;
using System;

namespace FoodOverhaul.UI
{
    public class NutritionUI
    {
        private static UserInterface _interface;

        private static NutritionPanel _panel;
        private static UIState _state;

        public static bool Enabled { get; private set; }

        public static void Initialize()
        {
            Enabled = false;
            _interface = new();
            _panel = new();
            _panel.Activate();
            _state = new();
            _state.Append(_panel);
        }

        public static void Update(GameTime time)
        {
            if (Enabled)
            {
                FoodOverhaulPlayer player = FoodOverhaulPlayer.GetModPlayer();
                _panel.UpdateNutrition(player != null ? player.nutrition : new());
                _interface.Update(time);
            }
        }

        public static void UpdateNutrition(Nutrition nutrition)
        {
            _panel.UpdateNutrition(nutrition);
        }

        public static void Load()
        {
            if (!Main.dedServ)
            {
                Initialize();
            }
        }

        public static void Unload()
        {
            _panel = null;
            _interface = null;
            _state = null;
            Enabled = false;
        }

        public static bool DrawGUI(GameTime time)
        {
            if(_interface?.CurrentState != null)
            {
                _interface.Draw(Main.spriteBatch, time);
            }
            return true;
        }

        public static void Toggle()
        {
            Enabled = !Enabled;
            if (Enabled)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private static void Show()
        {
            _interface?.SetState(_state);
        }

        private static void Hide()
        {
            _interface?.SetState(null);
        }
    }
}
