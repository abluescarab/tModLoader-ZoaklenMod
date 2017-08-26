using Terraria;
using Terraria.ID;

namespace ZoaklenMod.Projectiles.Minions
{
	//ported from my tAPI mod because I'm lazy
	public class Creeper : Minion
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Creeper");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(317);
			projectile.netImportant = true;
			projectile.width = 24;
			projectile.height = 32;
			Main.projFrames[projectile.type] = 1;
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			PlayerChanges modPlayer = (PlayerChanges)player.GetModPlayer(mod, "PlayerChanges");
			if(player.dead)
			{
				modPlayer.creeperMinion = false;
			}
			if(modPlayer.creeperMinion)
			{
				projectile.timeLeft = 2;
			}
		}

		public override bool MinionContactDamage()
		{
			return true;
		}
	}
}