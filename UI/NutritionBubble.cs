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

        private readonly static Asset<Texture2D> _background = ModContent.Request<Texture2D>("FoodOverhaul/Assets/UI/Bubble_Background");
        private readonly static DynamicSpriteFont _font = FontAssets.CombatText.First().Value;

        private float _value;
        private readonly int _maxValue;
        private readonly string _name;
        public Color Color { get; set; }
        public enum Direction {LEFT, RIGHT, TOP, BOTTOM};
        public Direction TextAlignment { get; set; }
        public bool ShowPercent {get; set;}

        public NutritionBubble(string name, Color color, int initialValue, int maxValue)
        {
            _name = name;
            Color = color;
            TextAlignment = Direction.BOTTOM;
            ShowPercent = true;
            _maxValue = maxValue;
            _value = initialValue;
            Width.Set(BORDER_SIZE, 0);
            Height.Set(BORDER_SIZE, 0);
        }
        public void UpdateValue(float value)
        {
            _value = value;
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dim = GetDimensions();

            DrawBackground(spriteBatch, dim);
            DrawBorder(spriteBatch, dim);
            DrawFill(spriteBatch, dim);
            DrawValueInBubble(spriteBatch, dim);

            if (IsMouseHovering)
            {
                DrawLabel(spriteBatch, dim);
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
        private void DrawPercent(SpriteBatch spriteBatch, CalculatedStyle dim)
        {
            Vector2 textSize = _font.MeasureString(PercentToShow() + "") * 0.75f;
            DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, _font, PercentToShow() + "", new Vector2(dim.X + (BORDER_SIZE / 2) - (textSize.X / 2), dim.Y + BORDER_SIZE / 2 - textSize.Y / 2), Color.White, 0, new Vector2(), 0.75f, SpriteEffects.None, 0);
        }
        private void DrawValue(SpriteBatch spriteBatch, CalculatedStyle dim)
        {
            Vector2 textSize = _font.MeasureString(Math.Round(_value) + "") * 0.6f;
            DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, _font, Math.Round(_value) + "", new Vector2(dim.X + (BORDER_SIZE / 2) - (textSize.X / 2), dim.Y + BORDER_SIZE / 2 - textSize.Y / 2), Color.White, 0, new Vector2(), 0.6f, SpriteEffects.None, 0);
        }
        private void DrawValueInBubble(SpriteBatch spriteBatch, CalculatedStyle dim)
        {
            if (ShowPercent)
            {
                DrawPercent(spriteBatch, dim);
            }
            else
            {
                DrawValue(spriteBatch, dim);
            }
        }
        private void DrawLabel(SpriteBatch spriteBatch, CalculatedStyle dim)
        {
            Vector2 textSize = _font.MeasureString(_name) * 0.75f;
            Vector2 bubbleCenter = new Vector2(dim.X + BORDER_SIZE / 2, dim.Y + BORDER_SIZE / 2);
            switch (TextAlignment)
            {
                case Direction.BOTTOM:
                    DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, _font, _name,
                        new Vector2(bubbleCenter.X - textSize.X / 2, dim.Y + BORDER_SIZE),
                        Color.White, 0, new Vector2(), 0.75f, SpriteEffects.None, 0);
                    break;
                case Direction.TOP:
                    DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, _font, _name,
                        new Vector2(bubbleCenter.X - textSize.X / 2, dim.Y - textSize.Y),
                        Color.White, 0, new Vector2(), 0.75f, SpriteEffects.None, 0);
                    break;
                case Direction.RIGHT:
                    DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, _font, _name,
                        new Vector2(dim.X + BORDER_SIZE, bubbleCenter.Y - textSize.Y / 2),
                        Color.White, 0, new Vector2(), 0.75f, SpriteEffects.None, 0);
                    break;
                case Direction.LEFT:
                    DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, _font, _name,
                        new Vector2(dim.X - textSize.X, bubbleCenter.Y - textSize.Y / 2),
                        Color.White, 0, new Vector2(), 0.75f, SpriteEffects.None, 0);
                    break;
            }
        }
        
        private float FillPercent()
        {
            return _value / _maxValue;
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
