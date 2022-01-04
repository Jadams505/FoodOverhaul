using Terraria.UI;
using Microsoft.Xna.Framework;
using Terraria;
using FoodOverhaul.Nutrition;

namespace FoodOverhaul.UI
{
    public class NutritionBubblesUI
    {

        private static UserInterface _interface;
        private static DragableContainer _panel;
        private static NutritionBubble _calories, _fat, _sodium, _carbs, _protein;
        private static UIState _state;

        public static bool Horizontal { get; set; }
        public static bool Enabled { get; private set; }

        public static void Initialize()
        {
            Enabled = false;
            Horizontal = true;
            _interface = new();

            _calories = new NutritionBubble("Calories", NutritionData.CALORIES_COLOR, 0, HealthinessHelper.TARGET_CALORIES);
            _fat = new NutritionBubble("Fat", NutritionData.FAT_COLOR, 0, HealthinessHelper.TARGET_FAT);
            _sodium = new NutritionBubble("Sodium", NutritionData.SODIUM_COLOR, 0, HealthinessHelper.TARGET_SODIUM);
            _carbs = new NutritionBubble("Carbs", NutritionData.CARBS_COLOR, 0, HealthinessHelper.TARGET_CARBS);
            _protein = new NutritionBubble("Protein", NutritionData.PROTEIN_COLOR, 0, HealthinessHelper.TARGET_PROTEIN);
            _panel = new DragableContainer();

            SwitchOrientation(Horizontal);
            
            _panel.Append(_calories);
            _panel.Append(_fat);
            _panel.Append(_sodium);
            _panel.Append(_protein);
            _panel.Append(_carbs);

            _state = new();
            _state.Append(_panel);
        }

        public static void UpdateNutrition(PlayerNutritionData data)
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
                LockPosition(NutritionClientConfig.Get().UIPositionLocked);
                SwitchOrientation(NutritionClientConfig.Get().DisplayUIHorizontally);
                ShowPercent(NutritionClientConfig.Get().DisplayPercents);
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

        public static void LockPosition(bool lockPostion)
        {
            if(_panel != null)
            {
                _panel.Lock(lockPostion);
            }
        }

        public static void SwitchOrientation(bool horizontal)
        {
            Horizontal = horizontal;
            if(_panel == null)
            {
                return;
            }
            AlignBubbles();
            if (Horizontal)
            {
                _panel.Width.Set(_calories.Width.Pixels * 6, 0);
                _panel.Height.Set(_calories.Width.Pixels, 0);
            }
            else
            {
                _panel.Height.Set(_calories.Width.Pixels * 6, 0);
                _panel.Width.Set(_calories.Width.Pixels, 0);
            }
        }

        public static void ShowPercent(bool showPercent)
        {
            if(_carbs != null)
            {
                _carbs.ShowPercent = showPercent;
            }
            if(_calories != null)
            {
                _calories.ShowPercent = showPercent;
            }
            if(_fat != null)
            {
                _fat.ShowPercent = showPercent;
            }
            if(_protein != null)
            {
                _protein.ShowPercent = showPercent;
            }
            if(_sodium != null)
            {
                _sodium.ShowPercent = showPercent;
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
            _panel.Unselect();
            _interface?.SetState(null);
        }

        public static void AlignBubbles()
        {
            ApplyOrientation(ref _calories, 0.1f);
            ApplyOrientation(ref _fat, 0.3f);
            ApplyOrientation(ref _sodium, 0.5f);
            ApplyOrientation(ref _carbs, 0.7f);
            ApplyOrientation(ref _protein, 0.9f);
        }
        private static void ApplyOrientation(ref NutritionBubble element, float value)
        {
            if(element == null)
            {
                return;
            }
            element.TextAlignment = NutritionClientConfig.Get().LabelTextPosition;
            if (Horizontal)
            {
                element.HAlign = value;
            }
            else
            {
                element.VAlign = value;
            }
        }
    }
}
