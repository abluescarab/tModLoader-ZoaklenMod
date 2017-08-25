using System;
using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Buffs
{
	public class Invader : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Invader";
			Main.buffTip[Type] = "The invader will fight for you";
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if (GetTotalInvaders(player) > 0)
			{
				modPlayer.invaderMinion = true;
			}
			if (!modPlayer.invaderMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
		
		private int GetTotalInvaders(Player player)
		{
			return (player.ownedProjectileCounts[mod.ProjectileType("Invader1")] + player.ownedProjectileCounts[mod.ProjectileType("Invader2")] + player.ownedProjectileCounts[mod.ProjectileType("Invader3")]);
		}
	}
}