using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class LastSoul : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Last Soul";
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 9;
			projectile.friendly = true;
			projectile.light = 0.8f;
			projectile.alpha = 255;
			projectile.magic = true;
			projectile.penetrate = -1;
		}

		public override void AI()
		{
			if(projectile.soundDelay == 0 && Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) > 2f)
			{
				projectile.soundDelay = 10;
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 9);
			}
			for(int num110 = 0; num110 < 8; num110++)
			{
				int num111 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
				Main.dust[num111].velocity *= 0.1f;
				Main.dust[num111].velocity += projectile.velocity * 0.2f;
				Main.dust[num111].position.X = projectile.position.X + (float)(projectile.width / 2) + 4f + (float)Main.rand.Next(-2, 3);
				Main.dust[num111].position.Y = projectile.position.Y + (float)(projectile.height / 2) + (float)Main.rand.Next(-2, 3);
				Main.dust[num111].noGravity = true;
			}
		}
	}
}