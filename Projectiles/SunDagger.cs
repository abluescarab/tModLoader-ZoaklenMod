using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class SunDagger : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Shuriken);
			projectile.name = "Sun Dagger";
			projectile.penetrate = 1;
			projectile.width = 30;
			projectile.height = 30;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 180;
			projectile.thrown = true;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 300, true);
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.position, Microsoft.Xna.Framework.Color.Yellow.ToVector3());
		}

		public override void Kill(int timeLeft)
		{
			float num1005 = (float)Main.rand.NextDouble() * (6.28318548f/3f);
			float num1006 = (float)Main.rand.NextDouble() * (6.28318548f/3f);
			float num1007 = (float)Main.rand.NextDouble() * (6.28318548f/3f);
			float num1008 = 4f + (float)Main.rand.NextDouble() * 4f;
			float num1009 = 4f + (float)Main.rand.NextDouble() * 4f;
			float num1010 = 4f + (float)Main.rand.NextDouble() * 4f;
			float num1011 = num1008;
			for(int num1012 = 0; num1012 < 10; num1012++)
			{
				int num1013 = 64;
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
				Main.dust[num1014].velocity *= -1f;
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
						Main.dust[num1014].velocity *= -5f;
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