using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace ZoaklenMod.Projectiles
{
	public class HolyArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.HolyArrow);
			projectile.name = "Holy Arrow";
			projectile.noDropItem = true;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			for (int num373 = 0; num373 < 10; num373++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 58, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 150, default(Color), 1.2f);
			}
			for (int num374 = 0; num374 < 3; num374++)
			{
				Gore.NewGore(projectile.position, new Vector2(projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
			}
			if (projectile.type == 12 && projectile.damage < 500)
			{
				for (int num375 = 0; num375 < 10; num375++)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 150, default(Color), 1.2f);
				}
				for (int num376 = 0; num376 < 3; num376++)
				{
					Gore.NewGore(projectile.position, new Vector2(projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
				}
			}
			float x = projectile.position.X + (float)Main.rand.Next(-400, 400);
			float y = projectile.position.Y - (float)Main.rand.Next(600, 900);
			Vector2 vector10 = new Vector2(x, y);
			float num377 = projectile.position.X + (float)(projectile.width / 2) - vector10.X;
			float num378 = projectile.position.Y + (float)(projectile.height / 2) - vector10.Y;
			int num379 = 22;
			float num380 = (float)Math.Sqrt((double)(num377 * num377 + num378 * num378));
			num380 = (float)num379 / num380;
			num377 *= num380;
			num378 *= num380;
			int num381 = projectile.damage;
			int num382 = Projectile.NewProjectile(x, y, num377, num378, 92, num381, projectile.knockBack, projectile.owner, 0f, 0f);
			if (projectile.type == 91)
			{
				Main.projectile[num382].ai[1] = projectile.position.Y;
				Main.projectile[num382].ai[0] = 1f;
			}
			else
			{
				Main.projectile[num382].ai[1] = projectile.position.Y;
			}
		}
		
		public override void AI()
		{
			if (projectile.ai[0] >= 20f)
			{
				projectile.ai[0] = 20f;
				projectile.velocity.Y = projectile.velocity.Y + 0.07f;
			}
		}
	}
}