using Terraria.UI;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.GameInput;

namespace FoodOverhaul.UI
{
    public class DragableContainer : UIElement
    {

        private bool _selected;

        public override void OnInitialize()
        {
            _selected = false;
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
                Left.Set(this.Left.Pixels + (Main.mouseX - Main.lastMouseX), 0);
                Top.Set(this.Top.Pixels + (Main.mouseY - Main.lastMouseY), 0);
            }
            base.Update(gameTime);
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
