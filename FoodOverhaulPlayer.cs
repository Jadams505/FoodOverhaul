using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System;
using Terraria.ID;
using FoodOverhaul.Util;
using Terraria.GameInput;
using FoodOverhaul.UI;
using FoodOverhaul.Nutrition;
using FoodOverhaul.Buffs;
using System;

namespace FoodOverhaul
{
    public class FoodOverhaulPlayer : ModPlayer
    {

        public int Tick;
        public bool ModifiedValuesOutsideOfConfig;
        public PlayerNutritionData PlayerNutrition;

        public FoodOverhaulPlayer()
        {
            PlayerNutrition = Initial();
            ModifiedValuesOutsideOfConfig = false;
        }

        public void AddNutrition(NutritionData data)
        {
            PlayerNutrition.Add(ref data);
        }
        public override void PreUpdateBuffs()
        {
            
            int healthyValues = HealthinessHelper.GetNumberOfHealthyValues(PlayerNutrition);
            switch (healthyValues)
            {
                case 0:
                case 1:
                case 2:
                    Player.AddBuff(ModContent.BuffType<MalnutritionDebuff>(), 2, quiet: false);
                    break;
                case 3:
                    Player.AddBuff(BuffID.WellFed, 2, quiet: false);
                    break;
                case 4:
                    Player.AddBuff(BuffID.WellFed2, 2, quiet: false);
                    break;
                case 5:
                    Player.AddBuff(BuffID.WellFed3, 2, quiet: false);
                    break;
            }
        }

        public override void PostUpdateBuffs()
        {
            int healthyValues = HealthinessHelper.GetNumberOfHealthyValues(PlayerNutrition);
            switch (healthyValues)
            {
                case 0:
                case 1:
                case 2:
                    ClearWellFedExceptFor(null);
                    break;
                case 3:
                    ClearWellFedExceptFor(BuffID.WellFed);
                    break;
                case 4:
                    ClearWellFedExceptFor(BuffID.WellFed2);
                    break;
                case 5:
                    ClearWellFedExceptFor(BuffID.WellFed3);
                    break;
            }
        }

        private void ClearWellFedExceptFor(int? buffId)
        {
            if(buffId != BuffID.WellFed)
            {
                Player.ClearBuff(BuffID.WellFed);
            }
            if (buffId != BuffID.WellFed2)
            {
                Player.ClearBuff(BuffID.WellFed2);
            }
            if (buffId != BuffID.WellFed3)
            {
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
            PlayerNutrition.Protein = TryOrDefault("protein", tag);
            PlayerNutrition.Calories = TryOrDefault("calories", tag);
            PlayerNutrition.Sodium = TryOrDefault("sodium", tag);
            PlayerNutrition.Carbs = TryOrDefault("carbs", tag);
            PlayerNutrition.Fat = TryOrDefault("fat", tag);
        }

        private float TryOrDefault(string key, TagCompound tag)
        {
            if (tag.ContainsKey(key)) 
            {
                return tag.GetFloat(key);
            }
            Mod.Logger.Error("Failed to Load value for " + key);
            return 0;
            
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
                NutritionBubblesUI.ToggleVisibility(!NutritionBubblesUI.Enabled);
                ModifiedValuesOutsideOfConfig = true;
            }
        }

        public override void OnRespawn(Player player)
        {
            player.GetModPlayer<FoodOverhaulPlayer>().PlayerNutrition = Respawn(Math.Clamp(1 - HealthinessHelper.HEATHY_BUFFER - 0.1f, 0, 1));
            NutritionBubblesUI.UpdateNutrition(PlayerNutrition);
        }

        public override void OnEnterWorld(Player player)
        {
            NutritionBubblesUI.UpdateNutrition(player.GetModPlayer<FoodOverhaulPlayer>().PlayerNutrition);
        }

        public override void PreSavePlayer()
        {
            NutritionClientConfig config = NutritionClientConfig.Get();
            if (config != null && ModifiedValuesOutsideOfConfig)
            {
                config.Save();
            }
            ModifiedValuesOutsideOfConfig = false;
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

        public static PlayerNutritionData Respawn(float percent)
        {
            return new PlayerNutritionData(calories: HealthinessHelper.TARGET_CALORIES * percent, fat: HealthinessHelper.TARGET_FAT * percent,
                sodium: HealthinessHelper.TARGET_SODIUM * percent, carbs: HealthinessHelper.TARGET_CARBS * percent,
                protein: HealthinessHelper.TARGET_PROTEIN * percent);
        }

    }
}
