using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class SkyBreakerSpear : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Daybreak);
			projectile.name = "Sky Breaker";
			projectile.aiStyle = 1;
			projectile.alpha = 0;
			projectile.thrown = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Daybreak, 600, true);
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			//Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
			for(int num269 = 4; num269 < 8; num269++)
			{
				float num270 = projectile.oldVelocity.X * (30f / (float)num269);
				float num271 = projectile.oldVelocity.Y * (30f / (float)num269);
				int num272 = Dust.NewDust(new Vector2(projectile.oldPosition.X - num270, projectile.oldPosition.Y - num271), 8, 8, 6, projectile.oldVelocity.X, projectile.oldVelocity.Y, 6, default(Color), 1.8f);
				Main.dust[num272].noGravity = true;
				Main.dust[num272].velocity *= 0.5f;
			}

			projectile.ai[0] += 1f;
			if(projectile.ai[0] > 30f)
			{
				projectile.ai[0] = 30f;
				projectile.velocity.Y = projectile.velocity.Y + 0.25f;
				if(projectile.velocity.Y > 16f)
				{
					projectile.velocity.Y = 16f;
				}
				projectile.velocity.X = projectile.velocity.X * 0.995f;
			}
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			if(projectile.owner == Main.myPlayer)
			{
				projectile.localAI[0] += 1f;
				if(projectile.localAI[0] >= 14f)
				{
					projectile.localAI[0] = 0f;
					int num551 = 0;
					for(int num552 = 0; num552 < 1000; num552++)
					{
						if(Main.projectile[num552].active && Main.projectile[num552].owner == projectile.owner && Main.projectile[num552].type == mod.ProjectileType("SkyBreakerFlakes"))
						{
							num551++;
						}
					}
					float num553 = (float)projectile.damage * 0.8f;
					if(num551 > 100)
					{
						float num554 = (float)(num551 - 100);
						num554 = 1f - num554 / 100f;
						num553 *= num554;
					}
					if(num551 > 100)
					{
						projectile.localAI[0] -= 1f;
					}
					if(num551 > 120)
					{
						projectile.localAI[0] -= 1f;
					}
					if(num551 > 140)
					{
						projectile.localAI[0] -= 1f;
					}
					if(num551 > 150)
					{
						projectile.localAI[0] -= 1f;
					}
					if(num551 > 160)
					{
						projectile.localAI[0] -= 1f;
					}
					if(num551 > 165)
					{
						projectile.localAI[0] -= 1f;
					}
					if(num551 > 170)
					{
						projectile.localAI[0] -= 2f;
					}
					if(num551 > 175)
					{
						projectile.localAI[0] -= 3f;
					}
					if(num551 > 180)
					{
						projectile.localAI[0] -= 4f;
					}
					if(num551 > 185)
					{
						projectile.localAI[0] -= 5f;
					}
					if(num551 > 190)
					{
						projectile.localAI[0] -= 6f;
					}
					if(num551 > 195)
					{
						projectile.localAI[0] -= 7f;
					}
					if(num553 > (float)projectile.damage * 0.1f)
					{
						int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("SkyBreakerFlakes"), (int)num553*2, projectile.knockBack * 0.55f, projectile.owner, 0f, (float)Main.rand.Next(3));
						Main.projectile[proj].tileCollide = true;
						return;
					}
				}
			}
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}
	}
}