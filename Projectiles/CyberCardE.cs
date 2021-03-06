using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class CyberCardE : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cyber Card");
		}

		public override void SetDefaults()
		{
			projectile.penetrate = 1;
			projectile.aiStyle = 1;
			projectile.width = 22;
			projectile.height = 22;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.timeLeft = 300;
			projectile.noDropItem = true;
			Main.projFrames[projectile.type] = 4;
			aiType = ProjectileID.Bullet;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			if(Main.rand.Next(0, 101) < GetWeaponCrit(player))
			{
				crit = true;
			}
			if(damage > 0 && target.lifeMax > 5 && !Main.player[projectile.owner].moonLeech)
			{
				vampireHeal(damage, new Vector2(target.Center.X, target.Center.Y));
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

		public override void AI()
		{
			projectile.frameCounter++;
			if(projectile.frameCounter % 2 == 0)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[dust].velocity.X += projectile.velocity.X / 2f;
				Main.dust[dust].velocity.Y += projectile.velocity.Y / 2f;
			}
			if(projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}
		}

		public override bool PreKill(int timeLeft)
		{
			for(int i = 0; i < 10; i++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Neon"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[dust].velocity.X += (int)(-((projectile.velocity.X / 2f) + Main.rand.Next(-8, 9)));
				Main.dust[dust].velocity.Y += (int)(-((projectile.velocity.Y / 2f) + Main.rand.Next(-8, 9)));
			}
			projectile.type = 0;
			return true;
		}

		public void vampireHeal(int dmg, Vector2 Position)
		{
			float num = (float)dmg * 0.075f;
			if((int)num == 0)
			{
				return;
			}
			if(Main.player[Main.myPlayer].lifeSteal <= 0f)
			{
				return;
			}
			Main.player[Main.myPlayer].lifeSteal -= num;
			int num2 = projectile.owner;
			Projectile.NewProjectile(Position.X, Position.Y, 0f, 0f, 305, 0, 0f, projectile.owner, (float)num2, num);
		}
	}
}