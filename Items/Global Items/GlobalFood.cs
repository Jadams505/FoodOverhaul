﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FoodOverhaul.Classes;
using FoodOverhaul.Util;
using System;

namespace FoodOverhaul.Items.Global_Items
{
    public class GlobalFood : GlobalItem
    {

        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ItemID.Sets.IsFood[entity.netID] || entity.ModItem is ModFood;
        }

        public override void SetDefaults(Item item)
        {
            if(item.ModItem is ModFood food)
            {
                NutritionMap.Instance().Add(item, food.GetNutrition());
            }else
            {
                NutritionMap.Instance().Add(item, new());
            }
            base.SetDefaults(item);
        }

        public override void OnConsumeItem(Item item, Player player)
        {
            ChatUtil.Info("I ate Food Today");
            FoodOverhaulPlayer modPlayer;
            try
            {
                modPlayer = player.GetModPlayer<FoodOverhaulPlayer>();
                modPlayer.AddNutrition(NutritionMap.Instance().Get(item));
            }
            catch (KeyNotFoundException ex)
            {
                Mod.Logger.Error(ex);
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.AddRange(NutritionMap.Instance().GetNutritionTooltip(Mod, item));
        }


    }
}
