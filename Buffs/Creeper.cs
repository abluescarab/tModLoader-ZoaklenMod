using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Buffs
{
	public class Creeper : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Creeper";
			Main.buffTip[Type] = "The creeper will fight for you";
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if(player.ownedProjectileCounts[mod.ProjectileType("Creeper")] > 0)
			{
				modPlayer.creeperMinion = true;
			}
			if(!modPlayer.creeperMinion)
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