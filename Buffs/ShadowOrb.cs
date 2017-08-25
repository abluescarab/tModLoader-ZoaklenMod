using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Buffs
{
	public class ShadowOrb : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Shadow Orb";
			Main.buffTip[Type] = "The shadow orb will fight for you";
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if(player.ownedProjectileCounts[mod.ProjectileType("ShadowOrb")] > 0)
			{
				modPlayer.shadowOrbMinion = true;
			}
			if(!modPlayer.shadowOrbMinion)
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