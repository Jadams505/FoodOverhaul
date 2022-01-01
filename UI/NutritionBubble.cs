using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using ReLogic.Content;
using Terraria.ModLoader.UI;
using Terraria.GameContent;
using ReLogic.Graphics;

namespace FoodOverhaul.UI
{
    public class NutritionBubble : UIElement
    {
        private const int SEPERATING_PIXELS = 2;
        private const int BORDER_SIZE = 40;
        private const int FILL_SIZE = 32;
        private const int PIXEL_OFFSET = 4;

        private static Asset<Texture2D> _background = ModContent.Request<Texture2D>("FoodOverhaul/Assets/UI/Bubble_Background");
        private static DynamicSpriteFont _font = FontAssets.CombatText.First().Value;

        private int _value;
        private int _maxValue;
        private string _name;
        public Color Color { get; set; }
        public NutritionBubble(string name, Color color, int initialValue, int maxValue)
        {
            _name = name;
            Color = color;
            _maxValue = maxValue;
            _value = initialValue;
            Width.Set(BORDER_SIZE, 0);
            Height.Set(BORDER_SIZE, 0);
        }
        public void UpdateValue(int value)
        {
            _value = value;
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dim = GetDimensions();

            DrawBackground(spriteBatch, dim);
            DrawBorder(spriteBatch, dim);
            DrawFill(spriteBatch, dim);
            DrawText(spriteBatch, dim);

            if (IsMouseHovering)
            {
                /*
                Rectangle bounds = base.Parent.GetDimensions().ToRectangle();
                bounds.Y = 0;
                bounds.Height = Main.screenHeight;
                UICommon.DrawHoverStringInBounds(spriteBatch, _name, bounds);
                */
                Vector2 textSize = _font.MeasureString(_name) * 0.75f;
                float bubbleCenter = dim.X + BORDER_SIZE / 2;
                DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, _font, _name, 
                    new Vector2(bubbleCenter - textSize.X / 2, dim.Y + BORDER_SIZE), Color.White, 0, new Vector2(), 0.75f, SpriteEffects.None, 0);
            }
        }

        private void DrawBackground(SpriteBatch spriteBatch, CalculatedStyle dim)
        {
            spriteBatch.Draw(_background.Value, new Vector2(dim.X, dim.Y + PIXEL_OFFSET), new Rectangle(0, BORDER_SIZE + SEPERATING_PIXELS, FILL_SIZE + PIXEL_OFFSET, FILL_SIZE), new Color(255, 255, 255, 255 / 2));
        }
        private void DrawFill(SpriteBatch spriteBatch, CalculatedStyle dim)
        {
            spriteBatch.Draw(_background.Value, new Vector2(dim.X, dim.Y + PIXEL_OFFSET + (FILL_SIZE - PixelsToShow())), new Rectangle(0, BORDER_SIZE + FILL_SIZE - PixelsToShow() + SEPERATING_PIXELS, FILL_SIZE + PIXEL_OFFSET, PixelsToShow()), Color);
        }
        private void DrawBorder(SpriteBatch spriteBatch, CalculatedStyle dim)
        {
            spriteBatch.Draw(_background.Value, new Vector2(dim.X, dim.Y), new Rectangle(0, 0, BORDER_SIZE, BORDER_SIZE), Color.White);
        }
        private void DrawText(SpriteBatch spriteBatch, CalculatedStyle dim)
        {
            Vector2 textSize = _font.MeasureString(PercentToShow() + "") * 0.75f;
            DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, _font, PercentToShow() + "", new Vector2(dim.X + (BORDER_SIZE / 2) - (textSize.X / 2), dim.Y + BORDER_SIZE / 2 - textSize.Y / 2), Color.White, 0, new Vector2(), 0.75f, SpriteEffects.None, 0);
        }
        private float FillPercent()
        {
            return (float)_value / _maxValue;
        }
        private int PixelsToShow()
        {
            double pixels = FillPercent() * FILL_SIZE;
            return (int)Math.Round(pixels <= FILL_SIZE ? pixels : FILL_SIZE);
        }
        private int PercentToShow()
        {
            return (int)Math.Round(FillPercent() * 100);
        }

    }
}
