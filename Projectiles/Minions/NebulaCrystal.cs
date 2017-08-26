using Microsoft.Xna.Framework;
using Terraria;

namespace ZoaklenMod.Projectiles.Minions
{
	public class NebulaCrystal : Minion
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula Crystal");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(643);
			projectile.netImportant = true;
			Main.projFrames[projectile.type] = 8;
			Main.projPet[projectile.type] = true;
		}

		public override void CheckActive()
		{
			// Do nothing
		}

		public override bool PreAI()
		{
			projectile.alpha = 0;
			projectile.frameCounter++;
			if(projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 8;
			}

			int dust = Dust.NewDust(new Vector2(projectile.Center.X+Main.rand.Next(-32, 28), projectile.Center.Y+Main.rand.Next(-32, 28)), 4, 4, 27, 0f, 0f, 100, new Color(255, 0, 255, 0), 1f);
			Main.dust[dust].velocity.X = 0f;
			Main.dust[dust].velocity.Y = 0f;
			Main.dust[dust].fadeIn = 1f;
			Main.dust[dust].noGravity = true;
			return true;
		}

		public override void AI()
		{
			bool detectedhostileEnemy = false;
			for(int i = 0; i < 200; i++)
			{
				NPC nPC15 = Main.npc[i];
				float num1075 = projectile.Distance(nPC15.Center);
				if(nPC15.active && !nPC15.friendly && num1075 < 300f)
				{
					detectedhostileEnemy = true;
					break;
				}
			}
			if(detectedhostileEnemy)
			{
				int xAdd = 0;
				while(xAdd == 0)
				{
					xAdd = Main.rand.Next(-4, 5);
				}
				int yAdd = 0;
				while(yAdd == 0)
				{
					yAdd = Main.rand.Next(-4, 5);
				}
				Vector2 vector2 = new Vector2(projectile.Center.X + xAdd, projectile.Center.Y + yAdd);
				int num73 = projectile.damage;
				float num74 = projectile.knockBack;

				float num197 = (Main.rand.NextFloat() - 0.5f) * 0.7853982f * 0.7f;
				int num198 = 0;
				while(num198 < 10 && !Collision.CanHit(vector2, 0, 0, vector2.RotatedBy((double)num197, default(Vector2)) * 100f, 0, 0))
				{
					num197 = (Main.rand.NextFloat() - 0.5f) * 0.7853982f * 0.7f;
					num198++;
				}

				Vector2 vector11 = new Vector2(vector2.X - projectile.Center.X, vector2.Y - projectile.Center.Y).RotatedBy((double)num197, default(Vector2)) * (0.95f + Main.rand.NextFloat() * 0.3f);

				if(projectile.frame % 8 == 0)
					Projectile.NewProjectile(vector2.X, vector2.Y, vector11.X, vector11.Y, 634, num73, num74, projectile.owner, 0f, 0f);
			}
		}
	}
}