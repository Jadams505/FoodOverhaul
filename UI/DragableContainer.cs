using Terraria.UI;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.GameInput;
using System;

namespace FoodOverhaul.UI
{
    public class DragableContainer : UIElement
    {

        private bool _selected;
        private bool _locked;

        public override void OnInitialize()
        {
            _selected = false;
            _locked = false;
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
            if (_selected && !_locked)
            {
                int deltaX = Main.mouseX - Main.lastMouseX, deltaY = Main.mouseY - Main.lastMouseY;
                if(Main.lastMouseX > 0 && Main.lastMouseX < Main.screenWidth && Main.lastMouseY > 0 && Main.lastMouseY < Main.screenHeight)
                {
                    Left.Set(Left.Pixels + deltaX, 0);
                    Top.Set(Top.Pixels + deltaY, 0);
                }
                
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

        public void Lock(bool lockPosition)
        {
            if (lockPosition)
            {
                _locked = true;
            }
            else
            {
                _locked = false;
            }
        }

        public void Unselect()
        {
            _selected = false;
        }
    }

    
}
