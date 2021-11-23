using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Terraria;
using FoodOverhaul.Classes;

namespace FoodOverhaul.UI
{
    public class NutritionBar : UIElement
    {
        private bool _selected;

        public UIText Protein, Carbs, Vegetables, Fruits, Dairy;


        public override void OnInitialize()
        {
            _selected = false;
            Width.Set(200, 0);
            Height.Set(200, 0);

            UIPanel panel = new UIPanel();
            panel.Width.Set(200, 0);
            panel.Height.Set(200, 0);
            Append(panel);

            UIText title = new UIText("Nutrition Facts");
            Protein = new UIText("Protein");
            Protein.VAlign = 0.2f;
            Carbs = new UIText("Carbs");
            Carbs.VAlign = 0.4f;
            Vegetables = new UIText("Vegatables");
            Vegetables.VAlign = 0.6f;
            Fruits = new UIText("Fruits");
            Fruits.VAlign = 0.8f;
            Dairy = new UIText("Dairy");
            Dairy.VAlign = 1f;

            UpdateNutrition(new Nutrition());

            
            panel.Append(title);
            panel.Append(Protein);
            panel.Append(Carbs);
            panel.Append(Vegetables);
            panel.Append(Fruits);
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
            Protein.SetText("Protein " + nutrition.protein);
            Carbs.SetText("Carbs " + nutrition.carbs);
            Vegetables.SetText("Vegetables " + nutrition.vegatable);
            Fruits.SetText("Fruits " + nutrition.fruit);
            Dairy.SetText("Dairy " + nutrition.dairy);
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
