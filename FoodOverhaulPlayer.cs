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

        public PlayerNutritionData PlayerNutrition;

        public FoodOverhaulPlayer()
        {
            PlayerNutrition = Initial();
        }

        public void AddNutrition(NutritionData data)
        {
            PlayerNutrition.Add(ref data);
        }
        public override void PreUpdateBuffs()
        {
            if(HealthinessHelper.IsHealthy(PlayerNutrition))
            {
                Player.AddBuff(BuffID.WellFed, TimeUtil.Minutes(10));
            }
        }

        public override void PostUpdateBuffs()
        {
            if(!HealthinessHelper.IsHealthy(PlayerNutrition))
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
                PlayerNutrition.Decrement();
                NutritionBubblesUI.UpdateNutrition(PlayerNutrition);
            }
        }

        public override void LoadData(TagCompound tag)
        {
            PlayerNutrition = Initial();
            try
            {
                PlayerNutrition.Protein = tag.GetFloat("protein");
                PlayerNutrition.Calories = tag.GetFloat("calories");
                PlayerNutrition.Sodium = tag.GetFloat("sodium");
                PlayerNutrition.Carbs = tag.GetFloat("carbs");
                PlayerNutrition.Fat = tag.GetFloat("fat");
            }
            catch (Exception)
            {
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("protein", PlayerNutrition.Protein);
            tag.Add("fat", PlayerNutrition.Fat);
            tag.Add("calories", PlayerNutrition.Calories);
            tag.Add("carbs", PlayerNutrition.Carbs);
            tag.Add("sodium", PlayerNutrition.Sodium);
            base.SaveData(tag);
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (KeybindManager.toggleNutrition.JustPressed)
            {  
                NutritionBubblesUI.UpdateNutrition(PlayerNutrition);
                NutritionBubblesUI.Toggle();
            }
        }

        public override void OnRespawn(Player player)
        {
            player.GetModPlayer<FoodOverhaulPlayer>().PlayerNutrition = Initial(); // on death reset nutrition
            NutritionBubblesUI.UpdateNutrition(PlayerNutrition);
        }

        public override void PlayerConnect(Player player)
        {
            NutritionBubblesUI.UpdateNutrition(PlayerNutrition);
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
        public static PlayerNutritionData Initial()
        {
            return new PlayerNutritionData(new NutritionData(calories: HealthinessHelper.TARGET_CALORIES,
                fat: HealthinessHelper.TARGET_FAT, sodium: HealthinessHelper.TARGET_SODIUM, carbs: HealthinessHelper.TARGET_CARBS,
                protein: HealthinessHelper.TARGET_PROTEIN));
        }

    }
}
