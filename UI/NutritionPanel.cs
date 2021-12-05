using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace FoodOverhaul.UI
{
    public class NutritionPanel : UIElement
    {

        private bool _selected;

        public UIText Protein, Carbs, Calories, Sodium, Fat;

        public override void OnInitialize()
        {
            _selected = false;
            Width.Set(200, 0);
            Height.Set(200, 0);

            UIPanel panel = new();
            panel.Width.Set(200, 0);
            panel.Height.Set(200, 0);
            Append(panel);

            UIText title = new("Nutrition Facts");
            Protein = new("");
            Carbs = new("");
            Fat = new("");
            Calories = new("");
            Sodium = new("");

            Calories.VAlign = 0.2f;
            Fat.VAlign = 0.4f;
            Sodium.VAlign = 0.6f;
            Carbs.VAlign = 0.8f;
            Protein.VAlign = 1f;

            Protein.TextColor = NutritionData.PROTEIN_COLOR;
            Carbs.TextColor = NutritionData.CARBS_COLOR;
            Fat.TextColor = NutritionData.FAT_COLOR;
            Calories.TextColor = NutritionData.CALORIES_COLOR;
            Sodium.TextColor = NutritionData.SODIUM_COLOR;

            UpdateNutrition(new());

            
            panel.Append(title);
            panel.Append(Fat);
            panel.Append(Sodium);
            panel.Append(Protein);
            panel.Append(Carbs);
            panel.Append(Calories);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawChildren(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (this.IsMouseHovering)
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (_selected)
            {

                this.Left.Set(this.Left.Pixels + (Main.mouseX - Main.lastMouseX), 0);
                this.Top.Set(this.Top.Pixels + (Main.mouseY - Main.lastMouseY), 0);
            }
            base.Update(gameTime);
        }

        public void UpdateNutrition(NutritionData nutrition)
        {
            Calories.SetText(nutrition.Calories + " Calories");
            Fat.SetText(nutrition.Fat + " Fat");
            Sodium.SetText(nutrition.Sodium + " Sodium");
            Carbs.SetText(nutrition.Carbs + " Carbs");
            Protein.SetText(nutrition.Protein + " Protein");
        }

        public override void MouseDown(UIMouseEvent evt)
        {
            _selected = true;
        }

        public override void MouseUp(UIMouseEvent evt)
        {
            _selected = false;
        }
    }
}
