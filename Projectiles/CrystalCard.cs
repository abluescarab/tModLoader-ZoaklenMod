using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class CrystalCard : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Crystal Card";
			projectile.penetrate = 1;
			projectile.aiStyle = 1;
			projectile.width = 22;
			projectile.height = 22;
			projectile.thrown = true;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 30;
			projectile.noDropItem = true;
			Main.projFrames[projectile.type] = 4;
			aiType = ProjectileID.Bullet;
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
			if(timeLeft <= 0)
			{
				for(int i = -1;i <= 1;i++)
				{
					int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("CrystalCardM"), (int)(projectile.damage * 0.4f), 0, projectile.owner);
					Main.projectile[proj].velocity = new Vector2((float)(projectile.velocity.X + Main.rand.Next(-2, 3)), (float)(projectile.velocity.Y + Main.rand.Next(-2, 3)));
				}
			}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
			for(int i = 0;i < 6;i++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 70, 0f, 0f, 50, default(Color), 1f);
				Main.dust[dust].velocity.X = Main.rand.Next(-4, 5);
				Main.dust[dust].velocity.Y = Main.rand.Next(-4, 5);
				Main.dust[dust].noGravity = true;
			}
			projectile.type = 0;
			return true;
		}
	}
}