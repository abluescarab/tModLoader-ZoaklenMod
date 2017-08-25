using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class SkyBreaker : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.NorthPoleWeapon);
			projectile.name = "Sky Breaker";
			projectile.penetrate = -1;
			projectile.light = 8;
			projectile.width = 30;
			projectile.height = 30;
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			if (projectile.ai[0] == 0f)
			{
				projectile.ai[0] = 3f;
				projectile.netUpdate = true;
			}
			if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
			{
				projectile.ai[0] -= 2.4f;
				if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
				{
					projectile.localAI[0] = 1f;
					if (Collision.CanHit(Main.player[projectile.owner].position, Main.player[projectile.owner].width, Main.player[projectile.owner].height, new Vector2(player.Center.X + projectile.velocity.X * projectile.ai[0], player.Center.Y + projectile.velocity.Y * projectile.ai[0]), projectile.width, projectile.height))
					{
						Projectile.NewProjectile(player.Center.X + projectile.velocity.X * projectile.ai[0], player.Center.Y + projectile.velocity.Y * projectile.ai[0], projectile.velocity.X * 2.4f, projectile.velocity.Y * 2.4f, mod.	ProjectileType("SkyBreakerSpear"), (int)((double)projectile.damage * 0.8), projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
					}
				}
			}
			else
			{
				projectile.ai[0] += 2.1f;
			}
		}
		
		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}
	}
}