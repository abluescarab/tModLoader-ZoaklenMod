using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class IchorCard : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ichor Card");
		}

		public override void SetDefaults()
		{
			projectile.penetrate = 1;
			projectile.aiStyle = 1;
			projectile.width = 22;
			projectile.height = 22;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 180;
			projectile.thrown = true;
			projectile.noDropItem = true;
			Main.projFrames[projectile.type] = 4;
			aiType = ProjectileID.Bullet;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			target.AddBuff(BuffID.Ichor, 300, true);
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
			if(projectile.frameCounter % 2 == 0)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 74, 0f, 0f, 100, new Color(185, 164, 0), 2f);
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
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 74, 0f, 0f, 100, new Color(185, 164, 0), 1f);
				Main.dust[dust].velocity.X = Main.rand.Next(-8, 9);
				Main.dust[dust].velocity.Y = Main.rand.Next(-8, 9);
			}
			projectile.type = 0;
			return true;
		}
	}
}