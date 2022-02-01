using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using FoodOverhaul.WorldGen.Trees;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Enums;
using Microsoft.Xna.Framework.Graphics;
using FoodOverhaul.Items.Placeable;

namespace FoodOverhaul.Tiles
{
    public class TestTile : ModTile
    {
        public override void SetStaticDefaults()
        {
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;

			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.AnchorValidTiles = new[] { ModContent.TileType<AppleGrass>() };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.DrawFlipHorizontal = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.RandomStyleRange = 3;
			TileObjectData.newTile.StyleMultiplier = 3;
			TileObjectData.addTile(Type);

            TileID.Sets.TreeSapling[Type] = true;
            TileID.Sets.CommonSapling[Type] = true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;

		public override void RandomUpdate(int i, int j)
		{
			Tile tile = Framing.GetTileSafely(i, j); // Safely get the tile at the given coordinates
			bool growSucess; // A bool to see if the tree growing was sucessful.

			// Style 0 is for the ExampleTree sapling, and style 1 is for ExamplePalmTree, so here we check frameX to call the correct method.
			// Any pixels before 54 on the tilesheet are for ExampleTree while any pixels above it are for ExamplePalmTree
			if (tile.frameX < 54)
				growSucess = Terraria.WorldGen.GrowTree(i, j);
			else
				growSucess = Terraria.WorldGen.GrowPalmTree(i, j);

			// A flag to check if a player is near the sapling
			bool isPlayerNear = Terraria.WorldGen.PlayerLOS(i, j);

			//If growing the tree was a sucess and the player is near, show growing effects
			if (growSucess && isPlayerNear)
				Terraria.WorldGen.TreeGrowFXCheck(i, j);
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
		{
			if (i % 2 == 1)
				effects = SpriteEffects.FlipHorizontally;
		}
    }

}
