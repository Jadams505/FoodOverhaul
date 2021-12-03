using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System;
using Terraria.ID;
using FoodOverhaul.Util;
using Terraria.GameInput;
using FoodOverhaul.UI;

namespace FoodOverhaul
{
    public class FoodOverhaulPlayer : ModPlayer
    {

        public int Tick;

        public NutritionData nutrition = NutritionHelper.Full();

        public void AddNutrition(NutritionData other)
        {
            NutritionHelper.Add(ref nutrition, ref other);
        }
        public override void PreUpdateBuffs()
        {
            if(nutrition.Protein == NutritionData.MAX)
            {
                Player.AddBuff(BuffID.WellFed, TimeUtil.Minutes(10));
            }
        }

        public override void PostUpdateBuffs()
        {
            if(nutrition.Protein != NutritionData.MAX)
            {
                Player.ClearBuff(BuffID.WellFed);
                Player.ClearBuff(BuffID.WellFed2);
                Player.ClearBuff(BuffID.WellFed3);
            }
        }

        public override void PostUpdate()
        {
            Tick++;
            if(Tick % TimeUtil.Seconds(2) == 0)
            {
                NutritionHelper.Decrement(ref nutrition);
                NutritionUI.UpdateNutrition(nutrition);
            }
        }

        public override void LoadData(TagCompound tag)
        {
            nutrition = NutritionHelper.Full();
            try
            {
                nutrition.Protein = tag.GetInt("protein");
                nutrition.Fruits = tag.GetInt("fruits");
                nutrition.Vegetables = tag.GetInt("vegetables");
                nutrition.Carbs = tag.GetInt("carbs");
                nutrition.Dairy = tag.GetInt("dairy");
            }
            catch (Exception)
            {
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("protein", nutrition.Protein);
            tag.Add("fruits", nutrition.Fruits);
            tag.Add("vegatables", nutrition.Vegetables);
            tag.Add("carbs", nutrition.Carbs);
            tag.Add("dairy", nutrition.Dairy);
            base.SaveData(tag);
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (KeybindManager.toggleNutrition.JustPressed)
            {
                NutritionUI.Toggle();
            }
        }

        public static FoodOverhaulPlayer GetModPlayer()
        {
            try
            {
                return Main.player[Main.myPlayer].GetModPlayer<FoodOverhaulPlayer>();
            }
            catch(Exception)
            {
            }
            return null;
            
        }

    }
}
