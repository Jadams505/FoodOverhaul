using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System;
using Terraria.ID;
using FoodOverhaul.Util;
using Terraria.GameInput;
using FoodOverhaul.UI;
using FoodOverhaul.Nutrition;

namespace FoodOverhaul
{
    public class FoodOverhaulPlayer : ModPlayer
    {

        public int Tick;

        public NutritionData nutrition = Initial();

        public void AddNutrition(NutritionData other)
        {
            nutrition.Add(ref other);
        }
        public override void PreUpdateBuffs()
        {
            if(HealthinessHelper.IsHealthy(nutrition))
            {
                Player.AddBuff(BuffID.WellFed, TimeUtil.Minutes(10));
            }
        }

        public override void PostUpdateBuffs()
        {
            if(!HealthinessHelper.IsHealthy(nutrition))
            {
                Player.ClearBuff(BuffID.WellFed);
                Player.ClearBuff(BuffID.WellFed2);
                Player.ClearBuff(BuffID.WellFed3);
            }
        }

        public override void PostUpdate()
        {
            Tick++;
            if(Tick % NutritionServerConfig.Get().TickRate == 0)
            {
                nutrition.Decrement();
                NutritionUI.UpdateNutrition(nutrition);
                NutritionBubblesUI.UpdateNutrition(nutrition);
            }
        }

        public override void LoadData(TagCompound tag)
        {
            nutrition = Initial();
            try
            {
                nutrition.Protein = tag.GetInt("protein");
                nutrition.Calories = tag.GetInt("calories");
                nutrition.Sodium = tag.GetInt("sodium");
                nutrition.Carbs = tag.GetInt("carbs");
                nutrition.Fat = tag.GetInt("fat");
            }
            catch (Exception)
            {
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("protein", nutrition.Protein);
            tag.Add("fat", nutrition.Fat);
            tag.Add("calories", nutrition.Calories);
            tag.Add("carbs", nutrition.Carbs);
            tag.Add("sodium", nutrition.Sodium);
            base.SaveData(tag);
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (KeybindManager.toggleNutrition.JustPressed)
            {  
                NutritionBubblesUI.UpdateNutrition(nutrition);
                NutritionBubblesUI.Toggle();
            }
            if (KeybindManager.toggleStats.JustPressed)
            {
                NutritionUI.Toggle();
            }
        }

        public override void OnRespawn(Player player)
        {
            player.GetModPlayer<FoodOverhaulPlayer>().nutrition = Initial(); // on death reset nutrition
            NutritionBubblesUI.UpdateNutrition(nutrition);
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

        public static NutritionData Initial()
        {
            return new NutritionData(calories: 2000, fat: 75, sodium: 2250, carbs: 275, protein: 50);
        }

    }
}
