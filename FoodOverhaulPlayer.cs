using Terraria;
using Terraria.ModLoader;
using FoodOverhaul.Classes;
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

        public Nutrition nutrition = Nutrition.Full();

        public void AddNutrition(Nutrition other)
        {
            nutrition.Add(other);
        }
        public override void PreUpdateBuffs()
        {
            if(nutrition.Protein.Val == Nutrition.MAX)
            {
                Player.AddBuff(BuffID.WellFed, TimeUtil.Minutes(10));
            }
        }

        public override void PostUpdateBuffs()
        {
            if(nutrition.Protein.Val != Nutrition.MAX)
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
                nutrition.Decrement();
                NutritionUI.UpdateNutrition(nutrition);
            }
        }

        public override void LoadData(TagCompound tag)
        {
            nutrition = Nutrition.Full();
            try
            {
                nutrition.WithProtein(tag.GetInt("protein"));
                nutrition.WithFruits(tag.GetInt("fruits"));
                nutrition.WithVegatables(tag.GetInt("vegetables"));
                nutrition.WithCarbs(tag.GetInt("carbs"));
                nutrition.WithDairy(tag.GetInt("dairy"));
            }
            catch (Exception)
            {
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("protein", nutrition.Protein.Val);
            tag.Add("fruits", nutrition.Fruits.Val);
            tag.Add("vegatables", nutrition.Vegatables.Val);
            tag.Add("carbs", nutrition.Carbs.Val);
            tag.Add("dairy", nutrition.Dairy.Val);
            base.SaveData(tag);
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (KeybindManager.debug.JustPressed)
            {
                ChatUtil.Info(nutrition.ToString());
            }
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
