using FoodOverhaul.Items.Placeable.Crops;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace FoodOverhaul.Tiles.Crops
{
    public class CarrotTile : CropBase
    {
        public override int StageCount => 3;
        public override int SeedType => ModContent.ItemType<Carrot>();
        public override int DropType => ModContent.ItemType<Carrot>();

		public override void SetStaticDefaults()
        {
			Main.tileFrameImportant[Type] = true;
			Main.tileObsidianKill[Type] = true;
			Main.tileCut[Type] = true;
			Main.tileNoFail[Type] = true;
			TileID.Sets.ReplaceTileBreakUp[Type] = true;
			TileID.Sets.IgnoredInHouseScore[Type] = true;
			TileID.Sets.IgnoredByGrowingSaplings[Type] = true;
			TileID.Sets.SwaysInWindBasic[Type] = true;
			TileID.Sets.SlowlyDiesInWater[Type] = true;

			AddMapEntryPerStage(Color.Orange, "Carrot", new Tuple<int, string>[] {
				Tuple.Create(0, "Immature Carrot"),
				Tuple.Create(1, "Growing Carrot"),
				Tuple.Create(2, "Mature Carrot")
			});

			TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
			TileObjectData.newTile.AnchorValidTiles = new int[] {
				TileID.Grass,
			};
			TileObjectData.newTile.AnchorAlternateTiles = new int[] {
				TileID.ClayPot,
				TileID.PlanterBox
			};
			TileObjectData.addTile(Type);

			SoundType = SoundID.Grass;
			SoundStyle = 0;
			DustType = DustID.OrangeTorch;
		}

        public override bool CanPlace(int i, int j)
        {
			Tile tile = Framing.GetTileSafely(i, j);

			if (tile.HasTile)
			{
				int tileType = tile.TileType;
				if (tileType == Type)
				{
					return FullGrown(i, j);
				}
				else
				{
					if (Main.tileCut[tileType] || TileID.Sets.BreakableWhenPlacing[tileType] || tileType == TileID.WaterDrip || tileType == TileID.LavaDrip || tileType == TileID.HoneyDrip || tileType == TileID.SandDrip)
					{
						bool foliageGrass = tileType == TileID.Plants || tileType == TileID.Plants2;
						bool moddedFoliage = tileType >= TileID.Count && (Main.tileCut[tileType] || TileID.Sets.BreakableWhenPlacing[tileType]);
						bool harvestableVanillaHerb = Main.tileAlch[tileType] && Terraria.WorldGen.IsHarvestableHerbWithSeed(tileType, tile.TileFrameX / 18);

						if (foliageGrass || moddedFoliage || harvestableVanillaHerb)
						{
							Terraria.WorldGen.KillTile(i, j);
							if (!tile.HasTile && Main.netMode == NetmodeID.MultiplayerClient)
							{
								NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j);
							}
							return true;
						}
					}
					return false;
				}
			}
			return true;
		}

        public override bool Drop(int i, int j)
		{
			int stage = GetStage(i, j);

			if (stage == 0)
			{
				return false;
			}

			Vector2 worldPosition = new Vector2(i, j).ToWorldCoordinates();
			Player nearestPlayer = Main.player[Player.FindClosest(worldPosition, 16, 16)];

			int dropAmount = 0;

			if (FullGrown(i, j))
			{
				dropAmount = 1;
				if (nearestPlayer.active && nearestPlayer.HeldItem.type == ItemID.StaffofRegrowth)
				{
					dropAmount += Main.rand.Next(1, 3);
				}
			}

			IEntitySource source = new EntitySource_TileBreak(i, j);

			if (dropAmount > 0)
			{
				Item.NewItem(source, worldPosition, DropType, dropAmount);
			}
			return false;
		}

        public override void RandomUpdate(int i, int j)
        {
			Grow(i, j);
        }
	}
}
