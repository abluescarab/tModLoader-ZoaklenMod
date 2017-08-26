using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZoaklenMod.Projectiles
{
	public class StarKitty : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star Kitty");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.StarWrath);
			projectile.damage = 300;
			projectile.penetrate = 1;
			aiType = ProjectileID.StarWrath;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.StarWrath;
			return true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for(int i = 0; i < 3; i++)
			{
				int a1 = Projectile.NewProjectile(projectile.Center.X - 1024f, projectile.Center.Y-(30f*(i+1)), 11.5f, -5f, ProjectileID.Meowmere, (int)(projectile.damage * .75f), 0, projectile.owner);
				Main.projectile[a1].aiStyle = 8;
				Main.projectile[a1].tileCollide = true;
			}
			for(int i = 0; i < 3; i++)
			{
				int a2 = Projectile.NewProjectile(projectile.Center.X + 1024f, projectile.Center.Y-(30f*(i+1)), -11.5f, -5f, ProjectileID.Meowmere, (int)(projectile.damage * .75f), 0, projectile.owner);
				Main.projectile[a2].aiStyle = 8;
				Main.projectile[a2].tileCollide = true;
			}
			return true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			for(int i = 0; i < 6; i++)
			{
				float spawnX = Main.rand.Next(-256,257);
				int a = Projectile.NewProjectile(projectile.Center.X + spawnX, projectile.Center.Y - 768f, (spawnX/48)*-1, 100f, ProjectileID.Meowmere, (int)(projectile.damage * .75f), 0, projectile.owner);
				Main.projectile[a].aiStyle = 14;
				Main.projectile[a].penetrate = 1;
				Main.projectile[a].tileCollide = true;
			}
		}
	}
}