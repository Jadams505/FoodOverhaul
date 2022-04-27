using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace FoodOverhaul.WorldGen.Trees
{
    public class AppleTree : ModTree
    {

        private static Mod Mod => ModLoader.GetMod("FoodOverhaul");

        private static Asset<Texture2D> _branch = Mod.Assets.Request<Texture2D>("Assets/WorldGen/Trees/Apple_Tree_Branches", AssetRequestMode.ImmediateLoad);
        private static Asset<Texture2D> _top = Mod.Assets.Request<Texture2D>("Assets/WorldGen/Trees/Apple_Tree_Tops", AssetRequestMode.ImmediateLoad);

        public override int DropWood()
        {
            return ItemID.Apple;
        }

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
        {
            return _branch?.Value;
        }

        public override Texture2D GetTexture()
        {
            return TextureAssets.Tile[TileID.Trees].Value;
        }
        
        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        {
            return _top?.Value;
        }
    }
}
