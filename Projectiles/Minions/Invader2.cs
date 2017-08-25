using Terraria;

namespace ZoaklenMod.Projectiles.Minions
{
	public class Invader2 : InvaderAI
	{
		public override void CustomDefaults()
		{
			projectile.width = 22;
			projectile.height = 16;
		}

		public override void Attack()
		{
			int a2 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y+5, 0, 10f, mod.ProjectileType("InvaderShot"), (int)(projectile.damage * 0.4f), 0, 0);
		}
	}
}