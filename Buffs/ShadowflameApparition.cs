using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Buffs
{
	public class ShadowflameApparition : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Shadowflame Apparition";
			Main.buffTip[Type] = "The shadowflame apparition will fight for you";
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if(player.ownedProjectileCounts[mod.ProjectileType("ShadowflameApparition")] > 0)
			{
				modPlayer.sfaMinion = true;
			}
			if(!modPlayer.sfaMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}