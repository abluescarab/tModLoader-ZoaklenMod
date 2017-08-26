using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class GoldenCard : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Card");
		}

		public override void SetDefaults()
		{
			projectile.penetrate = 5;
			projectile.aiStyle = 1;
			projectile.width = 22;
			projectile.height = 22;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 180;
			projectile.noDropItem = true;
			projectile.thrown = true;
			Main.projFrames[projectile.type] = 4;
			aiType = ProjectileID.Bullet;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			if(Main.rand.Next(0, 101) < GetWeaponCrit(player))
			{
				crit = true;
				target.AddBuff(BuffID.Midas, 999999, true);
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
			if(projectile.frameCounter % 2 == 0)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 57, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dust].velocity.X = projectile.velocity.X / 2f;
				Main.dust[dust].velocity.Y = projectile.velocity.Y / 2f;
				Main.dust[dust].noGravity = true;
			}
			if(projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}
			return true;
		}

		public override bool PreKill(int timeLeft)
		{
			for(int i = 0; i < 10; i++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 57, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dust].velocity.X = projectile.velocity.X;
				Main.dust[dust].velocity.Y = (int)((projectile.velocity.Y / 2f) + Main.rand.Next(-4, 5));
			}
			projectile.type = 0;
			return true;
		}
	}
}