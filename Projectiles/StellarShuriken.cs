using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class StellarShuriken : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Stellar Shuriken";
			projectile.penetrate = 1;
			projectile.light = 8;
			projectile.aiStyle = 5;
			projectile.width = 36;
			projectile.height = 36;
			projectile.ignoreWater = true;
			projectile.thrown = true;
			projectile.friendly = true;
			projectile.timeLeft = 180;
			projectile.noDropItem = true;
			aiType = ProjectileID.Shuriken;
		}

		public override bool PreKill(int timeLeft)
		{
			for(int i = 0; i < 5; i++)
			{
				int num111 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 64, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num111].velocity.X = Main.rand.Next(-6, 7);
				Main.dust[num111].velocity.Y = Main.rand.Next(-6, 7);
				Main.dust[num111].noGravity = true;
			}
			projectile.type = 0;
			return true;
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

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			float projX;
			if(Main.rand.Next(2) == 0)
			{
				projX = Main.rand.Next(150, 600);
			}
			else
			{
				projX = Main.rand.Next(-600, -150);
			}

			float projY;
			if(Main.rand.Next(2) == 0)
			{
				projY = Main.rand.Next(150, 600);
			}
			else
			{
				projY = Main.rand.Next(-600, -150);
			}

			for(int i = 0; i < 3; i++)
			{
				int proj = Projectile.NewProjectile(projectile.Center.X + projX, projectile.Center.Y + projY, (projX/48)*-2, (projY/48)*-2, mod.ProjectileType("GhostShuriken"), (int)(projectile.damage / 5f), 0, projectile.owner);
			}
		}
	}
}