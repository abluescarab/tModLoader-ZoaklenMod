using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class PhantasmalArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(631);
			projectile.name = "Phantasm Buster Arrow";
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			int num67 = Main.rand.Next(5, 10);
			Vector2 vector22 = Main.OffsetsPlayerOnhand[player.bodyFrame.Y / 56] * 2f;
			vector22 -= new Vector2((float)(player.bodyFrame.Width - player.width), (float)(player.bodyFrame.Height - 42)) / 2f;
			for (int num68 = 0; num68 < num67; num68++)
			{
				int num69 = Dust.NewDust(player.RotatedRelativePoint(player.position + vector22, true) - projectile.velocity, 0, 0, 229, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num69].velocity *= 1.6f;
				Dust expr_288B_cp_0 = Main.dust[num69];
				expr_288B_cp_0.velocity.Y = expr_288B_cp_0.velocity.Y - 1f;
				Main.dust[num69].position -= Vector2.One * 4f;
				Main.dust[num69].position = Vector2.Lerp(Main.dust[num69].position, player.RotatedRelativePoint(player.position + vector22, true) - projectile.velocity, 0.5f);
				Main.dust[num69].noGravity = true;
			}
		}
		
		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}
	}
}