using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class ExplosiveCard : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Explosive Card";
			Main.projFrames[projectile.type] = 4;
			projectile.width = 22;
			projectile.height = 22;
			projectile.penetrate = 1;
			projectile.aiStyle = 1;
			projectile.ignoreWater = true;
			projectile.thrown = true;
			projectile.friendly = true;
			projectile.timeLeft = 180;
			projectile.noDropItem = true;
			aiType = ProjectileID.Bullet;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int l = 0; l < 10; l++)
			{
				int num5 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[num5].velocity *= 0.5f;
				Main.dust[num5].velocity += projectile.velocity * 0.1f;
			}
			for (int m = 0; m < 5; m++)
			{
				int num6 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num6].noGravity = true;
				Main.dust[num6].velocity *= 3f;
				Main.dust[num6].velocity += projectile.velocity * 0.2f;
				num6 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num6].velocity *= 2f;
				Main.dust[num6].velocity += projectile.velocity * 0.3f;
			}
			for (int n = 0; n < 1; n++)
			{
				int num7 = Gore.NewGore(new Vector2(projectile.position.X - 10f, projectile.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num7].position += projectile.velocity * 1.25f;
				Main.gore[num7].scale = 1.5f;
				Main.gore[num7].velocity += projectile.velocity * 0.5f;
				Main.gore[num7].velocity *= 0.02f;
			}
		}
		
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			Player player = Main.player[projectile.owner];
			if(Main.rand.Next(0, 101) < GetWeaponCrit(player))
			{
				crit = true;
			}
		}
		
		private int GetWeaponCrit(Player player)
		{
			Item item = player.inventory[player.selectedItem];
			int crit = item.crit;
			if(item.melee)
			{
				crit += player.meleeCrit;
			}
			else if(item.magic)
			{
				crit += player.magicCrit;
			}
			else if(item.ranged)
			{
				crit += player.rangedCrit;
			}
			else if(item.thrown)
			{
				crit += player.thrownCrit;
			}
			return crit;
		}
		
		public override bool PreAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}
			return true;
		}
		
		public override bool PreKill(int timeLeft)
		{
			projectile.type = 0;
			return true;
		}
	}
}