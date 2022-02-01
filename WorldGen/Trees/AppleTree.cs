using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace FoodOverhaul.WorldGen.Trees
{
    public class AppleTree : ModTree
    {

        private static Mod Mod
        {
            get
            {
                return ModLoader.GetMod("FoodOverhaul");
            }
        }

        private static Texture2D _branches = Mod.Assets.Request<Texture2D>("Assets/WorldGen/Trees/Apple_Tree_Branches").Value;
        private static Texture2D _tops = Mod.Assets.Request<Texture2D>("Assets/WorldGen/Trees/Apple_Tree_Tops").Value;
        public override int DropWood()
        {
            return ItemID.Apple;
        }

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
        {
            return TextureAssets.TreeBranch[3].Value;
        }

        public override Texture2D GetTexture()
        {
            return TextureAssets.Wood[0].Value;
        }
        
        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        {
            return TextureAssets.TreeTop[2].Value;
        }
    }
}
