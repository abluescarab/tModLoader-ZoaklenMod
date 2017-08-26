using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class BitHoleMissile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bit Hole Missile");
		}

		public override void SetDefaults()
		{
			projectile.penetrate = 1;
			projectile.width = 22;
			projectile.height = 22;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.timeLeft = 600;
			projectile.noDropItem = true;
			projectile.ranged = true;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
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

		public override void AI()
		{
			if(projectile.localAI[0] == 0f)
			{
				projectile.ai[0] = (float)(Main.screenPosition.X + Main.mouseX);
				projectile.ai[1] = (float)(Main.screenPosition.Y + Main.mouseY);
				projectile.localAI[0] = 1f;
			}
			Vector2 final = new Vector2(projectile.ai[0], projectile.ai[1]);
			if(projectile.Distance(final) < 50)
			{
				projectile.Kill();
			}
			projectile.rotation += 0.11f;

			for(int i = 0; i < 3; i++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X+Main.rand.Next(projectile.width), projectile.position.Y+Main.rand.Next(projectile.height)), projectile.width, projectile.height, GetBitColor(), 0f, 0f, 0, default(Color), 2f);
				Main.dust[dust].velocity = Vector2.Zero;
				Main.dust[dust].noGravity = true;
			}
		}

		private int GetBitColor()
		{
			return (59 + Main.rand.Next(3));
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("BitHole"), projectile.damage, 0f, projectile.owner);
			projectile.type = 0;
			return true;
		}
	}
}