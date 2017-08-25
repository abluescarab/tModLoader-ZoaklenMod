using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class SkyBreakerFlakes : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.NorthPoleSnowflake);
			projectile.name = "Solar Excalibur";
			projectile.width = 20;
			projectile.height = 48;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.localAI[1] += 1f;
			if(projectile.localAI[1] > 5f)
			{
				projectile.alpha -= 50;
				if(projectile.alpha < 0)
				{
					projectile.alpha = 0;
				}
			}
			projectile.frame = (int)projectile.ai[1];
			if(projectile.localAI[1] > 20f)
			{
				projectile.localAI[1] = 20f;
				projectile.velocity.Y = projectile.velocity.Y + 0.15f;
			}
			projectile.rotation += Main.windSpeed * 0.2f;
			projectile.velocity.X = projectile.velocity.X + Main.windSpeed * 0.1f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			for(int num1001 = 0; num1001 < 5; num1001++)
			{
				int num1002 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 6, default(Color), 1.5f);
				Main.dust[num1002].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * (float)projectile.width / 2f;
				Main.dust[num1002].velocity *= 2f;
				Main.dust[num1002].noGravity = true;
				Main.dust[num1002].fadeIn = 2.5f;
			}
			for(int num1003 = 0; num1003 < 5; num1003++)
			{
				int num1004 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 6, default(Color), 2.7f);
				Main.dust[num1004].position = projectile.Center + Vector2.UnitX.RotatedByRandom(3.1415927410125732).RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2)) * (float)projectile.width / 2f;
				Main.dust[num1004].noGravity = true;
				Main.dust[num1004].velocity *= 3f;
			}
			float num1005 = (float)Main.rand.NextDouble() * 6.28318548f;
			float num1006 = (float)Main.rand.NextDouble() * 6.28318548f;
			float num1007 = (float)Main.rand.NextDouble() * 6.28318548f;
			float num1008 = 7f + (float)Main.rand.NextDouble() * 7f;
			float num1009 = 7f + (float)Main.rand.NextDouble() * 7f;
			float num1010 = 7f + (float)Main.rand.NextDouble() * 7f;
			float num1011 = num1008;
			if(num1009 > num1011)
			{
				num1011 = num1009;
			}
			if(num1010 > num1011)
			{
				num1011 = num1010;
			}
			for(int num1012 = 0; num1012 < 20; num1012++)
			{
				int num1013 = 6;
				float scaleFactor15 = num1011;
				if(num1012 > 50)
				{
					scaleFactor15 = num1009;
				}
				if(num1012 > 100)
				{
					scaleFactor15 = num1008;
				}
				if(num1012 > 150)
				{
					scaleFactor15 = num1010;
				}
				int num1014 = Dust.NewDust(projectile.position, 6, 6, num1013, 0f, 0f, 6, default(Color), 1f);
				Vector2 vector123 = Main.dust[num1014].velocity;
				Main.dust[num1014].position = projectile.Center;
				vector123.Normalize();
				vector123 *= scaleFactor15;
				if(num1012 > 30)
				{
					vector123.Y *= 0.5f;
					vector123 = vector123.RotatedBy((double)num1007, default(Vector2));
				}
				else if(num1012 > 20)
				{
					vector123.X *= 0.5f;
					vector123 = vector123.RotatedBy((double)num1005, default(Vector2));
				}
				else if(num1012 > 10)
				{
					vector123.Y *= 0.5f;
					vector123 = vector123.RotatedBy((double)num1006, default(Vector2));
				}
				Main.dust[num1014].velocity *= 0.2f;
				Main.dust[num1014].velocity += vector123;
				if(num1012 <= 40)
				{
					Main.dust[num1014].scale = 2f;
					Main.dust[num1014].noGravity = true;
					Main.dust[num1014].fadeIn = Main.rand.NextFloat() * 2f;
					if(Main.rand.Next(4) == 0)
					{
						Main.dust[num1014].fadeIn = 2.5f;
					}
					Main.dust[num1014].noLight = true;
					if(num1012 < 20)
					{
						Main.dust[num1014].position += Main.dust[num1014].velocity * 20f;
						Main.dust[num1014].velocity *= -1f;
					}
				}
			}
			return true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			for(int num1001 = 0; num1001 < 5; num1001++)
			{
				int num1002 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 6, default(Color), 1.5f);
				Main.dust[num1002].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * (float)projectile.width / 2f;
				Main.dust[num1002].velocity *= 2f;
				Main.dust[num1002].noGravity = true;
				Main.dust[num1002].fadeIn = 2.5f;
			}
			for(int num1003 = 0; num1003 < 5; num1003++)
			{
				int num1004 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 6, default(Color), 2.7f);
				Main.dust[num1004].position = projectile.Center + Vector2.UnitX.RotatedByRandom(3.1415927410125732).RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2)) * (float)projectile.width / 2f;
				Main.dust[num1004].noGravity = true;
				Main.dust[num1004].velocity *= 3f;
			}
			float num1005 = (float)Main.rand.NextDouble() * 6.28318548f;
			float num1006 = (float)Main.rand.NextDouble() * 6.28318548f;
			float num1007 = (float)Main.rand.NextDouble() * 6.28318548f;
			float num1008 = 7f + (float)Main.rand.NextDouble() * 7f;
			float num1009 = 7f + (float)Main.rand.NextDouble() * 7f;
			float num1010 = 7f + (float)Main.rand.NextDouble() * 7f;
			float num1011 = num1008;
			if(num1009 > num1011)
			{
				num1011 = num1009;
			}
			if(num1010 > num1011)
			{
				num1011 = num1010;
			}
			for(int num1012 = 0; num1012 < 20; num1012++)
			{
				int num1013 = 6;
				float scaleFactor15 = num1011;
				if(num1012 > 50)
				{
					scaleFactor15 = num1009;
				}
				if(num1012 > 100)
				{
					scaleFactor15 = num1008;
				}
				if(num1012 > 150)
				{
					scaleFactor15 = num1010;
				}
				int num1014 = Dust.NewDust(projectile.position, 6, 6, num1013, 0f, 0f, 6, default(Color), 1f);
				Vector2 vector123 = Main.dust[num1014].velocity;
				Main.dust[num1014].position = projectile.Center;
				vector123.Normalize();
				vector123 *= scaleFactor15;
				if(num1012 > 30)
				{
					vector123.Y *= 0.5f;
					vector123 = vector123.RotatedBy((double)num1007, default(Vector2));
				}
				else if(num1012 > 20)
				{
					vector123.X *= 0.5f;
					vector123 = vector123.RotatedBy((double)num1005, default(Vector2));
				}
				else if(num1012 > 10)
				{
					vector123.Y *= 0.5f;
					vector123 = vector123.RotatedBy((double)num1006, default(Vector2));
				}
				Main.dust[num1014].velocity *= 0.2f;
				Main.dust[num1014].velocity += vector123;
				if(num1012 <= 40)
				{
					Main.dust[num1014].scale = 2f;
					Main.dust[num1014].noGravity = true;
					Main.dust[num1014].fadeIn = Main.rand.NextFloat() * 2f;
					if(Main.rand.Next(4) == 0)
					{
						Main.dust[num1014].fadeIn = 2.5f;
					}
					Main.dust[num1014].noLight = true;
					if(num1012 < 20)
					{
						Main.dust[num1014].position += Main.dust[num1014].velocity * 20f;
						Main.dust[num1014].velocity *= -1f;
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