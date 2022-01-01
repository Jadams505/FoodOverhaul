using Terraria.UI;
using Terraria.ModLoader.UI;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;

namespace FoodOverhaul.UI
{
    public class NutritionBubblesUI
    {

        private static UserInterface _interface;
        private static DragableContainer _panel;
        private static NutritionBubble _calories, _fat, _sodium, _carbs, _protein;
        private static UIState _state;

        public static bool Enabled { get; private set; }

        public static void Initialize()
        {
            Enabled = false;
            _interface = new();

            

            _calories = new NutritionBubble("Calories", NutritionData.CALORIES_COLOR, 0, 3000);
            _calories.HAlign = 0.1f;

            _fat = new NutritionBubble("Fat", NutritionData.FAT_COLOR, 0, 90);
            _fat.HAlign = 0.3f;

            _sodium = new NutritionBubble("Sodium", NutritionData.SODIUM_COLOR, 0, 3000);
            _sodium.HAlign = 0.5f;

            _carbs = new NutritionBubble("Carbs", NutritionData.CARBS_COLOR, 0, 400);
            _carbs.HAlign = 0.7f;

            _protein = new NutritionBubble("Protein", NutritionData.PROTEIN_COLOR, 0, 75);
            _protein.HAlign = 0.9f;

            _panel = new DragableContainer();
            _panel.Width.Set(_calories.Width.Pixels * 6, 0);
            _panel.Height.Set(_calories.Width.Pixels, 0);

            
            _panel.Append(_calories);
            _panel.Append(_fat);
            _panel.Append(_sodium);
            _panel.Append(_protein);
            _panel.Append(_carbs);

            _state = new();
            _state.Append(_panel);
        }

        public static void UpdateNutrition(NutritionData data)
        {
            _calories.UpdateValue(data.Calories);
            _fat.UpdateValue(data.Fat);
            _sodium.UpdateValue(data.Sodium);
            _carbs.UpdateValue(data.Carbs);
            _protein.UpdateValue(data.Protein);
        }

        public static void Update(GameTime time)
        {
            if (Enabled)
            {
                _interface.Update(time);
                UpdateConfig();
            }
        }

        public static void UpdateConfig()
        {
            NutritionClientConfig config = NutritionClientConfig.Get();
            if (config != null)
            {
                config.UIPosX = (int)_panel.Left.Pixels;
                config.UIPosY = (int)_panel.Top.Pixels;
            }
        }

        public static void UpdatePanel(int x, int y)
        {
            if(_panel != null)
            {
                _panel.Left.Set(x, 0);
                _panel.Top.Set(y, 0);
            }
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
            _calories = null;
            _fat = null;
            _sodium = null;
            _carbs = null;
            _protein = null;
            _interface = null;
            _state = null;
            _panel = null;
            Enabled = false;
        }

        public static bool DrawGUI(GameTime time)
        {
            if (_interface?.CurrentState != null)
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
