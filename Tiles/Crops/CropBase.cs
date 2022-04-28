using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace FoodOverhaul.Tiles.Crops
{
    public abstract class CropBase : ModTile
    {
        public virtual int StageCount => 3;
        public virtual int SeedType => -1;
        public virtual int DropType => -1;

        /// <summary>
        /// A convenience method for adding minimap tile names by growth stage. This should be called in SetStaticDefaults just like AddMapEntry
        /// </summary>
        /// <param name="tileColor">The color the tile will be on the minimap</param>
        /// <param name="defaultName">The default name if no stage is specified</param>
        /// <param name="stageNamePairs">The list of stage to name pairs</param>
        public void AddMapEntryPerStage(Color tileColor, string defaultName, Tuple<int, string>[] stageNamePairs)
        {
            ModTranslation name = CreateMapEntryName();
            name.SetDefault(defaultName);
            AddMapEntry(tileColor, name, (_, x, y) =>
            {
                int stage = GetStage(x, y);
                foreach (Tuple<int, string> namePair in stageNamePairs)
                {
                    if (stage == namePair.Item1)
                    {
                        return namePair.Item2;
                    }
                }
                return defaultName;
            });
        }

        /// <summary>
        /// Whether or not the tile is in its final growth state 
        /// </summary>
        /// <param name="x">The x tile coordinate</param>
        /// <param name="y">The y tile coordinate</param>
        public bool FullGrown(int x, int y)
        {
            return GetStage(x, y) == StageCount - 1;
        }

        /// <summary>
        /// Grows the tile by one stage
        /// </summary>
        /// <param name="x">The x tile coordinate</param>
        /// <param name="y">The y tile coordinate</param>
        public void Grow(int x, int y)
        {
            Tile tile = Framing.GetTileSafely(x, y);
            TileObjectData data = TileObjectData.GetTileData(tile);

            if (!FullGrown(x, y))
            {
                tile.TileFrameX += (short)data.CoordinateFullWidth;
            }

            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendTileSquare(-1, x, y, data.Width, data.Height);
            }
        }

        /// <summary>
        /// Gets the stage from the tile in the world
        /// </summary>
        /// <param name="x">The x tile coordinate</param>
        /// <param name="y">The y tile coordinate</param>
        public int GetStage(int x, int y)
        {
            Tile tile = Framing.GetTileSafely(x, y);
            if (tile.TileType == Type)
            {
                TileObjectData data = TileObjectData.GetTileData(tile);
                return tile.TileFrameX / data.CoordinateFullWidth;
            }
            return -1;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            offsetY = -2;
        }

        public override bool IsTileSpelunkable(int i, int j)
        {
            return FullGrown(i, j);
        }
    }
}
