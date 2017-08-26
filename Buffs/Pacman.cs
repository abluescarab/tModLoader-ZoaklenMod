using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Buffs
{
	public class Pacman : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Pacman");
			Description.SetDefault("The eater of bits will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if(player.ownedProjectileCounts[mod.ProjectileType("Pacman")] > 0)
			{
				modPlayer.pacMinion = true;
			}
			if(!modPlayer.pacMinion)
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