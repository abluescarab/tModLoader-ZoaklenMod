using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace ZoaklenMod.Projectiles.Minions
{
	//ported from my tAPI mod because I'm lazy
	public class ShadowflameApparition : Minion
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(317);
			projectile.netImportant = true;
			projectile.name = "Shadowflame Apparition";
			projectile.width = 24;
			projectile.height = 32;
			Main.projFrames[projectile.type] = 6;
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
				modPlayer.sfaMinion = false;
			}
			if(modPlayer.sfaMinion)
			{
				projectile.timeLeft = 2;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.ShadowFlame, 300, true);
		}

		public override bool PreAI()
		{
			projectile.alpha = 0;
			projectile.frameCounter++;
			if(projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 6;
			}
			int dust = Dust.NewDust(new Vector2(projectile.position.X+Main.rand.Next(0, projectile.width+1), projectile.position.Y+Main.rand.Next(0, projectile.height+1)), projectile.width, projectile.height, 27, 0f, 0f, 100, default(Color), 1f);
			return true;
		}

		public override bool MinionContactDamage()
		{
			return true;
		}
	}
}