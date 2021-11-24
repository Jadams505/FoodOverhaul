using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Terraria;
using FoodOverhaul.Classes;
using Terraria.ID;

namespace FoodOverhaul.UI
{
    public class NutritionPanel : UIElement
    {
        public static readonly Color PROTEIN_COLOR = Colors.RarityPurple;
        public static readonly Color FRUIT_COLOR = Colors.RarityRed;
        public static readonly Color VEGETABLES_COLOR = Colors.RarityGreen;
        public static readonly Color DAIRY_COLOR = Colors.RarityBlue;
        public static readonly Color CARBS_COLOR = Colors.RarityOrange;

        private bool _selected;

        public UIText Protein, Carbs, Vegetables, Fruits, Dairy;

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
            Vegetables = new("");
            Fruits = new("");
            Dairy = new("");

            Fruits.VAlign = 0.2f;
            Vegetables.VAlign = 0.4f;
            Protein.VAlign = 0.6f;
            Carbs.VAlign = 0.8f;
            Dairy.VAlign = 1f;

            Protein.TextColor = PROTEIN_COLOR;
            Carbs.TextColor = CARBS_COLOR;
            Vegetables.TextColor = VEGETABLES_COLOR;
            Fruits.TextColor = FRUIT_COLOR;
            Dairy.TextColor = DAIRY_COLOR;

            UpdateNutrition(new Nutrition());

            
            panel.Append(title);
            panel.Append(Fruits);
            panel.Append(Vegetables);
            panel.Append(Protein);
            panel.Append(Carbs);
            panel.Append(Dairy);
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

        public void UpdateNutrition(Nutrition nutrition)
        {
            Fruits.SetText(nutrition.Fruits.ToString());
            Vegetables.SetText(nutrition.Vegatables.ToString());
            Protein.SetText(nutrition.Protein.ToString());
            Carbs.SetText(nutrition.Carbs.ToString());
            Dairy.SetText(nutrition.Dairy.ToString());
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
