using Terraria.ModLoader;
using Terraria;

namespace FoodOverhaul.Buffs
{
    public class MalnutritionDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Malnutrition");
            Description.SetDefault("Medium decrease to all stats");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 3;
            player.GetCritChance(DamageClass.Melee) -= 3;
            player.GetCritChance(DamageClass.Ranged) -= 3;
            player.GetCritChance(DamageClass.Magic) -= 3;
            player.GetCritChance(DamageClass.Throwing) -= 3;
            player.GetDamage(DamageClass.Melee) -= 0.075f;
            player.GetDamage(DamageClass.Ranged) -= 0.075f;
            player.GetDamage(DamageClass.Magic) -= 0.075f;
            player.GetDamage(DamageClass.Throwing) -= 0.075f;
            player.meleeSpeed -= 0.075f;
            player.minionKB -= 0.75f;
            player.moveSpeed -= 0.3f;
            player.pickSpeed += 0.1f;
        }

    }
}
